namespace Sisir_1
{
    partial class Skill
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
            label1 = new Label();
            delete = new Button();
            edit = new Button();
            add = new Button();
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridView1.Location = new Point(17, 97);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.ScrollBars = ScrollBars.Horizontal;
            dataGridView1.Size = new Size(466, 363);
            dataGridView1.TabIndex = 28;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Наименование";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 250;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(14, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(116, 38);
            label1.TabIndex = 30;
            label1.Text = "Навыки";
            // 
            // delete
            // 
            delete.Enabled = false;
            delete.Font = new Font("Segoe UI", 9F);
            delete.Location = new Point(513, 222);
            delete.Margin = new Padding(4, 3, 4, 3);
            delete.Name = "delete";
            delete.Size = new Size(113, 38);
            delete.TabIndex = 29;
            delete.Text = "Удалить";
            delete.UseVisualStyleBackColor = true;
            // 
            // edit
            // 
            edit.Enabled = false;
            edit.Font = new Font("Segoe UI", 9F);
            edit.Location = new Point(516, 138);
            edit.Margin = new Padding(4, 3, 4, 3);
            edit.Name = "edit";
            edit.Size = new Size(113, 38);
            edit.TabIndex = 27;
            edit.Text = "Изменить";
            edit.UseVisualStyleBackColor = true;
            // 
            // add
            // 
            add.Font = new Font("Segoe UI", 9F);
            add.Location = new Point(516, 93);
            add.Margin = new Padding(4, 3, 4, 3);
            add.Name = "add";
            add.Size = new Size(113, 38);
            add.TabIndex = 26;
            add.Text = "Добавить";
            add.UseVisualStyleBackColor = true;
            add.Click += button1_Click;
            // 
            // name
            // 
            name.Location = new Point(4, 37);
            name.Margin = new Padding(4, 3, 4, 3);
            name.Name = "name";
            name.Size = new Size(454, 31);
            name.TabIndex = 1;
            name.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 0;
            label2.Text = "Наименование";
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F);
            button5.Location = new Point(351, 163);
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
            button3.Location = new Point(230, 163);
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
            panel1.Controls.Add(name);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(17, 58);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 228);
            panel1.TabIndex = 31;
            panel1.Visible = false;
            // 
            // Skill
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 508);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(delete);
            Controls.Add(edit);
            Controls.Add(add);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Skill";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Skill";
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
        private TextBox name;
        private Label label2;
        private DataGridViewTextBoxColumn Column1;
        private Panel panel1;
    }
}