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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new PositionForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new LevelForm();
            form.Show();

        }
    }
}
