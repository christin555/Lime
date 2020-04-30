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
    public partial class Directory : Form
    {
        string directory_name;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        string query;
        public Directory()
        {
            InitializeComponent();
        }
        public Directory(string _directory_name)
        {
            this.Name = "Учет сотрудников";
            directory_name = _directory_name;
            InitializeComponent();
        }
        private void Directory_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "limeDataSet.positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.limeDataSet.positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "limeDataSet.departments". При необходимости она может быть перемещена или удалена.
            this.departmentsTableAdapter.Fill(this.limeDataSet.departments);
            this.WindowState = FormWindowState.Maximized;
            dataGridViewDirectory.DataSource = bs;
            con.ConnectionString = "Data Source=CHRISTINA\\SQLEXPRESS;Database=lime;trusted_connection=true;";
            Table_Load();


        }
        private void Table_Load()
        {
            switch (directory_name)
            {
                case "workers":
                    query = "Select workers.id, CONCAT_WS(' ',firstName,middleName,lastName) as 'Фамилия Имя Отчество',departments.name as 'Отдел', positions.name as 'Должность', phone as 'Телефон', email as 'email', CONCAT_WS(' ','серия '+ seriesPassport,'№'+numberPassport,'выдан '+CONVERT(varchar, whenPassport, 105),byWhomPassport) as 'Паспортные данные', registrationAddress 'Адрес регистрации' from workers left join departments on departments.id=departmentId left join positions on positions.id=positionId ";
                    nameTable.Text = "Сотрудники";
                    break;
                case "positions":
                    query = "select id, name as 'Наименование' from positions ";
                    nameTable.Text = "Должности";
                    break;
                case "departments":
                    query = "select id, name as 'Наименование' from departments";
                    nameTable.Text = "Отдела";
                    break;
            }
            LoadData(query, dataGridViewDirectory);
        }
        private void LoadData(string query, DataGridView dtg)
        {
            con.Open();
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
                dtg.DataSource = bs;
                dtg.Columns["id"].Visible = false;
                dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtg.Columns[dtg.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            da.Dispose();
            con.Close();
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directory_name = "workers";
            Table_Load();
            // openDirectory("workers");
        }
        private void openDirectory(string name)
        {
            Directory directory = new Directory(name);
            directory.Show();
            this.Close();
        }

        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directory_name = "departments";
            Table_Load();
            // openDirectory("departments");
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directory_name = "positions";
            Table_Load();
            //openDirectory("positions");
        }

        private void gotToAdd_Edit(bool param)
        {
            button_add.Enabled = !param;
            button_delete.Enabled = !param;
            button_edit.Enabled = !param;
            panel_add_worker.Visible = param;
            button_save.Visible = param;
            dataGridViewDirectory.Visible = !param;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            gotToAdd_Edit(true);
            switch (directory_name)
            {
                case "workers":
                    nameTable.Text = "Добавление сотрудника";
                    break;
                case "positions":
                    nameTable.Text = "Должности";
                    break;
                case "departments":
                    nameTable.Text = "Отдела";
                    break;
            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            switch (directory_name)
            {
                case "workers":
                    add_worker();
                    break;
                case "positions":
                    add_position();
                    break;
                case "departments":
                    add_department();
                    break;
            }
            gotToAdd_Edit(false);
            Table_Load();

        }



        public IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateTimePicker));
        }

        private Dictionary<string, string> getValuesfromfields()
        {
            Dictionary<string, string> array = new Dictionary<string, string>();
            List<String> _fields = new List<String>();
            List<String> _values = new List<String>();
            IEnumerable<Control> ControlList = GetAll(panel_add_worker);
            foreach (Control p in ControlList)
            {
                if (p.GetType() == typeof(TextBox))
                {
                    if (!String.IsNullOrEmpty(p.Text))
                    {
                        _fields.Add(p.Name);
                        _values.Add("'" + p.Text + "'");
                    }
                }
                if (p.GetType() == typeof(ComboBox))
                {
                    ComboBox c = p as ComboBox;
                    if (!String.IsNullOrEmpty(p.Text))
                    {
                        _fields.Add(c.Name);
                        _values.Add("'" + c.SelectedValue.ToString() + "'");
                    }
                }
                if (p.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker c = p as DateTimePicker;
                    if (!String.IsNullOrEmpty(p.Text))
                    {
                        _fields.Add(c.Name);
                        _values.Add("'" + c.Value.ToShortDateString() + "'");
                    }
                }
            }


            array["fields"] = String.Join(",", _fields);
            array["values"] = String.Join(",", _values);

            return array;

        }
        private void add_worker()
        {

            Dictionary<string, string> array = getValuesfromfields();
            string commandText = "INSERT into workers(" + array["fields"] + ") values(" + array["values"] + ")";
            add_to_bd(commandText);
        }
        private void add_to_bd(string commandText)
        {

            SqlCommand command = new SqlCommand(commandText, con);
            try
            {
                con.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
        private void add_position()
        {
        }
        private void add_department()
        {
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
