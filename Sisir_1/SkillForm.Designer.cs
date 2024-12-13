namespace Sisir_1
{
    partial class SkillForm
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
            label1 = new Label();
            delete = new Button();
            edit = new Button();
            add = new Button();
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
            dataGridView1.Location = new Point(15, 56);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(326, 235);
            dataGridView1.TabIndex = 28;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(10, 8);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 30;
            label1.Text = "Навыки";
            // 
            // delete
            // 
            delete.Font = new Font("Segoe UI", 9F);
            delete.Location = new Point(359, 134);
            delete.Margin = new Padding(3, 2, 3, 2);
            delete.Name = "delete";
            delete.Size = new Size(79, 22);
            delete.TabIndex = 29;
            delete.Text = "Удалить";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // edit
            // 
            edit.Font = new Font("Segoe UI", 9F);
            edit.Location = new Point(361, 82);
            edit.Margin = new Padding(3, 2, 3, 2);
            edit.Name = "edit";
            edit.Size = new Size(79, 22);
            edit.TabIndex = 27;
            edit.Text = "Изменить";
            edit.UseVisualStyleBackColor = true;
            edit.Click += edit_Click;
            // 
            // add
            // 
            add.Font = new Font("Segoe UI", 9F);
            add.Location = new Point(361, 56);
            add.Margin = new Padding(3, 2, 3, 2);
            add.Name = "add";
            add.Size = new Size(79, 22);
            add.TabIndex = 26;
            add.Text = "Добавить";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // name
            // 
            name.Location = new Point(3, 22);
            name.Margin = new Padding(3, 2, 3, 2);
            name.Name = "name";
            name.Size = new Size(319, 23);
            name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 0;
            label2.Text = "Наименование";
            // 
            // cancel
            // 
            cancel.Font = new Font("Segoe UI", 9F);
            cancel.Location = new Point(242, 99);
            cancel.Margin = new Padding(3, 2, 3, 2);
            cancel.Name = "cancel";
            cancel.Size = new Size(79, 22);
            cancel.TabIndex = 9;
            cancel.Text = "Отмена";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click_1;
            // 
            // ok
            // 
            ok.Font = new Font("Segoe UI", 9F);
            ok.Location = new Point(158, 99);
            ok.Margin = new Padding(3, 2, 3, 2);
            ok.Name = "ok";
            ok.Size = new Size(79, 22);
            ok.TabIndex = 8;
            ok.Text = "ОК";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(name);
            panel1.Controls.Add(cancel);
            panel1.Controls.Add(ok);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(15, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(328, 136);
            panel1.TabIndex = 31;
            panel1.Visible = false;
            // 
            // SkillForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 302);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(delete);
            Controls.Add(edit);
            Controls.Add(add);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SkillForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Skill";
            Load += SkillForm_Load;
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
        private TextBox name;
        private Label label2;
        private Panel panel1;
    }
}