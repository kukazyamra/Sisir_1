namespace Sisir_1.Reports
{
    partial class ResponsibleReport
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
            label3 = new Label();
            start_period = new DateTimePicker();
            label1 = new Label();
            end_period = new DateTimePicker();
            SuspendLayout();
            // 
            // title
            // 
            title.Size = new Size(290, 32);
            title.Text = "Отчет по ответственным";
            // 
            // formReport
            // 
            formReport.Location = new Point(213, 205);
            // 
            // label2
            // 
            label2.Location = new Point(12, 138);
            // 
            // button1
            // 
            button1.Location = new Point(322, 161);
            // 
            // responsible_id
            // 
            responsible_id.Location = new Point(12, 161);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 38;
            label3.Text = "Начало периода";
            // 
            // start_period
            // 
            start_period.Format = DateTimePickerFormat.Short;
            start_period.Location = new Point(12, 97);
            start_period.Name = "start_period";
            start_period.Size = new Size(151, 27);
            start_period.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 74);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 40;
            label1.Text = "Конец периода";
            // 
            // end_period
            // 
            end_period.Format = DateTimePickerFormat.Short;
            end_period.Location = new Point(198, 97);
            end_period.Name = "end_period";
            end_period.Size = new Size(151, 27);
            end_period.TabIndex = 39;
            // 
            // ResponsibleReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 282);
            Controls.Add(label1);
            Controls.Add(end_period);
            Controls.Add(label3);
            Controls.Add(start_period);
            Name = "ResponsibleReport";
            Text = "Отчет по ответственным";
            Controls.SetChildIndex(title, 0);
            Controls.SetChildIndex(formReport, 0);
            Controls.SetChildIndex(responsible_id, 0);
            Controls.SetChildIndex(button1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(start_period, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(end_period, 0);
            Controls.SetChildIndex(label1, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private DateTimePicker start_period;
        private Label label1;
        private DateTimePicker end_period;
    }
}