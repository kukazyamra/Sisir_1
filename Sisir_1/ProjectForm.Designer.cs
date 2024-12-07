namespace Sisir_1
{
    partial class ProjectForm
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
            delete = new Button();
            edit = new Button();
            add = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            team_remove = new Button();
            team_add = new Button();
            dataGridView2 = new DataGridView();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Team_Id = new DataGridViewTextBoxColumn();
            button5 = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            finish_date_fact = new DateTimePicker();
            label7 = new Label();
            start_date_fact = new DateTimePicker();
            label4 = new Label();
            start_date_plan = new DateTimePicker();
            label3 = new Label();
            description = new RichTextBox();
            label9 = new Label();
            name = new TextBox();
            label2 = new Label();
            responsible_id = new ComboBox();
            label6 = new Label();
            responsible___ = new Button();
            creation_date = new DateTimePicker();
            finish_date_plan = new DateTimePicker();
            label8 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // delete
            // 
            delete.Font = new Font("Segoe UI", 9F);
            delete.Location = new Point(834, 197);
            delete.Name = "delete";
            delete.Size = new Size(90, 29);
            delete.TabIndex = 7;
            delete.Text = "Удалить";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // edit
            // 
            edit.Font = new Font("Segoe UI", 9F);
            edit.Location = new Point(834, 109);
            edit.Name = "edit";
            edit.Size = new Size(90, 29);
            edit.TabIndex = 6;
            edit.Text = "Изменить";
            edit.UseVisualStyleBackColor = true;
            edit.Click += edit_Click;
            // 
            // add
            // 
            add.Font = new Font("Segoe UI", 9F);
            add.Location = new Point(834, 75);
            add.Name = "add";
            add.Size = new Size(90, 29);
            add.TabIndex = 5;
            add.Text = "Добавить";
            add.UseVisualStyleBackColor = true;
            add.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(21, 11);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 9;
            label1.Text = "Проекты";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 75);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(789, 456);
            dataGridView1.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(5, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 677);
            panel1.TabIndex = 11;
            panel1.Visible = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(team_remove);
            groupBox2.Controls.Add(team_add);
            groupBox2.Controls.Add(dataGridView2);
            groupBox2.Location = new Point(13, 363);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(770, 232);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Команда";
            // 
            // team_remove
            // 
            team_remove.Font = new Font("Segoe UI", 7F);
            team_remove.Location = new Point(533, 64);
            team_remove.Name = "team_remove";
            team_remove.Size = new Size(27, 29);
            team_remove.TabIndex = 23;
            team_remove.Text = "-";
            team_remove.UseVisualStyleBackColor = true;
            team_remove.Click += team_remove_Click;
            // 
            // team_add
            // 
            team_add.Font = new Font("Segoe UI", 7F);
            team_add.Location = new Point(533, 27);
            team_add.Name = "team_add";
            team_add.Size = new Size(27, 32);
            team_add.TabIndex = 22;
            team_add.Text = "+";
            team_add.UseVisualStyleBackColor = true;
            team_add.Click += team_add_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column9, Column10, Team_Id });
            dataGridView2.Location = new Point(7, 27);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(518, 188);
            dataGridView2.TabIndex = 7;
            // 
            // Column9
            // 
            Column9.HeaderText = "Сотрудник";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Width = 200;
            // 
            // Column10
            // 
            Column10.HeaderText = "Должность";
            Column10.MinimumWidth = 8;
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 220;
            // 
            // Team_Id
            // 
            Team_Id.HeaderText = "ID";
            Team_Id.MinimumWidth = 6;
            Team_Id.Name = "Team_Id";
            Team_Id.ReadOnly = true;
            Team_Id.Visible = false;
            Team_Id.Width = 125;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F);
            button5.Location = new Point(695, 616);
            button5.Name = "button5";
            button5.Size = new Size(90, 29);
            button5.TabIndex = 4;
            button5.Text = "Отмена";
            button5.UseVisualStyleBackColor = true;
            button5.Click += cancel_Click_1;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F);
            button3.Location = new Point(584, 616);
            button3.Name = "button3";
            button3.Size = new Size(90, 29);
            button3.TabIndex = 3;
            button3.Text = "ОК";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ok_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(finish_date_fact);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(start_date_fact);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(start_date_plan);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(description);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(name);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(responsible_id);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(responsible___);
            groupBox1.Controls.Add(creation_date);
            groupBox1.Controls.Add(finish_date_plan);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(13, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 347);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Основное";
            // 
            // finish_date_fact
            // 
            finish_date_fact.Format = DateTimePickerFormat.Short;
            finish_date_fact.Location = new Point(589, 293);
            finish_date_fact.Name = "finish_date_fact";
            finish_date_fact.Size = new Size(175, 27);
            finish_date_fact.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(589, 272);
            label7.Name = "label7";
            label7.Size = new Size(176, 20);
            label7.TabIndex = 31;
            label7.Text = "Дата завершения (факт)";
            // 
            // start_date_fact
            // 
            start_date_fact.Format = DateTimePickerFormat.Short;
            start_date_fact.Location = new Point(397, 293);
            start_date_fact.Name = "start_date_fact";
            start_date_fact.Size = new Size(175, 27);
            start_date_fact.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(397, 272);
            label4.Name = "label4";
            label4.Size = new Size(139, 20);
            label4.TabIndex = 29;
            label4.Text = "Дата начала (факт)";
            // 
            // start_date_plan
            // 
            start_date_plan.Format = DateTimePickerFormat.Short;
            start_date_plan.Location = new Point(7, 293);
            start_date_plan.Name = "start_date_plan";
            start_date_plan.Size = new Size(175, 27);
            start_date_plan.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 101);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 3;
            label3.Text = "Описание";
            // 
            // description
            // 
            description.Location = new Point(6, 124);
            description.Name = "description";
            description.Size = new Size(372, 120);
            description.TabIndex = 2;
            description.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 272);
            label9.Name = "label9";
            label9.Size = new Size(142, 20);
            label9.TabIndex = 27;
            label9.Text = "Дата начала (план)";
            // 
            // name
            // 
            name.Location = new Point(6, 51);
            name.Name = "name";
            name.Size = new Size(372, 27);
            name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 27);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 0;
            label2.Text = "Наименование";
            // 
            // responsible_id
            // 
            responsible_id.DropDownStyle = ComboBoxStyle.DropDownList;
            responsible_id.FormattingEnabled = true;
            responsible_id.Location = new Point(397, 51);
            responsible_id.Name = "responsible_id";
            responsible_id.Size = new Size(337, 28);
            responsible_id.TabIndex = 8;
            responsible_id.SelectedValueChanged += responsible_id_SelectedValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(397, 101);
            label6.Name = "label6";
            label6.Size = new Size(110, 20);
            label6.TabIndex = 18;
            label6.Text = "Дата создания";
            // 
            // responsible___
            // 
            responsible___.Location = new Point(741, 51);
            responsible___.Name = "responsible___";
            responsible___.Size = new Size(27, 29);
            responsible___.TabIndex = 20;
            responsible___.Text = "...";
            responsible___.UseVisualStyleBackColor = true;
            responsible___.Click += add_responsible_Click;
            // 
            // creation_date
            // 
            creation_date.Format = DateTimePickerFormat.Short;
            creation_date.Location = new Point(397, 125);
            creation_date.Name = "creation_date";
            creation_date.Size = new Size(175, 27);
            creation_date.TabIndex = 19;
            // 
            // finish_date_plan
            // 
            finish_date_plan.Format = DateTimePickerFormat.Short;
            finish_date_plan.Location = new Point(202, 293);
            finish_date_plan.Name = "finish_date_plan";
            finish_date_plan.Size = new Size(175, 27);
            finish_date_plan.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(397, 28);
            label8.Name = "label8";
            label8.Size = new Size(115, 20);
            label8.TabIndex = 19;
            label8.Text = "Ответственный";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(202, 272);
            label5.Name = "label5";
            label5.Size = new Size(179, 20);
            label5.TabIndex = 23;
            label5.Text = "Дата завершения (план)";
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 780);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(delete);
            Controls.Add(edit);
            Controls.Add(add);
            Name = "ProjectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Справочник проектов";
            Load += Project_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button delete;
        private Button edit;
        private Button add;
        private Label label1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private GroupBox groupBox2;
        private Button team_remove;
        private Button team_add;
        private DataGridView dataGridView2;
        private Button button5;
        private Button responsible___;
        private Label label8;
        public ComboBox responsible_id;
        private Button button3;
        private GroupBox groupBox1;
        private TextBox name;
        private Label label2;
        private Label label3;
        private RichTextBox description;
        private DateTimePicker creation_date;
        private Label label6;
        private DateTimePicker finish_date_plan;
        private Label label5;
        private DateTimePicker start_date_plan;
        private Label label9;
        private DateTimePicker finish_date_fact;
        private Label label7;
        private DateTimePicker start_date_fact;
        private Label label4;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Team_Id;
    }
}