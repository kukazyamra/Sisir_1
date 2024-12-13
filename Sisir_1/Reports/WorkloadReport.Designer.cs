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
            title.Size = new Size(418, 32);
            title.Text = "Отчет \"Загруженность сотрудников\"";
            // 
            // formReport
            // 
            formReport.Location = new Point(227, 201);
            // 
            // label2
            // 
            label2.Location = new Point(23, 132);
            // 
            // button1
            // 
            button1.Location = new Point(336, 154);
            // 
            // responsible_id
            // 
            responsible_id.Location = new Point(23, 155);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 71);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 38;
            label1.Text = "Сортировка";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(23, 94);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(307, 28);
            comboBox1.TabIndex = 37;
            // 
            // WorkloadReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 287);
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