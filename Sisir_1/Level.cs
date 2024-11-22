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
            groupBox1.Visible = true;
            dataGridView1.Visible = false;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dataGridView1.Visible = true;
            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dataGridView1.Visible = true;
            button1.Enabled = true;
        }
    }
}
