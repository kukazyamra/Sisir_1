namespace Sisir_1
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            dataGridView1.Visible = false;
            add.Enabled = false;
            edit.Enabled = false;
            delete.Enabled = false;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            add.Enabled = true;
            edit.Enabled = true;
            delete.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            add.Enabled = true;
            edit.Enabled = true;
            delete.Enabled = true;
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void Employee_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new Position();
            form.Show();
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            var form = new Level();
            form.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var form = new Skill();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
