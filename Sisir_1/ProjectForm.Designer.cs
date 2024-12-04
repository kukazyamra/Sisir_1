﻿namespace Sisir_1
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
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            button9 = new Button();
            button8 = new Button();
            dataGridView2 = new DataGridView();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            button5 = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            start_date_plan = new DateTimePicker();
            label3 = new Label();
            description = new RichTextBox();
            label9 = new Label();
            name = new TextBox();
            label2 = new Label();
            responsible_id = new ComboBox();
            label6 = new Label();
            button6 = new Button();
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
            delete.Location = new Point(834, 198);
            delete.Margin = new Padding(3, 2, 3, 2);
            delete.Name = "delete";
            delete.Size = new Size(90, 30);
            delete.TabIndex = 7;
            delete.Text = "Удалить";
            delete.UseVisualStyleBackColor = true;
            // 
            // edit
            // 
            edit.Font = new Font("Segoe UI", 9F);
            edit.Location = new Point(834, 110);
            edit.Margin = new Padding(3, 2, 3, 2);
            edit.Name = "edit";
            edit.Size = new Size(90, 30);
            edit.TabIndex = 6;
            edit.Text = "Изменить";
            edit.UseVisualStyleBackColor = true;
            // 
            // add
            // 
            add.Font = new Font("Segoe UI", 9F);
            add.Location = new Point(834, 74);
            add.Margin = new Padding(3, 2, 3, 2);
            add.Name = "add";
            add.Size = new Size(90, 30);
            add.TabIndex = 5;
            add.Text = "Добавить";
            add.UseVisualStyleBackColor = true;
            add.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(21, 10);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 9;
            label1.Text = "Проекты";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8 });
            dataGridView1.Location = new Point(14, 74);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(789, 456);
            dataGridView1.TabIndex = 10;
            dataGridView1.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            // 
            // Column1
            // 
            Column1.HeaderText = "Наименование";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Описание";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 250;
            // 
            // Column3
            // 
            Column3.HeaderText = "Дата создания";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 95;
            // 
            // Column4
            // 
            Column4.HeaderText = "Дата начала (план)";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 95;
            // 
            // Column5
            // 
            Column5.HeaderText = "Дата начала (факт)";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 95;
            // 
            // Column6
            // 
            Column6.HeaderText = "Дата завершения (план)";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 95;
            // 
            // Column7
            // 
            Column7.HeaderText = "Дата завершения (план)";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 95;
            // 
            // Column8
            // 
            Column8.HeaderText = "Ответственный";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 150;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(14, 54);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 678);
            panel1.TabIndex = 11;
            panel1.Visible = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button9);
            groupBox2.Controls.Add(button8);
            groupBox2.Controls.Add(dataGridView2);
            groupBox2.Location = new Point(13, 362);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(770, 232);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Команда";
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 7F);
            button9.Location = new Point(532, 64);
            button9.Margin = new Padding(3, 2, 3, 2);
            button9.Name = "button9";
            button9.Size = new Size(27, 30);
            button9.TabIndex = 23;
            button9.Text = "-";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 7F);
            button8.Location = new Point(532, 26);
            button8.Margin = new Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new Size(27, 32);
            button8.TabIndex = 22;
            button8.Text = "+";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column9, Column10 });
            dataGridView2.Location = new Point(7, 26);
            dataGridView2.Margin = new Padding(3, 2, 3, 2);
            dataGridView2.Name = "dataGridView2";
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
            Column9.Width = 377;
            // 
            // Column10
            // 
            Column10.HeaderText = "Должность";
            Column10.MinimumWidth = 8;
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 220;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F);
            button5.Location = new Point(695, 616);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(90, 30);
            button5.TabIndex = 4;
            button5.Text = "Отмена";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F);
            button3.Location = new Point(584, 616);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(90, 30);
            button3.TabIndex = 3;
            button3.Text = "ОК";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(start_date_plan);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(description);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(name);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(responsible_id);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(creation_date);
            groupBox1.Controls.Add(finish_date_plan);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(13, 10);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(776, 346);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Основное";
            // 
            // start_date_plan
            // 
            start_date_plan.Format = DateTimePickerFormat.Short;
            start_date_plan.Location = new Point(7, 294);
            start_date_plan.Margin = new Padding(3, 2, 3, 2);
            start_date_plan.Name = "start_date_plan";
            start_date_plan.Size = new Size(175, 27);
            start_date_plan.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 102);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 3;
            label3.Text = "Описание";
            // 
            // description
            // 
            description.Location = new Point(6, 124);
            description.Margin = new Padding(3, 2, 3, 2);
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
            name.Location = new Point(6, 50);
            name.Margin = new Padding(3, 2, 3, 2);
            name.Name = "name";
            name.Size = new Size(372, 27);
            name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 26);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 0;
            label2.Text = "Наименование";
            // 
            // responsible_id
            // 
            responsible_id.FormattingEnabled = true;
            responsible_id.Location = new Point(397, 50);
            responsible_id.Margin = new Padding(3, 2, 3, 2);
            responsible_id.Name = "responsible_id";
            responsible_id.Size = new Size(337, 28);
            responsible_id.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(397, 102);
            label6.Name = "label6";
            label6.Size = new Size(110, 20);
            label6.TabIndex = 18;
            label6.Text = "Дата создания";
            // 
            // button6
            // 
            button6.Location = new Point(741, 50);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(27, 30);
            button6.TabIndex = 20;
            button6.Text = "...";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // creation_date
            // 
            creation_date.Format = DateTimePickerFormat.Short;
            creation_date.Location = new Point(397, 126);
            creation_date.Margin = new Padding(3, 2, 3, 2);
            creation_date.Name = "creation_date";
            creation_date.Size = new Size(175, 27);
            creation_date.TabIndex = 19;
            // 
            // finish_date_plan
            // 
            finish_date_plan.Format = DateTimePickerFormat.Short;
            finish_date_plan.Location = new Point(202, 294);
            finish_date_plan.Margin = new Padding(3, 2, 3, 2);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private Button button9;
        private Button button8;
        private DataGridView dataGridView2;
        private Button button5;
        private Button button6;
        private Label label8;
        private ComboBox responsible_id;
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
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
    }
}