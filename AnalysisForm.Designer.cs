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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            WykresLiniowy1 = new ScottPlot.WinForms.FormsPlot();
            label6 = new Label();
            ParamFinansowy3_ComboBox = new ComboBox();
            WykresKolumnowy1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)WykresKolumnowy1).BeginInit();
            SuspendLayout();
            // 
            // WykresPunktowy1
            // 
            WykresPunktowy1.DisplayScale = 1F;
            WykresPunktowy1.Location = new Point(18, 12);
            WykresPunktowy1.Name = "WykresPunktowy1";
            WykresPunktowy1.Size = new Size(912, 837);
            WykresPunktowy1.TabIndex = 0;
            // 
            // Year_ComboBox
            // 
            Year_ComboBox.FormattingEnabled = true;
            Year_ComboBox.Location = new Point(13, 958);
            Year_ComboBox.Name = "Year_ComboBox";
            Year_ComboBox.Size = new Size(121, 23);
            Year_ComboBox.TabIndex = 1;
            // 
            // PKD1_ComboBox
            // 
            PKD1_ComboBox.FormattingEnabled = true;
            PKD1_ComboBox.Location = new Point(13, 870);
            PKD1_ComboBox.Name = "PKD1_ComboBox";
            PKD1_ComboBox.Size = new Size(912, 23);
            PKD1_ComboBox.TabIndex = 2;
            // 
            // PKD2_ComboBox
            // 
            PKD2_ComboBox.FormattingEnabled = true;
            PKD2_ComboBox.Location = new Point(13, 914);
            PKD2_ComboBox.Name = "PKD2_ComboBox";
            PKD2_ComboBox.Size = new Size(912, 23);
            PKD2_ComboBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 940);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 4;
            label1.Text = "Rok";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 852);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 5;
            label2.Text = "PKD1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 896);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 6;
            label3.Text = "PKD2";
            // 
            // AktualizujWykresPunktowy_Button
            // 
            AktualizujWykresPunktowy_Button.Location = new Point(814, 958);
            AktualizujWykresPunktowy_Button.Name = "AktualizujWykresPunktowy_Button";
            AktualizujWykresPunktowy_Button.Size = new Size(116, 23);
            AktualizujWykresPunktowy_Button.TabIndex = 7;
            AktualizujWykresPunktowy_Button.Text = "Aktualizuj wykresy";
            AktualizujWykresPunktowy_Button.UseVisualStyleBackColor = true;
            AktualizujWykresPunktowy_Button.Click += AktualizujWykresPunktowy_Button_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(140, 940);
            label4.Name = "label4";
            label4.Size = new Size(148, 15);
            label4.TabIndex = 9;
            label4.Text = "Parametr finansowy 1 (OX)";
            // 
            // ParamFinansowy1_ComboBox
            // 
            ParamFinansowy1_ComboBox.FormattingEnabled = true;
            ParamFinansowy1_ComboBox.Location = new Point(140, 958);
            ParamFinansowy1_ComboBox.Name = "ParamFinansowy1_ComboBox";
            ParamFinansowy1_ComboBox.Size = new Size(331, 23);
            ParamFinansowy1_ComboBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(477, 941);
            label5.Name = "label5";
            label5.Size = new Size(148, 15);
            label5.TabIndex = 11;
            label5.Text = "Parametr finansowy 2 (OY)";
            // 
            // ParamFinansowy2_ComboBox
            // 
            ParamFinansowy2_ComboBox.FormattingEnabled = true;
            ParamFinansowy2_ComboBox.Location = new Point(477, 959);
            ParamFinansowy2_ComboBox.Name = "ParamFinansowy2_ComboBox";
            ParamFinansowy2_ComboBox.Size = new Size(331, 23);
            ParamFinansowy2_ComboBox.TabIndex = 10;
            // 
            // WykresLiniowy1
            // 
            WykresLiniowy1.DisplayScale = 1F;
            WykresLiniowy1.Location = new Point(973, 12);
            WykresLiniowy1.Name = "WykresLiniowy1";
            WykresLiniowy1.Size = new Size(912, 502);
            WykresLiniowy1.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(973, 517);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 14;
            label6.Text = "Parametr finansowy";
            // 
            // ParamFinansowy3_ComboBox
            // 
            ParamFinansowy3_ComboBox.FormattingEnabled = true;
            ParamFinansowy3_ComboBox.Location = new Point(973, 535);
            ParamFinansowy3_ComboBox.Name = "ParamFinansowy3_ComboBox";
            ParamFinansowy3_ComboBox.Size = new Size(331, 23);
            ParamFinansowy3_ComboBox.TabIndex = 13;
            // 
            // WykresKolumnowy1
            // 
            chartArea1.Name = "ChartArea1";
            WykresKolumnowy1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            WykresKolumnowy1.Legends.Add(legend1);
            WykresKolumnowy1.Location = new Point(973, 564);
            WykresKolumnowy1.Name = "WykresKolumnowy1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series5.Legend = "Legend1";
            series5.Name = "Series5";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series6.Legend = "Legend1";
            series6.Name = "Series6";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series7.Legend = "Legend1";
            series7.Name = "Series7";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series8.Legend = "Legend1";
            series8.Name = "Series8";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series9.Legend = "Legend1";
            series9.Name = "Series9";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series10.Legend = "Legend1";
            series10.Name = "Series10";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series11.Legend = "Legend1";
            series11.Name = "Series11";
            WykresKolumnowy1.Series.Add(series1);
            WykresKolumnowy1.Series.Add(series2);
            WykresKolumnowy1.Series.Add(series3);
            WykresKolumnowy1.Series.Add(series4);
            WykresKolumnowy1.Series.Add(series5);
            WykresKolumnowy1.Series.Add(series6);
            WykresKolumnowy1.Series.Add(series7);
            WykresKolumnowy1.Series.Add(series8);
            WykresKolumnowy1.Series.Add(series9);
            WykresKolumnowy1.Series.Add(series10);
            WykresKolumnowy1.Series.Add(series11);
            WykresKolumnowy1.Size = new Size(912, 417);
            WykresKolumnowy1.TabIndex = 15;
            WykresKolumnowy1.Text = "chart1";
            // 
            // AnalysisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 993);
            Controls.Add(WykresKolumnowy1);
            Controls.Add(label6);
            Controls.Add(ParamFinansowy3_ComboBox);
            Controls.Add(WykresLiniowy1);
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
            FormClosing += AnalysisForm_FormClosing;
            Load += AnalysisForm_Load;
            ((System.ComponentModel.ISupportInitialize)WykresKolumnowy1).EndInit();
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
        private ScottPlot.WinForms.FormsPlot WykresLiniowy1;
        private Label label6;
        private ComboBox ParamFinansowy3_ComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart WykresKolumnowy1;
    }
}