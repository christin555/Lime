using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lime
{
    public partial class skills_level : Form
    {
        public skills_level()
        {
            InitializeComponent();
        }
        public void SetLabel(string name)
        {
            label1.Text = name;
        }
        public string GetSkill
        {
            get { return comboBox1.SelectedItem ==null ?"": comboBox1.SelectedItem.ToString(); }
        }
        private void skills_level_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true; 
        }
    }
}
