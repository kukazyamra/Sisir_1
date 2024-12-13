namespace Sisir_1.Reports
{
    partial class CurrentProjects
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
            SuspendLayout();
            // 
            // title
            // 
            title.Size = new Size(305, 32);
            title.Text = "Отчет \"Проекты в работе\"";
            // 
            // formReport
            // 
            formReport.Location = new Point(218, 147);
            // 
            // CurrentProjects
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 188);
            Name = "CurrentProjects";
            Text = "Проекты в работе";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}