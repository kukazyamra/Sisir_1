namespace Sisir_1
{
    partial class Position
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            delete = new Button();
            edit = new Button();
            add = new Button();
            label20 = new Label();
            salary = new TextBox();
            name = new TextBox();
            label2 = new Label();
            button5 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridView1.Location = new Point(17, 98);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.ScrollBars = ScrollBars.Horizontal;
            dataGridView1.Size = new Size(474, 260);
            dataGridView1.TabIndex = 22;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Наименование";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 200;
            // 
            // Column2
            // 
            Column2.HeaderText = "Заработная плата";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 78;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(14, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(160, 38);
            label1.TabIndex = 24;
            label1.Text = "Должности";
            // 
            // delete
            // 
            delete.Enabled = false;
            delete.Font = new Font("Segoe UI", 9F);
            delete.Location = new Point(500, 247);
            delete.Margin = new Padding(4, 3, 4, 3);
            delete.Name = "delete";
            delete.Size = new Size(113, 38);
            delete.TabIndex = 23;
            delete.Text = "Удалить";
            delete.UseVisualStyleBackColor = true;
            // 
            // edit
            // 
            edit.Enabled = false;
            edit.Font = new Font("Segoe UI", 9F);
            edit.Location = new Point(500, 143);
            edit.Margin = new Padding(4, 3, 4, 3);
            edit.Name = "edit";
            edit.Size = new Size(113, 38);
            edit.TabIndex = 21;
            edit.Text = "Изменить";
            edit.UseVisualStyleBackColor = true;
            // 
            // add
            // 
            add.Font = new Font("Segoe UI", 9F);
            add.Location = new Point(500, 98);
            add.Margin = new Padding(4, 3, 4, 3);
            add.Name = "add";
            add.Size = new Size(113, 38);
            add.TabIndex = 20;
            add.Text = "Добавить";
            add.UseVisualStyleBackColor = true;
            add.Click += button1_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(4, 78);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(156, 25);
            label20.TabIndex = 16;
            label20.Text = "Заработная плата";
            // 
            // salary
            // 
            salary.Location = new Point(4, 112);
            salary.Margin = new Padding(4, 3, 4, 3);
            salary.Name = "salary";
            salary.Size = new Size(213, 31);
            salary.TabIndex = 3;
            // 
            // name
            // 
            name.Location = new Point(4, 30);
            name.Margin = new Padding(4, 3, 4, 3);
            name.Name = "name";
            name.Size = new Size(435, 31);
            name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, -5);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 0;
            label2.Text = "Наименование";
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F);
            button5.Location = new Point(331, 192);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(113, 38);
            button5.TabIndex = 9;
            button5.Text = "Отмена";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F);
            button3.Location = new Point(213, 192);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(113, 38);
            button3.TabIndex = 8;
            button3.Text = "ОК";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(label20);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(salary);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(name);
            panel1.Location = new Point(17, 73);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 260);
            panel1.TabIndex = 25;
            panel1.Visible = false;
            // 
            // Position
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 395);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(delete);
            Controls.Add(edit);
            Controls.Add(add);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Position";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Справочник должностей";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button delete;
        private Button edit;
        private Button add;
        private Button button5;
        private Button button3;
        private Label label20;
        private TextBox salary;
        private TextBox name;
        private Label label2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Panel panel1;
    }
}