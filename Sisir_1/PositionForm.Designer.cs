namespace Sisir_1
{
    partial class PositionForm
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
            cancel = new Button();
            ok = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 78);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.ScrollBars = ScrollBars.Horizontal;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(379, 208);
            dataGridView1.TabIndex = 22;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
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
            label1.Location = new Point(11, 10);
            label1.Name = "label1";
            label1.Size = new Size(139, 32);
            label1.TabIndex = 24;
            label1.Text = "Должности";
            // 
            // delete
            // 
            delete.Font = new Font("Segoe UI", 9F);
            delete.Location = new Point(400, 198);
            delete.Margin = new Padding(3, 2, 3, 2);
            delete.Name = "delete";
            delete.Size = new Size(90, 30);
            delete.TabIndex = 23;
            delete.Text = "Удалить";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // edit
            // 
            edit.Font = new Font("Segoe UI", 9F);
            edit.Location = new Point(400, 114);
            edit.Margin = new Padding(3, 2, 3, 2);
            edit.Name = "edit";
            edit.Size = new Size(90, 30);
            edit.TabIndex = 21;
            edit.Text = "Изменить";
            edit.UseVisualStyleBackColor = true;
            edit.Click += edit_Click;
            // 
            // add
            // 
            add.Font = new Font("Segoe UI", 9F);
            add.Location = new Point(400, 78);
            add.Margin = new Padding(3, 2, 3, 2);
            add.Name = "add";
            add.Size = new Size(90, 30);
            add.TabIndex = 20;
            add.Text = "Добавить";
            add.UseVisualStyleBackColor = true;
            add.Click += button1_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(3, 62);
            label20.Name = "label20";
            label20.Size = new Size(134, 20);
            label20.TabIndex = 16;
            label20.Text = "Заработная плата";
            // 
            // salary
            // 
            salary.Location = new Point(3, 90);
            salary.Margin = new Padding(3, 2, 3, 2);
            salary.Name = "salary";
            salary.Size = new Size(171, 27);
            salary.TabIndex = 3;
            // 
            // name
            // 
            name.Location = new Point(3, 24);
            name.Margin = new Padding(3, 2, 3, 2);
            name.Name = "name";
            name.Size = new Size(349, 27);
            name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, -4);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 0;
            label2.Text = "Наименование";
            // 
            // cancel
            // 
            cancel.Font = new Font("Segoe UI", 9F);
            cancel.Location = new Point(266, 140);
            cancel.Margin = new Padding(3, 2, 3, 2);
            cancel.Name = "cancel";
            cancel.Size = new Size(90, 30);
            cancel.TabIndex = 9;
            cancel.Text = "Отмена";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click_1;
            // 
            // ok
            // 
            ok.Font = new Font("Segoe UI", 9F);
            ok.Location = new Point(170, 140);
            ok.Margin = new Padding(3, 2, 3, 2);
            ok.Name = "ok";
            ok.Size = new Size(90, 30);
            ok.TabIndex = 8;
            ok.Text = "ОК";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(label20);
            panel1.Controls.Add(cancel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(salary);
            panel1.Controls.Add(ok);
            panel1.Controls.Add(name);
            panel1.Location = new Point(14, 58);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(379, 186);
            panel1.TabIndex = 25;
            panel1.Visible = false;
            // 
            // PositionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 316);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(delete);
            Controls.Add(edit);
            Controls.Add(add);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PositionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Справочник должностей";
            Load += PositionForm_Load;
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
        private Button cancel;
        private Button ok;
        private Label label20;
        private TextBox salary;
        private TextBox name;
        private Label label2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Panel panel1;
    }
}