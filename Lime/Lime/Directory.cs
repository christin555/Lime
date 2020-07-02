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
        Control activepanel;
        private string level_skill;
        List<String> id_skills_for_delete = new List<String>();
        private string filter_paramsGL;

        public Directory()
        {

            InitializeComponent();
        }
        public Directory(string _directory_name , string  _filter_params = null)
        {
            con.ConnectionString = "Data Source=CHRISTINA\\SQLEXPRESS;Database=lime;trusted_connection=true;";
            con.Open();
            this.Name = "Учет сотрудников";
            directory_name = _directory_name;
            InitializeComponent();
            filter_paramsGL = _filter_params;
        }
        private void Directory_Load(object sender, EventArgs e)
        {


            Table_Load();
            button_edit.Enabled = false;
            dataGridViewDirectory.SelectionChanged += dataGridViewDirectory_SelectionChanged;
            if (directory_name == "workers") { toolStrip1.Visible = true; textBox_search.Text = "ФИО, номер сотрудника или email"; }
            else toolStrip1.Visible = false;
        }

        private void dataGridViewDirectory_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDirectory.CurrentRow != null)
                button_edit.Enabled = true;
            else
                button_edit.Enabled = false;

        }

        private void Table_Load(string param = "")
        {
   

            this.positionsTableAdapter.Fill(this.limeDataSet.positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "limeDataSet.departments". При необходимости она может быть перемещена или удалена.
            this.departmentsTableAdapter.Fill(this.limeDataSet.departments);

            switch (directory_name)
            {
                case "workers":
                    query = "Select  workers.id, CONCAT_WS(' ',TRIM( ' ' FROM  firstName) ,middleName,TRIM( ' ' FROM lastName)) as 'Фамилия Имя Отчество', dateOfBirth as 'Дата рождения', departments.name as 'Отдел', positions.name as 'Должность', phone as 'Телефон', email as 'email', CONCAT_WS(' ','серия '+ seriesPassport,'№'+numberPassport,'выдан '+CONVERT(varchar, whenPassport, 105),byWhomPassport) as 'Паспортные данные', registrationAddress 'Адрес регистрации' from workers left join departments on departments.id=departmentId left join positions on positions.id=positionId  " + param + "";
                    nameTable.Text = "Сотрудники";
                    activepanel = panel_add_worker;

                    break;
                case "positions":
                    query = "select  id, name as 'Наименование' from positions";
                    nameTable.Text = "Должности";
                    activepanel = panel_pos_dep;
                    break;
                case "departments":
                    query = "select id, name as 'Наименование' from departments;";
                    nameTable.Text = "Отделы";
                    activepanel = panel_pos_dep;
                    break;
                case "skills":
                
                    query = "select id, TRIM( ' ' FROM  name) as 'Наименование'  from skills;";
                    if (filter_paramsGL != null ) {
                     
                       query = "select id, TRIM( ' ' FROM  name) as 'Наименование'  from skills where skills.id not in ( " + filter_paramsGL + ") "; 
                    }
                
                    nameTable.Text = "Навыки";
                    activepanel = panel_pos_dep;
                    break;
                case "projects":
                    query = "select id, TRIM( ' ' FROM  projectName) as 'Наименование',startDate as 'Начало', endDate as 'Конец'  from projects;";
                    nameTable.Text = "Проекты";
                    activepanel = projects;
                    break;
            }
            LoadData(query, dataGridViewDirectory);
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
                bs.DataSource = table;
                dtg.DataSource = table;
                dtg.Columns["id"].Visible = false;
                dtg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                if (directory_name == "workers")
                {
                    if (dtg.Columns["skills"] == null)
                        dtg.Columns.Add(new DataGridViewTextBoxColumn() { Name = "skills", HeaderText = "Навыки" });
                    foreach (DataGridViewRow row in dtg.Rows)
                    {
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
                }
                if (directory_name == "projects")
                {
                    if (dtg.Columns["needs"] == null)
                        dtg.Columns.Add(new DataGridViewTextBoxColumn() { Name = "needs", HeaderText = "Требуемые навыки" });

                    if (dtg.Columns["members"] == null)
                        dtg.Columns.Add(new DataGridViewTextBoxColumn() { Name = "members", HeaderText = "Cостав команды" });

                    foreach (DataGridViewRow row in dtg.Rows)
                    {
                        string commandText = "Select TRIM( ' ' FROM  skills.name ) as name from project_needs  left join skills on skills.id = project_needs.skillId  where projectId=" + row.Cells["id"].Value + "";
                        SqlCommand command = new SqlCommand(commandText, con);
                        SqlDataReader reader = command.ExecuteReader();

                        List<String> text = new List<String>();
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // построчно считываем данные
                            {
                                if (reader["name"].ToString() != "")
                                    text.Add(reader["name"].ToString().Trim() + ";");

                            }


                        }
                        reader.Close();

                        row.Cells["needs"].Value = String.Join(Environment.NewLine, text);

                        commandText = "Select CONCAT_WS(' ',firstName,middleName,lastName, 'тел.', workers.phone) as 'name' from project_members  left join workers on workers.id = project_members.workerId  where projectId=" + row.Cells["id"].Value + "";
                        command = new SqlCommand(commandText, con);
                        reader = command.ExecuteReader();

                        List<String> workers = new List<String>();
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // построчно считываем данные
                            {
                                if (reader["name"].ToString() != "")
                                    workers.Add(reader["name"].ToString().Trim() + ";");

                            }


                        }
                        reader.Close();
                        row.Cells["members"].Value = String.Join(Environment.NewLine, workers);
                    }

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
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            if (textBox_search.Text == "ФИО, номер сотрудника или email")
            {
                textBox_search.Text = "";
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
            panel1.Visible = !panel1.Visible;
            button_add.Enabled = !param;
            button_delete.Enabled = !param;
            button_edit.Enabled = !param;
            activepanel.Visible = param;
            button_save.Visible = param;
            button_return.Visible = param;
            dataGridViewDirectory.Visible = !param;
            textBox_search.Enabled = !param;
         
            dataGridView_skills.Rows.Clear();
            dataGridView_skills.Refresh();

            dataGridView_skillForProject.Rows.Clear();
            dataGridView_skillForProject.Refresh();

            dataGridView_members.Rows.Clear();
            dataGridView_members.Refresh();
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
                case "skills":
                    nameTable.Text = "Добавление навыка";
                    break;
                case "projects":
                    nameTable.Text = "Добавление проекта";
                    break;
            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {

            if (edit) edit_worker();
            else add_new_entity(directory_name);
            add = false;
            edit = false;
            gotToAdd_Edit(false);
            Table_Load();
            clear_fields();

        }

        private void clear_fields()
        {

            IEnumerable<Control> ControlList = GetAll(activepanel);
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
            IEnumerable<Control> ControlList = GetAll(activepanel);

            foreach (Control p in ControlList)
            {
                if (p.GetType() == typeof(TextBox))
                {
                    if (!String.IsNullOrEmpty(p.Text))
                    {

                        _fields_values.Add(p.Name + "='" + p.Text.Trim(' ') + "'");
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
        private void getValuesfromBDtofields()
        {
            string table = directory_name;

            IEnumerable<Control> ControlList = GetAll(activepanel);
            string sqlExpression = "SELECT * FROM  " + table + " where id = " + id_edit + "";


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
                            p.Text = reader[p.Name].ToString().Trim(' ');

                        }
                        if (p.GetType() == typeof(ComboBox))
                        {
                            ComboBox c = p as ComboBox;
                            if (reader[p.Name].ToString() != "") c.SelectedValue = reader[p.Name].ToString();

                        }
                        if (p.GetType() == typeof(DateTimePicker))
                        {
                            DateTimePicker c = p as DateTimePicker;
                              c.Value = Convert.ToDateTime(reader[p.Name].ToString());

                        }
                    }

                }


                reader.Close();
            }


            if (directory_name == "workers")
            {
                sqlExpression = "SELECT * FROM workers_skills left join skills on skills.id = workers_skills.skillId where workerId = " + id_edit + "";

                command = new SqlCommand(sqlExpression, con);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read()) // построчно считываем данные
                    {
                        dataGridView_skills.Rows.Add(reader["skillId"], reader["name"], reader["level"]);
                    }
                }
                reader.Close();
            }

            if (directory_name == "projects")
            {
                sqlExpression = "SELECT * FROM project_needs left join skills on skills.id = project_needs.skillId where project_needs.projectId = " + id_edit + "";

                command = new SqlCommand(sqlExpression, con);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read()) // построчно считываем данные
                    {
                        dataGridView_skillForProject.Rows.Add(reader["skillId"], reader["name"]);
                    }
                }
                reader.Close();

                sqlExpression = "SELECT   workers.id, CONCAT_WS(' ', firstName, middleName, lastName, ', тел.', workers.phone) as name FROM project_members left join workers on workers.id = project_members.workerId where project_members.projectId = " + id_edit + "";

                command = new SqlCommand(sqlExpression, con);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read()) // построчно считываем данные
                    {
                        dataGridView_members.Rows.Add(reader["id"], reader["name"]);
                    }
                }
                reader.Close();

            }


        }

     

        private void edit_worker()
        {

            string set_text = getValuesfromfields_forEdit();
           
            string commandText = "Update "+ directory_name + " set " + set_text + " where id =" + id_edit + "";
         
            add_to_bd(commandText);

            if (directory_name == "workers") addOrUpdateSkill(id_edit);
            if (directory_name == "projects") addOrUpdateNeed(id_edit);
        }
        private void addOrUpdateNeed(string project_id)
        {
            string commandText;

            commandText = "delete project_members  where projectId="+ project_id +"";
            add_to_bd(commandText);

            foreach (DataGridViewRow row in dataGridView_skillForProject.Rows)
            {
                commandText = "IF (not EXISTS(select * from project_needs where projectId = " + project_id + "  and skillId = " + row.Cells["id_skill"].Value + ")) insert into project_needs values(" + project_id + "," + row.Cells["id_skill"].Value  + ")";
                add_to_bd(commandText);
            }

            foreach (DataGridViewRow row in dataGridView_members.Rows)
            {
                commandText = "IF (not EXISTS(select * from project_members where projectId = " + project_id + "  and workerId = " + row.Cells["workerId"].Value + ")) insert into project_members values(" + project_id + "," + row.Cells["workerId"].Value + ")";
                add_to_bd(commandText);
            }

            if (id_skills_for_delete.Count() > 0)
            {
                string ids = String.Join(",", id_skills_for_delete);
                string sql = string.Format("Delete from project_needs where projectId = " + project_id + " and skillId in (" + ids + ")");

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("оШИбо4КА вЫШЛа", ex);
                        throw error;
                    }

                }
                id_skills_for_delete.Clear();
            }
        }
        private void addOrUpdateSkill(string user_id)
        {
            string commandText;
            foreach (DataGridViewRow row in dataGridView_skills.Rows)
            {
                 commandText = "IF EXISTS(select * from workers_skills where workerId = " + user_id + "  and skillId = " + row.Cells["id"].Value + ") update workers_skills set level = " + row.Cells["level"].Value + " where workerId =  " + user_id + " and skillId =" + row.Cells["id"].Value + " ELSE  insert into workers_skills values(" + user_id + "," + row.Cells["id"].Value + "," + row.Cells["level"].Value + ")";
                add_to_bd(commandText);
            }
            if (id_skills_for_delete.Count() > 0)
            {
                string ids = String.Join(",", id_skills_for_delete);
                string sql = string.Format("Delete from workers_skills where workerId = " + user_id + " and skillId in (" + ids + ")");

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("оШИбо4КА вЫШЛа", ex);
                        throw error;
                    }

                }
                id_skills_for_delete.Clear();
            }
        }
        private void add_new_entity(string nameTable)
        {
            Dictionary<string, string> array = getValuesfromfields_forAdd();
            string commandText = "INSERT into " + nameTable + "(" + array["fields"] + ") values(" + array["values"] + "); SELECT SCOPE_IDENTITY();";               
            if (directory_name == "workers" || directory_name == "projects") { 
           
                string id = add_to_bd(commandText, true);
                if (directory_name == "workers") addOrUpdateSkill(id);
                else   addOrUpdateNeed(id);
            }
         
            else add_to_bd(commandText);
        }
        private string add_to_bd(string commandText, bool returnId =false)
        {
            string id=null;
            SqlCommand command = new SqlCommand(commandText, con);
            try
            {    
               if(returnId) id = command.ExecuteScalar().ToString();
                else command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
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
            id_edit = dataGridViewDirectory["id", dataGridViewDirectory.CurrentCell.RowIndex].Value.ToString();
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
                case "projects":
                    nameTable.Text = "Редактирование проекта";
                    break;
            }
          
           getValuesfromBDtofields();
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
                    cmd.ExecuteNonQuery();      
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("оШИбо4КА вЫШЛа", ex);
                    throw error;
                } 
               
            }
          
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            string   id_delete = dataGridViewDirectory["id", dataGridViewDirectory.CurrentRow.Index].Value.ToString();
            int index = dataGridViewDirectory.CurrentRow.Index;
            Delete(id_delete);
            dataGridViewDirectory.Rows.RemoveAt(index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
     
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
      
            if (edit ==true || add ==true)
            {
                if (MessageBox.Show("Вы не сохранили данные, выйти?", "Учет сотруднников", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    e.Cancel = false;    
                
                else e.Cancel = true;     
            }
        }
        public int GetId
        {
            get { return dataGridViewDirectory["id", dataGridViewDirectory.CurrentRow.Index].Value == null? 0 : Convert.ToInt32(dataGridViewDirectory["id", dataGridViewDirectory.CurrentRow.Index].Value.ToString()); }
        }
        public string GetNameSkill
        {
            get { return dataGridViewDirectory[1, dataGridViewDirectory.CurrentRow.Index].Value.ToString(); }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Directory directory = new Directory("departments");
            directory.Size = new Size(800, 800);
            directory.ShowDialog(); directory.SetPanelSize();
            int id = directory.GetId;    
            this.departmentsTableAdapter.Fill(this.limeDataSet.departments);
            departmentId.SelectedValue = id;
          
        }
        private void modal_open(string directory_name)
        {
            Directory directory = new Directory(directory_name);
            directory.Size = new Size(800, 800);
            directory.ShowDialog();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Directory directory = new Directory("positions");
            directory.Size = new Size(800, 800); directory.SetPanelSize();
            directory.ShowDialog();
            int id = directory.GetId;
            this.positionsTableAdapter.Fill(this.limeDataSet.positions);
            positionId.SelectedValue = id;

        }

        private void panel_add_worker_Paint(object sender, PaintEventArgs e)
        {

        }


        private void навыкиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            directory_name = "skills";
            Table_Load();
        }
        public void skillAddForm()
        {
         
            dataGridViewDirectory.CellDoubleClick += CellDoubleClickSkill;
           
        }
        

        public void SetPanelSize()
        {

           this.panel1.Size = new Size(500, 600);

        }

        public void skillAddForm2()
        {

            dataGridViewDirectory.CellDoubleClick += CellDoubleClickSkill2;

        }


        private void button3_Click(object sender, EventArgs e)
        {
         
            List<String> filter_pars = new List<String>();

            foreach (DataGridViewRow row in dataGridView_skills.Rows)
            {
                filter_pars.Add(row.Cells["id"].Value.ToString());
            }
            string filter_params = null;
            if (filter_pars.Count > 0) filter_params = String.Join(",", filter_pars);

            Directory directory = new Directory("skills", filter_params);
            directory.Size = new Size(800, 800);
            directory.SetPanelSize();
            directory.skillAddForm();
            directory.ShowDialog();
            int id = directory.GetId;
            string name = directory.GetNameSkill;
            string level = directory.GetSkill_level;
            int a;
            if(name!="" &&  level !=""  && int.TryParse(level,out a) ) dataGridView_skills.Rows.Add(id, name, level);
          
        }
        public string GetSkill_level
        {
            get { return level_skill; }
        }
        private void CellDoubleClickSkill(object sender, DataGridViewCellEventArgs e)
        { 
            string name = GetNameSkill; 
            skills_level skills_level = new skills_level();
            skills_level.Size = new Size(600, 150);  
            skills_level.SetLabel(name);
            skills_level.ShowDialog();
            level_skill = skills_level.GetSkill;
            this.Close();
        }
        private void CellDoubleClickSkill2(object sender, DataGridViewCellEventArgs e)
        {
         
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string id_delete = dataGridView_skills["id", dataGridView_skills.CurrentRow.Index].Value.ToString();
            int index = dataGridView_skills.CurrentRow.Index;
            id_skills_for_delete.Add(id_delete);
            dataGridView_skills.Rows.RemoveAt(index);
        }

        private void проектыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directory_name = "projects";
            Table_Load();
        }

        private void projects_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            List<String> filter_pars = new List<String>();
      
            foreach (DataGridViewRow row in dataGridView_skillForProject.Rows)
            {
                filter_pars.Add(row.Cells["id_skill"].Value.ToString());
            }
            string filter_params = null;
            if (filter_pars.Count>0)        filter_params = String.Join(",", filter_pars);

            Directory directory = new Directory("skills", filter_params);
            directory.Size = new Size(800, 800);
            directory.SetPanelSize();
            directory.skillAddForm2();
            directory.ShowDialog();
            int id = directory.GetId;
            string name = directory.GetNameSkill;
            if (name != "" ) dataGridView_skillForProject.Rows.Add(id, name);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string id_delete = dataGridView_skillForProject["id_skill", dataGridView_skillForProject.CurrentRow.Index].Value.ToString();
            int index = dataGridView_skillForProject.CurrentRow.Index;
            id_skills_for_delete.Add(id_delete);
            dataGridView_skillForProject.Rows.RemoveAt(index);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<String> filter_pars = new List<String>();
            List<String> members = new List<String>();
            string startDate_value = startDate.Value.ToShortDateString();
            string endDate_value = endDate.Value.ToShortDateString();
            foreach (DataGridViewRow row in dataGridView_members.Rows)
            {
                members.Add(row.Cells["workerId"].Value.ToString());
            }

            foreach (DataGridViewRow row in dataGridView_skillForProject.Rows)
            {
                filter_pars.Add(row.Cells["id_skill"].Value.ToString());
            }
          
            string filter_params = String.Join(",", filter_pars);

            filterWorkers directory = new filterWorkers(filter_params, members, startDate_value, endDate_value);
            directory.ShowDialog();

            Dictionary<int, string> ids= directory.GetId();

            dataGridView_members.Rows.Clear();
            dataGridView_members.Refresh();

            foreach (KeyValuePair<int, string> entry in ids)
            {
            dataGridView_members.Rows.Add( entry.Key, entry.Value);
            }
         
       
            //   if (name != "") dataGridView_members.Rows.Add(id, name);
        }

        private void dataGridView_skillForProject_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView_skillForProject.Rows.Count > 0) linkLabel3.Enabled = true; else linkLabel3.Enabled = false;
        }

        private void dataGridView_skillForProject_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView_skillForProject.Rows.Count > 0) linkLabel3.Enabled = true; else linkLabel3.Enabled = false; 
        }

        private void поВостребованнымНавыкамToolStripMenuItem_Click(object sender, EventArgs e)
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
            openReport("projects_date");
        }
    }
}
