using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using DataTable = System.Data.DataTable;

namespace Lime
{
    public partial class Report : Form
    {
        string report_name;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        string query;
        Word._Application oWord = new Word.Application();
        public Report(string _report_name)
        {
            con.ConnectionString = "Data Source=CHRISTINA\\SQLEXPRESS;Database=lime;trusted_connection=true;";
            con.Open();
            report_name = _report_name;
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            Table_Load();
        }
        private void Table_Load(string param = "")
        {
            switch (report_name)
            {
                case "skills":
                    query = "select skills.id, TRIM( ' ' from skills.name) ,count(project_needs.skillId) as prcoutn, count(workers_skills.skillId) as workers, (sum(workers_skills.level)/count(workers_skills.skillId))  as avglevel from skills left join workers_skills on workers_skills.skillId = skills.id left join project_needs on project_needs.skillId = skills.id  group by skills.id, skills.name order by prcoutn desc";
                    //  nameTable.Text = "Сотрудники";
                    // activepanel = panel_add_worker;
                    LoadData(query, dataGridView);
                    dataGridView.Columns[1].HeaderText = "Навык";
                    dataGridView.Columns[2].HeaderText = "Кол-во проектов";
                    dataGridView.Columns[3].HeaderText = "Кол-во сотрудников";
                    dataGridView.Columns[4].HeaderText = "Средний уровень";
                    wordreport();
                    dataGridView.Visible = true;
                    textBox1.Visible = true;
                    label1.Text = "ОТЧЕТ ПО НАВЫКАМ В ПРОЕКТАХ";
                    break;
                case "projects":
                    dataGridView1.Visible = true;
                    query = "select projects.ID,trim(' ' from  projects.projectName),FORMAT(projects.startDate, N'D') as startDate  , trim(' ' from skills.name) from projects left join project_needs on project_needs.projectId = projects.id left join skills on skills.id = project_needs.skillId where skillId not in (select skillId from workers_skills left join project_members on project_members.workerId = workers_skills.workerId where project_members.projectId = projects.id)";
                    LoadData(query, dataGridView1);
                    label1.Text = "ОТЧЕТ ПО ПРОЕКТАМ, НЕ НАБРАВШИХ СОТРУДНИКОВ ПО НЕОБХОДИМЫМ НАВЫКАМ";
                    break;

                case "projects_date":
                    dataGridView.Visible = true;
                    query = "select DATENAME(MONTH,startDate) as  Month, CAST (count(project_members.workerId) AS VARCHAR(10) )  as 'count' from project_members right join projects on projects.id = projectId where 'dage' is not null group by MONTH(startDate), DATENAME(MONTH,startDate) order by MONTH(startDate)";
                    LoadData(query, dataGridView);
                    dataGridView.Columns[0].HeaderText = "Месяц";
                    dataGridView.Columns[1].HeaderText = "Кол-во проектов";
                    label1.Text = "ОТЧЕТ ПО МЕСЯЧНОЙ НАГРУЗКЕ СОТРУДНИКОВ В ПРОЦЕНТАХ";

                    string sql = "select count(id) from workers ";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    int newProdID=0;
                    try
                    {

                        newProdID = (Int32)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                      
                    }
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                      dataGridView.Rows[i].Cells[1].Value = Convert.ToString(Convert.ToDouble(dataGridView.Rows[i].Cells[1].Value.ToString()) * 100 / Convert.ToDouble(newProdID)) + "%";
                    }

                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        chart1.Series["Series1"].Points.AddXY(dataGridView.Rows[i].Cells[0].Value, Convert.ToDouble(dataGridView.Rows[i].Cells[1].Value.ToString().TrimEnd('%')));
                    }
                    break;

            }





        }
        private void LoadData(string query, DataGridView dtg)
        {

            try
            {

                int count = dtg.Columns.Count;
                for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
                {
                    dtg.Columns.RemoveAt(0);
                }

                da = new SqlDataAdapter(query, con);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                da.Fill(table);
                List<String> list = new List<String>();
                if (report_name == "projects")
                {
                    dtg.Columns.Add("id", "id");
                    dtg.Columns.Add("project", "Проект");
                    dtg.Columns.Add("start", "Начало");
                    dtg.Columns.Add("skills", "Недобор по навыкам");

                    DataView dv = table.DefaultView;
                    dv.Sort = "startDate desc";
                    DataTable sortedDT = dv.ToTable();


                    foreach (DataRow dtRow in table.Rows)
                    {
                        if (!list.Contains(dtRow[0].ToString()))
                        {
                            var field1 = dtRow[0].ToString();
                            List<String> pr = new List<String>();
                            list.Add(dtRow[0].ToString());
                            foreach (DataRow dc in table.Rows)
                            {
                                if (field1 == dc[0].ToString())
                                {
                                    pr.Add(dc[3].ToString());

                                }
                            }
                            dtg.Rows.Add();
                            dtg.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = dtRow[0].ToString();
                            dtg.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = dtRow[1].ToString();
                            dtg.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = dtRow[2].ToString();
                            dtg.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = String.Join(", ", pr);
                        }
                    }
                }

                else
                {
                    bs.DataSource = table;
                    dtg.DataSource = table;

                }
                if (report_name == "projects" || report_name == "skills")
                {
                    dtg.Columns["id"].Visible = false;
                }
                dtg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


                dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtg.Columns[dtg.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            da.Dispose();

        }
        private void поВостребованнымНавыкамToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private _Document GetDoc(string path)
        {

            // Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
            _Document oDoc = oWord.Documents.Add(path);


            var paragraphone = oWord.ActiveDocument.Paragraphs.Add();
            paragraphone.Range.Text = textBox1.Text.ToString();
            paragraphone.Range.Font.Name = "Times New Roman";
            paragraphone.Range.Font.Size = 14;



            // SetTemplate(oDoc);
            //Добавляем параграф в конец документа
            var Paragraph = oWord.ActiveDocument.Paragraphs.Add();

            //Получаем диапазон
            var tableRange = Paragraph.Range;


            //Добавляем таблицу 2х2 в указаный диапазон

            oWord.ActiveDocument.Tables.Add(tableRange, 1, 4);
            oWord.ActiveDocument.Tables[oWord.ActiveDocument.Tables.Count].AllowAutoFit = true;
            oWord.ActiveDocument.Tables[oWord.ActiveDocument.Tables.Count].AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);

            //"Приукрашиваем" таблицу, иначе по-дефолту она будет без линий
            var table = oWord.ActiveDocument.Tables[oWord.ActiveDocument.Tables.Count];
            table.set_Style("Сетка таблицы");
            table.ApplyStyleHeadingRows = true;
            table.ApplyStyleLastRow = false;
            table.ApplyStyleFirstColumn = true;
            table.ApplyStyleLastColumn = false;
            table.ApplyStyleRowBands = true;
            table.ApplyStyleColumnBands = false;
            table.Range.Font.Size = 12;



            foreach (DataGridViewCell cell in dataGridView.Rows[0].Cells)
            {
                table.Cell(table.Rows.Count, cell.ColumnIndex).Range.Text = dataGridView.Columns[cell.ColumnIndex].HeaderText;
                table.Cell(table.Rows.Count, cell.ColumnIndex).Range.Bold = 1;

            }
            // table.Rows.Add();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                table.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {

                    table.Cell(table.Rows.Count, cell.ColumnIndex).Range.Text = cell.Value.ToString();
                    table.Cell(table.Rows.Count, cell.ColumnIndex).Range.Bold = 0;
                }

            }

            DateTime date1 = DateTime.Now;
            paragraphone = oWord.ActiveDocument.Paragraphs.Add();

            paragraphone.Range.Text = "Дата формирования отчета: " + date1.ToLongDateString() + ", " + date1.ToShortTimeString();
            paragraphone.Range.Font.Name = "Times New Roman";
            paragraphone.Range.Font.Size = 14;
            paragraphone.Range.ParagraphFormat.SpaceBefore = 22;
            oWord.Visible = true;
            // oWord.UserControl = true;
            return oDoc;
        }
        public void wordreport()
        {
            int newProdID = 0;
            string sql = "select count(id) from projects ";

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {

                newProdID = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            textBox1.Text += "Кол-во текущих проектов: " + newProdID + Environment.NewLine;
            List<String> pr = new List<String>();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (Convert.ToDouble(dataGridView.Rows[i].Cells[2].Value.ToString()) / Convert.ToDouble(newProdID) >= 0.5)
                    pr.Add(dataGridView.Rows[i].Cells[1].Value.ToString());
            }
            textBox1.Text += "Наиболее востребованные навыки: " + String.Join(", ", pr) + Environment.NewLine;

            List<String> skills = new List<String>();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView.Rows[i].Cells[3].Value.ToString()) == 0)
                    skills.Add(dataGridView.Rows[i].Cells[1].Value.ToString());
            }
            textBox1.Text += "Недобор сотрудников по навыкам: " + String.Join(", ", skills) + Environment.NewLine;


            List<String> skills_down = new List<String>();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[4].Value.ToString() != "" && (Convert.ToInt32(dataGridView.Rows[i].Cells[4].Value.ToString()) == 1 || Convert.ToInt32(dataGridView.Rows[i].Cells[4].Value.ToString()) == 2))
                    skills_down.Add(dataGridView.Rows[i].Cells[1].Value.ToString());
            }
            textBox1.Text += "Наименее развитые навыки: " + String.Join(", ", skills_down) + Environment.NewLine;

            List<String> skills_up = new List<String>();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[4].Value.ToString() != "" && (Convert.ToInt32(dataGridView.Rows[i].Cells[4].Value.ToString()) == 5 || Convert.ToInt32(dataGridView.Rows[i].Cells[4].Value.ToString()) == 4))
                    skills_up.Add(dataGridView.Rows[i].Cells[1].Value.ToString());
            }

            textBox1.Text += "Наиболее развитые навыки: " + String.Join(", ", skills_up) + Environment.NewLine;

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (report_name == "skills")
            {
                _Document oDoc = GetDoc(Environment.CurrentDirectory + "\\sh2.dotx");

                //  oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\New.docx");
                // oDoc.Close();
            }
            if (report_name == "projects")
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                ExcelWorkSheet.Rows.WrapText = true;
                // excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 1, j] = dataGridView1.Rows[i].Cells[j].Value;
                        ExcelApp.Cells[i + 1, j].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                        ExcelApp.Cells[i + 1, j].VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        ((Microsoft.Office.Interop.Excel.Range)ExcelWorkSheet.Cells[i + 1, j]).BorderAround(XlLineStyle.xlContinuous);

                    }
                }

                Microsoft.Office.Interop.Excel.Range rg = null;
                rg = ExcelWorkSheet.get_Range("A1"); //Можно выбрать диапазон, например ("A1", "C1"), т.е. первый 3 столбца
                rg.ColumnWidth = 20;

                rg = ExcelWorkSheet.get_Range("B1"); //Можно выбрать диапазон, например ("A1", "C1"), т.е. первый 3 столбца
                rg.ColumnWidth = 20;
                rg = ExcelWorkSheet.get_Range("c1"); //Можно выбрать диапазон, например ("A1", "C1"), т.е. первый 3 столбца
                rg.ColumnWidth = 30;
                //Вызываем нашу созданную эксельку.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }


            if (report_name == "projects_date")
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;

                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                ExcelWorkSheet.Rows.WrapText = true;


                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                      
                        ExcelApp.Cells[i + 1, j + 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                        ExcelApp.Cells[i + 1, j + 1].VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        ((Microsoft.Office.Interop.Excel.Range)ExcelWorkSheet.Cells[i + 1, j + 1]).BorderAround(XlLineStyle.xlContinuous);


                    }
                    
                    ExcelApp.Cells[i + 1, 1] = dataGridView.Rows[i].Cells[0].Value.ToString();
                        ExcelApp.Cells[i + 1, 2] = Convert.ToDouble(dataGridView.Rows[i].Cells[1].Value.ToString().TrimEnd('%'))/100;
   

                }
                ExcelApp.Range["B1", "B4" + dataGridView.Rows.Count].NumberFormat = "0.00%";
                // ExcelWorkSheet.get_Range("B1", "B" + dataGridView.Rows.Count).NumberFormat = "PERCENT";
                Microsoft.Office.Interop.Excel.ChartObjects xlCharts = (Microsoft.Office.Interop.Excel.ChartObjects)ExcelWorkSheet.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)xlCharts.Add(110, 0, 350, 250);
                Microsoft.Office.Interop.Excel.Chart chart = myChart.Chart;
                Microsoft.Office.Interop.Excel.SeriesCollection seriesCollection = (Microsoft.Office.Interop.Excel.SeriesCollection)chart.SeriesCollection(Type.Missing);
                Microsoft.Office.Interop.Excel.Series series = seriesCollection.NewSeries();
                series.XValues = ExcelWorkSheet.get_Range("A1", "A" + dataGridView.Rows.Count);
                series.Values = ExcelWorkSheet.get_Range("B1", "B" + dataGridView.Rows.Count);
                chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnStacked;
                chart.Legend.Delete();
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            openReport("skills");
        }


      
        private void openReport(string name)
        {
            this.Hide();
            Report report = new Report(name);
            report.FormClosed += (object s, FormClosedEventArgs ev) => { this.Show(); };
            report.Show();

        }

        private void поToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openReport("projects");
        }

        private void поКолвуПроектовВМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поКолвуПроектовВМесяцToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openReport("projects_date");
        }
    }
}
