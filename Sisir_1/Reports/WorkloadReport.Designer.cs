namespace Sisir_1.Reports
{
    partial class WorkloadReport
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // title
            // 
            title.Location = new Point(9, 15);
            title.Size = new Size(328, 25);
            title.Text = "Отчет \"Загруженность сотрудников\"";
            // 
            // formReport
            // 
            formReport.Location = new Point(189, 152);
            formReport.Size = new Size(104, 25);
            // 
            // label2
            // 
            label2.Location = new Point(20, 99);
            // 
            // button1
            // 
            button1.Location = new Point(268, 116);
            button1.Size = new Size(25, 23);
            // 
            // responsible_id
            // 
            responsible_id.Location = new Point(20, 116);
            responsible_id.Size = new Size(242, 23);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 53);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 38;
            label1.Text = "Сортировка";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(20, 70);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(269, 23);
            comboBox1.TabIndex = 37;
            // 
            // WorkloadReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 215);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "WorkloadReport";
            Text = "Загруженность";
            Controls.SetChildIndex(title, 0);
            Controls.SetChildIndex(formReport, 0);
            Controls.SetChildIndex(responsible_id, 0);
            Controls.SetChildIndex(button1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(comboBox1, 0);
            Controls.SetChildIndex(label1, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label label1;
        protected ComboBox comboBox1;
    }
}