namespace Sisir_1
{
    partial class Skill_level
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
            textBox1 = new TextBox();
            ok = new Button();
            cancel = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 60);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 0;
            label1.Text = "Уровень владения";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 27);
            textBox1.TabIndex = 1;
            // 
            // ok
            // 
            ok.Location = new Point(24, 146);
            ok.Name = "ok";
            ok.Size = new Size(94, 29);
            ok.TabIndex = 2;
            ok.Text = "ОК";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(137, 146);
            cancel.Name = "cancel";
            cancel.Size = new Size(94, 29);
            cancel.TabIndex = 3;
            cancel.Text = "Отмена";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(238, 32);
            label2.TabIndex = 19;
            label2.Text = "Добавление навыка";
            // 
            // Skill_level
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 192);
            Controls.Add(label2);
            Controls.Add(cancel);
            Controls.Add(ok);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Skill_level";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Skill_level";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button ok;
        private Button cancel;
        private Label label2;
    }
}