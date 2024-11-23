namespace Sisir_1
{
    public partial class Skill : Form
    {
        public Skill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            dataGridView1.Visible = false;
            button1.Enabled = false;
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            button1.Enabled = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            button1.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
