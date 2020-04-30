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
        bool edit = false;
        bool add = false;
        string id_edit;
        int max_offset = 0;
        int offset = 0;
        Control activepanel;
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
         
            // dataGridViewDirectory.DataSource = bs;
            con.ConnectionString = "Data Source=CHRISTINA\\SQLEXPRESS;Database=lime;trusted_connection=true;";
           // Table_Load();
            button_edit.Enabled = false;
            dataGridViewDirectory.SelectionChanged += dataGridViewDirectory_SelectionChanged;     
            textBox_search.Text = "ФИО, номер сотрудника или email";
        }

        private void dataGridViewDirectory_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDirectory.CurrentRow != null)
                button_edit.Enabled = true;
            else
                button_edit.Enabled = false;

        }

        private void Table_Load(string param="")
        {
            switch (directory_name)
            {
                case "workers":
                    query = "Select top 20 workers.id, CONCAT_WS(' ',firstName,middleName,lastName) as 'Фамилия Имя Отчество',departments.name as 'Отдел', positions.name as 'Должность', phone as 'Телефон', email as 'email', CONCAT_WS(' ','серия '+ seriesPassport,'№'+numberPassport,'выдан '+CONVERT(varchar, whenPassport, 105),byWhomPassport) as 'Паспортные данные', registrationAddress 'Адрес регистрации' from workers left join departments on departments.id=departmentId left join positions on positions.id=positionId "+ param + "";
                    nameTable.Text = "Сотрудники";
                    activepanel = panel_add_worker;
               
                    break;
                case "positions":
                    query = "select top 20 id, name as 'Наименование' from positions";
                    nameTable.Text = "Должности";
                    activepanel = panel_pos_dep;
                    break;
                case "departments":
                    query = "select top 20 id, name as 'Наименование' from departments;";
                    nameTable.Text = "Отделы";
                    activepanel = panel_pos_dep;
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
                dtg.DataSource = table;
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
            if (textBox_search.Text == "ФИО, номер сотрудника или email") { textBox_search.Text = "";
                textBox_search.ForeColor = Color.Black;
            }
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
            activepanel.Visible = param;
            button_save.Visible = param;
            button_return.Visible = param;
            dataGridViewDirectory.Visible = !param;
            textBox_search.Enabled = !param;
            button_filtr.Enabled = !param;

            add = param;
            edit = param;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            add = true;
            gotToAdd_Edit(true);
            switch (directory_name)
            {
                case "workers":
                    nameTable.Text = "Добавление сотрудника";
                    break;
                case "positions":
                    nameTable.Text = "Добавление должности";
                    break;
                case "departments":
                    nameTable.Text = "Добавление отдела";
                    break;
            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            add_new_entity(directory_name);
            gotToAdd_Edit(false);
            Table_Load();
            clear_fields();
            
        }

        private void clear_fields()
        {

            IEnumerable<Control> ControlList = GetAll(panel_add_worker);
            foreach (Control p in ControlList)
            {
                p.ResetText();

            }

        }

        public IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateTimePicker));
        }

        private Dictionary<string, string> getValuesfromfields_forAdd()
        {
            Dictionary<string, string> array = new Dictionary<string, string>();
            List<String> _fields = new List<String>();
            List<String> _values = new List<String>();
            IEnumerable<Control> ControlList = GetAll(activepanel);
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
        private string getValuesfromfields_forEdit()
        {
            string fields_values = "";
            List<String> _fields_values = new List<String>();
            IEnumerable<Control> ControlList = GetAll(panel_add_worker);
            foreach (Control p in ControlList)
            {
                if (p.GetType() == typeof(TextBox))
                {
                    if (!String.IsNullOrEmpty(p.Text))
                    {

                        _fields_values.Add(p.Name + "='" + p.Text + "'");
                    }
                }
                if (p.GetType() == typeof(ComboBox))
                {
                    ComboBox c = p as ComboBox;
                    if (!String.IsNullOrEmpty(p.Text))
                    {

                        _fields_values.Add(p.Name + "= '" + c.SelectedValue.ToString() + "'");
                    }
                }
                if (p.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker c = p as DateTimePicker;
                    if (!String.IsNullOrEmpty(p.Text))
                    {

                        _fields_values.Add(p.Name + "= '" + c.Value.ToShortDateString() + "'");
                    }
                }
            }


            fields_values = String.Join(",", _fields_values);

            return fields_values;

        }
        private void getValuesfromBDtofields(string table)
        {
            IEnumerable<Control> ControlList = GetAll(panel_add_worker);
            string sqlExpression = "SELECT * FROM  " + table + " where id = " + id_edit + "";

            con.Open();
            SqlCommand command = new SqlCommand(sqlExpression, con);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read()) // построчно считываем данные
                {

                    foreach (Control p in ControlList)
                    {
                        if (p.GetType() == typeof(TextBox))
                        {
                            p.Text = reader[p.Name].ToString();

                        }
                        if (p.GetType() == typeof(ComboBox))
                        {
                            ComboBox c = p as ComboBox;
                            if (reader[p.Name].ToString() != "") c.SelectedValue = reader[p.Name].ToString();

                        }
                        if (p.GetType() == typeof(DateTimePicker))
                        {
                            DateTimePicker c = p as DateTimePicker;
                            //   c.Value =reader[p.Name].ToString();

                        }
                    }

                }


                reader.Close();
            }


            con.Close();


        }

        private void edit_worker()
        {

            string set_text = getValuesfromfields_forEdit();
            string commandText = "Update workers set " + set_text + " where id=" + id_edit + "";
            // label13.Text = commandText;
            add_to_bd(commandText);
        }

        private void add_new_entity(string nameTable)
        {
            Dictionary<string, string> array = getValuesfromfields_forAdd();
            string commandText = "INSERT into " + nameTable + "(" + array["fields"] + ") values(" + array["values"] + ")";
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


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dictionary<string, string> array = getValuesfromfields_forAdd();
            string commandText = "INSERT into workers(" + array["fields"] + ") values(" + array["values"] + ")";
            add_to_bd(commandText);
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            edit = true;
            gotToAdd_Edit(true);

            switch (directory_name)
            {
                case "workers":
                    nameTable.Text = "Редактирование сотрудника";
                    break;
                case "positions":
                    nameTable.Text = "Редактирование должности";
                    break;
                case "departments":
                    nameTable.Text = "Редактирование отдела";
                    break;
            }
            id_edit = dataGridViewDirectory[0, dataGridViewDirectory.CurrentRow.Index].Value.ToString();
            getValuesfromBDtofields("workers");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void nochange_Click(object sender, EventArgs e)
        {
            gotToAdd_Edit(false);
            clear_fields();
        }
        public void Delete(string id)
        {
            string sql = string.Format("Delete from " + directory_name + " where id = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
          
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("оШИбо4КА вЫШЛа", ex);
                    throw error;
                } 
                con.Close();
            }
          
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            string   id_delete = dataGridViewDirectory[0, dataGridViewDirectory.CurrentRow.Index].Value.ToString();
            int index = dataGridViewDirectory.CurrentRow.Index;
            Delete(id_delete);
            dataGridViewDirectory.Rows.RemoveAt(index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Table_Load(++offset);
           // if (offset == 0) button2.Enabled = false;
           // else button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  Table_Load(--offset);
        //    if (offset == max_offset) button1.Enabled = false;
           // else button1.Enabled = true;
        }

        private void textBox_search_MouseLeave(object sender, EventArgs e)
        {

        }

        private void textBox_search_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            string parm = textBox_search.Text;
            if (parm != "" && textBox_search.Text != "ФИО, номер сотрудника или email" && parm != " ")
            {
                string search = "where firstName like '" + parm + "%' or middleName like '" + parm + "%'  or  lastName like '" + parm + "%'   or phone  like '%" + parm + "%'  ";
                Table_Load(search);
            }
            else Table_Load();
        }

        private void textBox_search_Leave(object sender, EventArgs e)
        {
            string parm = textBox_search.Text;
            if (parm == "" || parm == " ")
            { textBox_search.Text = "ФИО, номер сотрудника или email"; textBox_search.ForeColor = Color.DarkGray; }
        }

        private void Directory_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            if (edit ==true || add ==true)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Вы не сохранили данные, выйти?", "Учет сотруднников", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Cancel the Closing event from closing the form.
                     e.Cancel = false;
                    // Call method to save file...
                } else e.Cancel = true;  
            
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           modal_open("departments");
       
        
        }
        private void modal_open(string directory_name)
        {
            Directory directory = new Directory(directory_name);
            directory.Size = new Size(800, 800);
            directory.ShowDialog();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            modal_open("positions");

        }
    }
}
