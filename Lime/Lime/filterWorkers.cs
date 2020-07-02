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

namespace Lime
{
    public partial class filterWorkers : Form
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        private string params_filterCl;
        string params_filter;
        string dates;
        List<String> members;
        public filterWorkers(string _params_filter, List<String> _members, string startDate_value, string endDate_value)
        {
            params_filter = _params_filter;
            members =  _members;
            dates = " ((startDate <'" + startDate_value + "' and " + "endDate <'" + endDate_value+ "'))";
            InitializeComponent();
        }

        private void filterWorkers_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=CHRISTINA\\SQLEXPRESS;Database=lime;trusted_connection=true;";
            con.Open();
            this.Name = "Учет сотрудников";


            params_filterCl = "left join workers_skills on workers_skills.workerId = workers.Id left join project_members on project_members.workerId = workers.id left join projects on projects.id =project_members.projectId  where workers_skills.skillId in( " + params_filter + ")";

           params_filter = params_filterCl + " and " + dates + "";
            Table_Load(params_filter);
        }
        private void Table_Load(string param = "")
        {
            string _members = "";


           if (members.Count>0)   _members = " where workers.id in ( " + String.Join(",", members) + ") ";
     

            string  query = "Select DISTINCT  workers.id, CONCAT_WS(' ',firstName,middleName,lastName) as 'Фамилия Имя Отчество',departments.name as 'Отдел', positions.name as 'Должность', phone as 'Телефон', email as 'email', CONCAT_WS(' ','серия '+ seriesPassport,'№'+numberPassport,'выдан '+CONVERT(varchar, whenPassport, 105),byWhomPassport) as 'Паспортные данные', registrationAddress 'Адрес регистрации' from workers left join departments on departments.id=departmentId left join positions on positions.id=positionId  " + param + "";
        
            if (members.Count > 0) query += " union Select  workers.id, CONCAT_WS(' ',firstName,middleName,lastName) as 'Фамилия Имя Отчество',departments.name as 'Отдел', positions.name as 'Должность', phone as 'Телефон', email as 'email', CONCAT_WS(' ','серия '+ seriesPassport,'№'+numberPassport,'выдан '+CONVERT(varchar, whenPassport, 105),byWhomPassport) as 'Паспортные данные', registrationAddress 'Адрес регистрации' from workers left join departments on departments.id=departmentId left join positions on positions.id=positionId  " + _members + "";
             
            query += " union Select DISTINCT  workers.id, CONCAT_WS(' ',firstName,middleName,lastName) as 'Фамилия Имя Отчество',departments.name as 'Отдел', positions.name as 'Должность', phone as 'Телефон', email as 'email', CONCAT_WS(' ','серия '+ seriesPassport,'№'+numberPassport,'выдан '+CONVERT(varchar, whenPassport, 105),byWhomPassport) as 'Паспортные данные', registrationAddress 'Адрес регистрации' from workers left join departments on departments.id=departmentId left join positions on positions.id=positionId " + params_filterCl + " and workers.id not in(select workerId from project_members) ";
          
            textBox1.Text = query;
            LoadData(query, dataGridViewDirectory);
        }
        public Dictionary<int, string> GetId()
        {
            Dictionary<int, string> array = new Dictionary<int, string>();
          
            for (int i=0;  i< dataGridViewDirectory.Rows.Count;i++ )
            {
                
                   if (Convert.ToBoolean(dataGridViewDirectory.Rows[i].Cells["check"].Value) == true)
                    array.Add(Convert.ToInt32(dataGridViewDirectory.Rows[i].Cells["id"].Value.ToString()), dataGridViewDirectory.Rows[i].Cells["Фамилия Имя Отчество"].Value.ToString()+", тел."+ dataGridViewDirectory.Rows[i].Cells["Телефон"].Value.ToString());
           
            }
            return array;
        }
    
        private void LoadData(string query, DataGridView dtg)
        {

            try
            {
                da = new SqlDataAdapter(query, con);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                da.Fill(table);
                bs.DataSource = table;

                DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                {
                    column.HeaderText = "";
                    column.Name = "check";
              
                    column.CellTemplate = new DataGridViewCheckBoxCell();
                 
                }

                dtg.Columns.Insert(0, column);

                dtg.DataSource = table;
                dtg.Columns["id"].Visible = false;
                dtg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtg.Columns.Add(new DataGridViewTextBoxColumn() { Name = "skills", HeaderText = "Навыки" });
                    foreach (DataGridViewRow row in dtg.Rows)
                    {
                    if (members.Exists(e => e.EndsWith(row.Cells["id"].Value.ToString()))) row.Cells["check"].Value = true;




                        string commandText = "Select skills.name, workers_skills.level  from workers left join workers_skills on workerId = workers.id left join skills on skills.id = workers_skills.skillId  where workers.id=" + row.Cells["id"].Value + "";
                        SqlCommand command = new SqlCommand(commandText, con);
                        SqlDataReader reader = command.ExecuteReader();

                        List<String> text = new List<String>();
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // построчно считываем данные
                            {
                                if (reader["name"].ToString() != "")
                                    text.Add(reader["name"].ToString().Trim() + ", уровень - " + reader["level"].ToString() + ";");

                            }
                            reader.Close();

                        }
                        row.Cells["skills"].Value = String.Join(Environment.NewLine, text);
                    }
             
                

                dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtg.Columns[dtg.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            da.Dispose();

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
