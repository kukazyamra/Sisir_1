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
    public partial class Position : Form
    {
        public Position()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            dataGridView1.Visible = false;
            add.Enabled = false;
            delete.Enabled = false;
            edit.Enabled = false;
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            add.Enabled = true;
            delete.Enabled = true;
            edit.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            add.Enabled = true;
            delete.Enabled = true;
            edit.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}