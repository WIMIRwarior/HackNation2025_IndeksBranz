using ScottPlot;
using ScottPlot.Colormaps;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace IndeksBranz
{
    public partial class AnalysisForm : Form
    {
        private double plot_X_max = 0;
        private double plot_X_min = 0;
        private double plot_Y_max = 0;
        private double plot_Y_min = 0;

        private string DataFilePath = Path.Combine(Application.StartupPath, "Dynamiki_poziomy.csv");
        private string DataFilePath2 = Path.Combine(Application.StartupPath, "Indeks_branz.csv");
        private int PKD_number;
        private string PKD_NaturalLanguage = "EMPTY";

        public enum Kategorie
        {
            PKD = 0, 
            NAZWA_PKD = 1,
            Data = 2,
            Liczba_jednostek_gospodarczych = 3,
            Liczba_rentownych_jednostek_gospodarczych = 4,
            Przychody_netto = 5, 
            Zysk_netto = 6,
            Sprzedaz = 7,
            Koszty = 8,
            Odsetki = 9,
            Naklady_inwestycyjne = 10,
            Srodki_pieniezne_pap_wart = 11,
            Zobowiazania_dlugoterminowe = 12,
            Zobowiazania_krotkoterminowe =13,
            Krotko_terminowe_kredyty_bankowe=14,
            Dlugo_terminowe_kredyty_bankowe=15,
            Zapasy=16,
            Dynamika_liczba_jednostek_gospodarczych=17,
            Dynamika_liczba_rentownych_jednostek_gospodarczych=18,
            Dynamika_przychody_netto=19,
            Dynamika_zysk_netto=20,
            Dynamika_sprzedaz=21,
            Dynamika_koszty=22, 
            Dynamika_odsetki=23,
            Dynamika_naklady_inwestycyjne=24,
            Dynamika_zobowiazania_krotkoterminowe=25,
            Dynamika_zobowiazania_dlugoterminowe=26,
            Dynamika_srodki_pieniezne_pap_wart=27,
            Dynamika_krotko_terminowe_kredyty_bankowe=28,
            Dynamika_dlugo_terminowe_kredyty_bankowe=29,
            Dynamika_zapasy=30,
            Dynamika_rentownosc_sprzedazy=31
        }


        public AnalysisForm()
        {
            InitializeComponent();
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            this.Text = "Analiza dla PKD: " + PKD_number + "-" + PKD_NaturalLanguage;
            SetupPointChart();
            SetupLinearChart();
            LoadDataToPointChart();
            LoadDataToLinearChart();
            Fill_YearComboBox();
            Fill_PKDComboBoxes();
            Fill_ParamFinansowyComboBoxes();
        }


        private void SetupPointChart()
        {
            var plt = WykresPunktowy1.Plot;
            plt.Add.Legend();
            WykresPunktowy1.Plot.Legend.IsVisible = true;

            // plt.Axes.Frameless();


            var fx = new ScottPlot.Plottables.FloatingAxis(plt.Axes.Bottom);
            var fy = new ScottPlot.Plottables.FloatingAxis(plt.Axes.Left);
            //fx.Position = 0;
            //fy.Position = 0;

            plt.Add.Plottable(fx);
            plt.Add.Plottable(fy);

            //plt.Axes.AutoScale();
            WykresPunktowy1.Plot.Title("Analiza parametrów branży na tle ogółu gospodarki i dwóch wybranych branż odniesienia");

            WykresPunktowy1.Refresh();
        }

        private void LoadDataToPointChart()
        {
            
            

            WykresPunktowy1.Plot.Clear();
            SetupPointChart();
            if (Year_ComboBox.SelectedItem != null&&ParamFinansowy1_ComboBox.SelectedItem!=null&&
                PKD1_ComboBox.SelectedItem!=null&& PKD2_ComboBox.SelectedItem!=null)
            {

                WykresPunktowy1.Plot.XLabel(ParamFinansowy1_ComboBox.SelectedItem.ToString().Trim('"')+"[%]");
                WykresPunktowy1.Plot.YLabel(ParamFinansowy2_ComboBox.SelectedItem.ToString().Trim('"') + "[%]");

                List<double> PKD1_x = new List<double>();
                List<double> PKD1_y = new List<double>();
                List<double> PKD2_x = new List<double>();
                List<double> PKD2_y = new List<double>();
                List<double> USER_PKD_x = new List<double>();
                List<double> USER_PKD_y = new List<double>();
                List<double> OGOL_x = new List<double>();
                List<double> OGOL_y = new List<double>();
                var lines = File.ReadAllLines(DataFilePath);

                foreach (var line in lines.Skip(1)) // pomijamy nagłówek
                {
                    var parts = line.Split(';');

                    if (parts[(int)Kategorie.Data] == Year_ComboBox.SelectedItem.ToString()&& parts[(int)Kategorie.NAZWA_PKD] == PKD1_ComboBox.SelectedItem.ToString())
                    {
                        PKD1_x.Add(double.Parse(parts[ParamFinansowy1_ComboBox.SelectedIndex+17]));
                        PKD1_y.Add(double.Parse(parts[ParamFinansowy2_ComboBox.SelectedIndex + 17]));
                        plot_X_max = PKD1_x[0];
                        plot_X_min = PKD1_x[0];
                        plot_Y_max = PKD1_y[0];
                        plot_Y_min = PKD1_y[0];

                    }
                    if (parts[(int)Kategorie.Data] == Year_ComboBox.SelectedItem.ToString() && parts[(int)Kategorie.NAZWA_PKD] == PKD2_ComboBox.SelectedItem.ToString())
                    {
                        PKD2_x.Add(double.Parse(parts[ParamFinansowy1_ComboBox.SelectedIndex + 17]));
                        PKD2_y.Add(double.Parse(parts[ParamFinansowy2_ComboBox.SelectedIndex + 17]));

                        if(PKD2_x[0] > plot_X_max)
                        {
                            plot_X_max = PKD2_x[0];
                        }
                        if (PKD2_x[0]<plot_X_min)
                        {
                            plot_X_min=PKD2_x[0];
                        }
                        if (PKD2_y[0] > plot_Y_max)
                        {
                            plot_Y_max = PKD2_y[0];
                        }
                        if (PKD2_y[0] < plot_Y_min)
                        {
                            plot_Y_min = PKD2_y[0];
                        }

                    }
                    if (parts[(int)Kategorie.Data] == Year_ComboBox.SelectedItem.ToString() && parts[(int)Kategorie.NAZWA_PKD].Trim('"') == "OGOLEM")
                    {
                        OGOL_x.Add(double.Parse(parts[ParamFinansowy1_ComboBox.SelectedIndex + 17]));
                        OGOL_y.Add(double.Parse(parts[ParamFinansowy2_ComboBox.SelectedIndex + 17]));
                        if (OGOL_x[0] > plot_X_max)
                        {
                            plot_X_max = OGOL_x[0];
                        }
                        if (OGOL_x[0] < plot_X_min)
                        {
                            plot_X_min = OGOL_x[0];
                        }
                        if (OGOL_y[0] > plot_Y_max)
                        {
                            plot_Y_max =OGOL_y[0];
                        }
                        if (OGOL_y[0] < plot_Y_min)
                        {
                            plot_Y_min = OGOL_y[0];
                        }
                    }
                    if (parts[(int)Kategorie.Data] == Year_ComboBox.SelectedItem.ToString() && parts[(int)Kategorie.NAZWA_PKD] == PKD_NaturalLanguage)
                    {
                        USER_PKD_x.Add(double.Parse(parts[ParamFinansowy1_ComboBox.SelectedIndex + 17]));
                        USER_PKD_y.Add(double.Parse(parts[ParamFinansowy2_ComboBox.SelectedIndex + 17]));
                        if (USER_PKD_x[0] > plot_X_max)
                        {
                            plot_X_max = USER_PKD_x[0];
                        }
                        if (USER_PKD_x[0] < plot_X_min)
                        {
                            plot_X_min = USER_PKD_x[0];
                        }
                        if (USER_PKD_y[0] > plot_Y_max)
                        {
                            plot_Y_max = USER_PKD_y[0];
                        }
                        if (USER_PKD_y[0] < plot_Y_min)
                        {
                            plot_Y_min = USER_PKD_y[0];
                        }
                    }
                }

                var scatterPKD1 = WykresPunktowy1.Plot.Add.Scatter(PKD1_x.ToArray(), PKD1_y.ToArray());
                scatterPKD1.LineWidth = 0;  //Skasowanie lini między punktami.
                scatterPKD1.LegendText = PKD1_ComboBox.SelectedItem.ToString().Trim('"');
                scatterPKD1.MarkerShape = ScottPlot.MarkerShape.FilledDiamond;
                scatterPKD1.MarkerSize = 15;

                var scatterPKD2 = WykresPunktowy1.Plot.Add.Scatter(PKD2_x.ToArray(), PKD2_y.ToArray());
                scatterPKD2.LineWidth = 0;
                scatterPKD2.LegendText = PKD2_ComboBox.SelectedItem.ToString().Trim('"');
                scatterPKD2.MarkerShape = ScottPlot.MarkerShape.FilledSquare;
                scatterPKD2.MarkerSize = 15;

                var scatterUSER_PKD = WykresPunktowy1.Plot.Add.Scatter(USER_PKD_x.ToArray(), USER_PKD_y.ToArray());
                scatterUSER_PKD.LineWidth = 0;
                scatterUSER_PKD.LegendText = PKD_NaturalLanguage.Trim('"');
                scatterUSER_PKD.MarkerShape = ScottPlot.MarkerShape.FilledTriangleUp;
                scatterUSER_PKD.MarkerSize = 15;

                var scatterOGOL = WykresPunktowy1.Plot.Add.Scatter(OGOL_x.ToArray(), OGOL_y.ToArray());
                scatterOGOL.LineWidth = 0;
                scatterOGOL.LegendText = "Ogół gospodarki";
                scatterOGOL.MarkerShape = ScottPlot.MarkerShape.FilledCircle;
                scatterOGOL.MarkerSize = 15;

                double absX = Math.Abs(plot_X_max) + Math.Abs(plot_X_min);
                double absY = Math.Abs(plot_Y_max) + Math.Abs(plot_Y_min);


                WykresPunktowy1.Plot.Axes.SetLimits(-100,100, -100,100);  //Przeskalowanie wykresu.

                WykresPunktowy1.Plot.Axes.AutoScale();


                WykresPunktowy1.Refresh();


            }
        }

        private void Fill_YearComboBox()
        {
            var lines = File.ReadAllLines(DataFilePath);
            List<string> Years_List = new List<string>();
            foreach (var line in lines.Skip(1)) // pomijamy nagłówek
            {
                var parts = line.Split(';');
                Years_List.Add(parts[(int)Kategorie.Data]);

            }
            Year_ComboBox.Items.AddRange(Years_List.Distinct().ToArray());


        }

        private void Fill_PKDComboBoxes()
        {
            var lines = File.ReadAllLines(DataFilePath);
            List<string> PKD_List = new List<string>();
            foreach (var line in lines.Skip(1)) // pomijamy nagłówek
            {
                var parts = line.Split(';');
                PKD_List.Add(parts[(int)Kategorie.NAZWA_PKD]);
            }
            PKD1_ComboBox.Items.AddRange(PKD_List.Distinct().ToArray());
            PKD2_ComboBox.Items.AddRange(PKD_List.Distinct().ToArray());
        }

        private void Fill_ParamFinansowyComboBoxes()
        {
            var lines = File.ReadAllLines(DataFilePath);
            List<string> Dynamiki_Headers_List = new List<string>();
            List<string> Headers_List = new List<string>();
            var headers = lines[0].Split(';');
            string pattern = "Dynamika.*";

            for (int i = 3; i < headers.Length; i++)
            {
                if (Regex.IsMatch(headers[i].Trim('"'), pattern))
                { 
                    Dynamiki_Headers_List.Add(headers[i]);
                }
                else
                {
                    Headers_List.Add(headers[i]);
                }
            }

            ParamFinansowy1_ComboBox.Items.AddRange(Dynamiki_Headers_List.Distinct().ToArray());
            ParamFinansowy2_ComboBox.Items.AddRange(Dynamiki_Headers_List.Distinct().ToArray());
            ParamFinansowy3_ComboBox.Items.AddRange(Headers_List.Distinct().ToArray());
        }

        private void AktualizujWykresPunktowy_Button_Click(object sender, EventArgs e)
        {
            LoadDataToPointChart();
            LoadDataToLinearChart();
            InsertDataToColumnChart();
        }

        public void SetPKD(int PKD)
        {
            PKD_number = PKD;
            SetPKD_NaturalLanguage(PKD);
        }

        public void SetPKD_NaturalLanguage(int PKD)
        {
            MessageBox.Show(PKD.ToString());
            var lines = File.ReadAllLines(DataFilePath);
            List<string> Years_List = new List<string>();
            foreach (var line in lines.Skip(1))
            {

                var parts = line.Split(';');
                if (parts[0].Trim('"')==PKD.ToString())
                {
                    PKD_NaturalLanguage = parts[1];
                    MessageBox.Show(PKD_NaturalLanguage);
                    break;
                }
            }
        }

        public void SetupLinearChart()
        {
            var plt = WykresLiniowy1.Plot;
            plt.Add.Legend();

            WykresLiniowy1.Plot.Legend.IsVisible = true;

            WykresLiniowy1.Plot.Title("Szereg czasowy wybranego parametru finansowego w odniesieniu do wybranych branż i krajowej gospodarki.");

            WykresLiniowy1.Refresh();
        }

        private void LoadDataToLinearChart()
        {



            WykresLiniowy1.Plot.Clear();
            SetupLinearChart();
            if (ParamFinansowy3_ComboBox.SelectedItem != null && PKD1_ComboBox.SelectedItem != null 
                && PKD2_ComboBox.SelectedItem != null)
            {
                string patern = ".*Liczba.*";
                WykresLiniowy1.Plot.XLabel("Rok");
                if (Regex.IsMatch(ParamFinansowy3_ComboBox.SelectedItem.ToString().Trim('"'), patern))
                {
                    WykresLiniowy1.Plot.YLabel(ParamFinansowy3_ComboBox.SelectedItem.ToString().Trim('"') + "[szt]");
                }
                else
                {
                    WykresLiniowy1.Plot.YLabel(ParamFinansowy3_ComboBox.SelectedItem.ToString().Trim('"') + "[mln PLN]");
                }

                List<double> PKD1_x = new List<double>();
                List<double> PKD1_y = new List<double>();
                List<double> PKD2_x = new List<double>();
                List<double> PKD2_y = new List<double>();
                List<double> USER_PKD_x = new List<double>();
                List<double> USER_PKD_y = new List<double>();
                List<double> OGOL_x = new List<double>();
                List<double> OGOL_y = new List<double>();
                var lines = File.ReadAllLines(DataFilePath);

                foreach (var line in lines.Skip(1)) // pomijamy nagłówek
                {
                    var parts = line.Split(';');

                    if (parts[(int)Kategorie.NAZWA_PKD] == PKD1_ComboBox.SelectedItem.ToString())
                    {
                        PKD1_x.Add(double.Parse(parts[(int)Kategorie.Data].Trim('"')));
                        PKD1_y.Add(double.Parse(parts[ParamFinansowy3_ComboBox.SelectedIndex + 17]));
                    }
                    if (parts[(int)Kategorie.NAZWA_PKD] == PKD2_ComboBox.SelectedItem.ToString())
                    {
                        PKD2_x.Add(double.Parse(parts[(int)Kategorie.Data].Trim('"')));
                        PKD2_y.Add(double.Parse(parts[ParamFinansowy3_ComboBox.SelectedIndex + 17]));
                    }
                    if (parts[(int)Kategorie.NAZWA_PKD].Trim('"') == "OGOLEM")
                    {
                        OGOL_x.Add(double.Parse(parts[(int)Kategorie.Data].Trim('"')));
                        OGOL_y.Add(double.Parse(parts[ParamFinansowy3_ComboBox.SelectedIndex + 17]));
                    }
                    if (parts[(int)Kategorie.NAZWA_PKD] == PKD_NaturalLanguage)
                    {
                        USER_PKD_x.Add(double.Parse(parts[(int)Kategorie.Data].Trim('"')));
                        USER_PKD_y.Add(double.Parse(parts[ParamFinansowy3_ComboBox.SelectedIndex + 17]));
                    }
                }

                var scatterPKD1 = WykresLiniowy1.Plot.Add.Scatter(PKD1_x.ToArray(), PKD1_y.ToArray());
                scatterPKD1.LineWidth = 3;  //Skasowanie lini między punktami.
                scatterPKD1.LegendText = PKD1_ComboBox.SelectedItem.ToString().Trim('"');
                scatterPKD1.MarkerShape = ScottPlot.MarkerShape.Asterisk;
                scatterPKD1.MarkerSize = 7;

                var scatterPKD2 = WykresLiniowy1.Plot.Add.Scatter(PKD2_x.ToArray(), PKD2_y.ToArray());
                scatterPKD2.LineWidth = 3;
                scatterPKD2.LegendText = PKD2_ComboBox.SelectedItem.ToString().Trim('"');
                scatterPKD2.MarkerShape = ScottPlot.MarkerShape.Cross;
                scatterPKD2.MarkerSize = 7;

                var scatterUSER_PKD = WykresLiniowy1.Plot.Add.Scatter(USER_PKD_x.ToArray(), USER_PKD_y.ToArray());
                scatterUSER_PKD.LineWidth = 3;
                scatterUSER_PKD.LegendText = PKD_NaturalLanguage.Trim('"');
                scatterUSER_PKD.MarkerShape = ScottPlot.MarkerShape.FilledTriangleUp;
                scatterUSER_PKD.MarkerSize = 7;

                var scatterOGOL = WykresLiniowy1.Plot.Add.Scatter(OGOL_x.ToArray(), OGOL_y.ToArray());
                scatterOGOL.LineWidth = 3;
                scatterOGOL.LegendText = "Ogół gospodarki";
                scatterOGOL.MarkerShape = ScottPlot.MarkerShape.FilledCircle;
                scatterOGOL.MarkerSize = 7;

                double absX = Math.Abs(plot_X_max) + Math.Abs(plot_X_min);
                double absY = Math.Abs(plot_Y_max) + Math.Abs(plot_Y_min);


                // utworzenie manualnego generatora ticków
                var ticks = new ScottPlot.TickGenerators.NumericManual();

                for (int i = 0; i < OGOL_x.Count(); i++)
                {
                    ticks.AddMajor(OGOL_x[i], OGOL_x[i].ToString());
                }

                // przypisanie generatora ticków do osi poziomej
                WykresLiniowy1.Plot.Axes.Bottom.TickGenerator = ticks;

                WykresLiniowy1.Plot.Axes.AutoScale();


                WykresLiniowy1.Refresh();


            }
        }

        public void SetupColumnChart()
        {
        }

        public void InsertDataToColumnChart()
        {
            WykresKolumnowy1.Series.Clear();


            




            if (PKD_NaturalLanguage!=null && PKD1_ComboBox.SelectedItem!=null && PKD2_ComboBox.SelectedItem!=null)
            {
                WykresKolumnowy1.Series.Clear();
                WykresKolumnowy1.Titles.Add("Suma punktów");
                var lines = File.ReadAllLines(DataFilePath2);
                double[] xs = { 1, 2, 3 }; // kategorie lub indeksy słupków
                string[] categories = { PKD_NaturalLanguage, PKD1_ComboBox.SelectedItem.ToString().Trim('"'), PKD2_ComboBox.SelectedItem.ToString().Trim('"') };
                
                var part = lines[0].Split(';');

                Series s1 = WykresKolumnowy1.Series.Add(part[31].Trim('"'));
               
                s1.ChartType = SeriesChartType.StackedColumn;


                WykresKolumnowy1.ChartAreas[0].AxisX.CustomLabels.Add(-1, 1, "Analizowane\nPKD");
                WykresKolumnowy1.ChartAreas[0].AxisX.CustomLabels.Add(1, 1.2, "PKD1");
                WykresKolumnowy1.ChartAreas[0].AxisX.CustomLabels.Add(1.2, 2.5, "PKD2");


                foreach (var line in lines.Skip(1))
                {

                    var parts = line.Split(';');
                    if (parts[0].Trim('"') == PKD_NaturalLanguage.Trim('"'))
                    {
                        MessageBox.Show("1 if");
                        s1.Points.AddXY(0, double.Parse(parts[31].Trim('"')));
                        

                    }

                    if (parts[0].Trim('"') == PKD1_ComboBox.SelectedItem.ToString().Trim('"'))
                    {
                        
                        s1.Points.AddXY(1, double.Parse(parts[31].Trim('"')));
                        
                    }

                    if (parts[0].Trim('"') == PKD2_ComboBox.SelectedItem.ToString().Trim('"'))
                    {

                        s1.Points.AddXY(2, double.Parse(parts[31].Trim('"')));
                        

                    }



                }

                
            }
        }



    }
}
