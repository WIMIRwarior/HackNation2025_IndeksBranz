namespace IndeksBranz
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            StartAnalysis_Button = new Button();
            SuspendLayout();
            // 
            // StartAnalysis_Button
            // 
            StartAnalysis_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StartAnalysis_Button.Location = new Point(340, 217);
            StartAnalysis_Button.MaximumSize = new Size(123, 23);
            StartAnalysis_Button.MinimumSize = new Size(124, 23);
            StartAnalysis_Button.Name = "StartAnalysis_Button";
            StartAnalysis_Button.Size = new Size(124, 23);
            StartAnalysis_Button.TabIndex = 0;
            StartAnalysis_Button.Text = "Rozpocznij Analizę";
            StartAnalysis_Button.UseMnemonic = false;
            StartAnalysis_Button.UseVisualStyleBackColor = true;
            StartAnalysis_Button.Click += StartAnalysis_Button_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(StartAnalysis_Button);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            SizeChanged += MainForm_SizeChanged;
            ResumeLayout(false);
        }

        #endregion

        private Button StartAnalysis_Button;
    }
}