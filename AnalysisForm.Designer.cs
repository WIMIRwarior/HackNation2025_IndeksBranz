namespace IndeksBranz
{
    partial class AnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisForm));
            WykresPunktowy1 = new ScottPlot.WinForms.FormsPlot();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            Year_ComboBox = new ComboBox();
            PKD1_ComboBox = new ComboBox();
            PKD2_ComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            AktualizujWykresPunktowy_Button = new Button();
            label4 = new Label();
            ParamFinansowy1_ComboBox = new ComboBox();
            label5 = new Label();
            ParamFinansowy2_ComboBox = new ComboBox();
            SuspendLayout();
            // 
            // WykresPunktowy1
            // 
            WykresPunktowy1.DisplayScale = 1F;
            WykresPunktowy1.Location = new Point(12, 12);
            WykresPunktowy1.Name = "WykresPunktowy1";
            WykresPunktowy1.Size = new Size(912, 351);
            WykresPunktowy1.TabIndex = 0;
            // 
            // Year_ComboBox
            // 
            Year_ComboBox.FormattingEnabled = true;
            Year_ComboBox.Location = new Point(12, 499);
            Year_ComboBox.Name = "Year_ComboBox";
            Year_ComboBox.Size = new Size(121, 23);
            Year_ComboBox.TabIndex = 1;
            // 
            // PKD1_ComboBox
            // 
            PKD1_ComboBox.FormattingEnabled = true;
            PKD1_ComboBox.Location = new Point(12, 384);
            PKD1_ComboBox.Name = "PKD1_ComboBox";
            PKD1_ComboBox.Size = new Size(912, 23);
            PKD1_ComboBox.TabIndex = 2;
            // 
            // PKD2_ComboBox
            // 
            PKD2_ComboBox.FormattingEnabled = true;
            PKD2_ComboBox.Location = new Point(12, 443);
            PKD2_ComboBox.Name = "PKD2_ComboBox";
            PKD2_ComboBox.Size = new Size(912, 23);
            PKD2_ComboBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 481);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 4;
            label1.Text = "Rok";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 366);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 5;
            label2.Text = "PKD1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 425);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 6;
            label3.Text = "PKD2";
            // 
            // AktualizujWykresPunktowy_Button
            // 
            AktualizujWykresPunktowy_Button.Location = new Point(813, 499);
            AktualizujWykresPunktowy_Button.Name = "AktualizujWykresPunktowy_Button";
            AktualizujWykresPunktowy_Button.Size = new Size(111, 23);
            AktualizujWykresPunktowy_Button.TabIndex = 7;
            AktualizujWykresPunktowy_Button.Text = "Aktualizuj wykres";
            AktualizujWykresPunktowy_Button.UseVisualStyleBackColor = true;
            AktualizujWykresPunktowy_Button.Click += AktualizujWykresPunktowy_Button_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(139, 481);
            label4.Name = "label4";
            label4.Size = new Size(148, 15);
            label4.TabIndex = 9;
            label4.Text = "Parametr finansowy 1 (OX)";
            // 
            // ParamFinansowy1_ComboBox
            // 
            ParamFinansowy1_ComboBox.FormattingEnabled = true;
            ParamFinansowy1_ComboBox.Location = new Point(139, 499);
            ParamFinansowy1_ComboBox.Name = "ParamFinansowy1_ComboBox";
            ParamFinansowy1_ComboBox.Size = new Size(331, 23);
            ParamFinansowy1_ComboBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(476, 482);
            label5.Name = "label5";
            label5.Size = new Size(148, 15);
            label5.TabIndex = 11;
            label5.Text = "Parametr finansowy 2 (OY)";
            // 
            // ParamFinansowy2_ComboBox
            // 
            ParamFinansowy2_ComboBox.FormattingEnabled = true;
            ParamFinansowy2_ComboBox.Location = new Point(476, 500);
            ParamFinansowy2_ComboBox.Name = "ParamFinansowy2_ComboBox";
            ParamFinansowy2_ComboBox.Size = new Size(331, 23);
            ParamFinansowy2_ComboBox.TabIndex = 10;
            // 
            // AnalysisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1233, 528);
            Controls.Add(label5);
            Controls.Add(ParamFinansowy2_ComboBox);
            Controls.Add(label4);
            Controls.Add(ParamFinansowy1_ComboBox);
            Controls.Add(AktualizujWykresPunktowy_Button);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PKD2_ComboBox);
            Controls.Add(PKD1_ComboBox);
            Controls.Add(Year_ComboBox);
            Controls.Add(WykresPunktowy1);
            Name = "AnalysisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AnalysisForm";
            WindowState = FormWindowState.Maximized;
            Load += AnalysisForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Wykres_punktowy_1;
        private ScottPlot.WinForms.FormsPlot WykresPunktowy1;
        private ComboBox Year_ComboBox;
        private ComboBox PKD1_ComboBox;
        private ComboBox PKD2_ComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button AktualizujWykresPunktowy_Button;
        private Label label4;
        private ComboBox ParamFinansowy1_ComboBox;
        private Label label5;
        private ComboBox ParamFinansowy2_ComboBox;
    }
}