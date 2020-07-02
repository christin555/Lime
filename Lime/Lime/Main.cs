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
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

       

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDirectory("workers");
        
        }

        private void другоеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDirectory("departments");
          
        }
        private void openDirectory(string name)
        { 
            this.Hide();
            Directory directory = new Directory(name);
            directory.FormClosed += (object s, FormClosedEventArgs ev) => { this.Show(); };
            directory.Show();
          
        }
        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDirectory("positions");
         
        }

        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void навыкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDirectory("skills");
        }

        private void проектыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDirectory("projects");
        }
    }
}
