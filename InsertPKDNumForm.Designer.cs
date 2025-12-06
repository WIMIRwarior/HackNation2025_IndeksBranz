namespace IndeksBranz
{
    partial class InsertPKDNumForm
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
            InsertPKD_TextBox = new TextBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // InsertPKD_TextBox
            // 
            InsertPKD_TextBox.Location = new Point(47, 131);
            InsertPKD_TextBox.Name = "InsertPKD_TextBox";
            InsertPKD_TextBox.Size = new Size(162, 23);
            InsertPKD_TextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Menu;
            label1.Location = new Point(47, 113);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 1;
            label1.Text = "Wprowadź numer PKD";
            // 
            // button1
            // 
            button1.Location = new Point(134, 160);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Analizuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // InsertPKDNumForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(258, 237);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(InsertPKD_TextBox);
            MaximumSize = new Size(274, 276);
            MinimumSize = new Size(274, 276);
            Name = "InsertPKDNumForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InsertPKDNumForm";
            FormClosing += InsertPKDNumForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InsertPKD_TextBox;
        private Label label1;
        private Button button1;
    }
}