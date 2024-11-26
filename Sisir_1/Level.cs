using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisir_1
{
    public partial class Level : Form
    {
        public Level()
        {
            InitializeComponent();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            dataGridView1.Visible = false;
            submit.Enabled = false;
            edit.Enabled = false;
            delete.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            submit.Enabled = true;
            edit.Enabled = true;
            delete.Enabled = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            submit.Enabled = true;
            edit.Enabled = true;
            delete.Enabled = true;
        }
    }
}
