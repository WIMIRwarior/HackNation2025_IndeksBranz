using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IndeksBranz
{
    public partial class AnalysisForm : Form
    {
        private string DataFilePath = "C:\\Users\\Karol\\Desktop\\PULPIT\\C#_projects\\HackNation\\IndeksBranz\\Sources\\Data\\Dynamiki_poziomy.csv";
        private int PKD_number;

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
            Dynamika_zapasy=30
        }


        public AnalysisForm()
        {
            InitializeComponent();
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            SetupPointChart();
            LoadDataToPointChart();
            Fill_YearComboBox();
            Fill_PKDComboBoxes();
            Fill_ParamFinansowyComboBoxes();
        }


        private void SetupPointChart()
        {
            var plt = WykresPunktowy1.Plot;

            plt.Axes.Frameless();


            var fx = new ScottPlot.Plottables.FloatingAxis(plt.Axes.Bottom);
            var fy = new ScottPlot.Plottables.FloatingAxis(plt.Axes.Left);


            plt.Add.Plottable(fx);
            plt.Add.Plottable(fy);

            plt.Axes.SetLimits(-15, 15, -20, 20);

            WykresPunktowy1.Refresh();
        }

        private void LoadDataToPointChart()
        {
            if (Year_ComboBox.SelectedItem != null&&ParamFinansowy1_ComboBox.SelectedItem!=null&&
                PKD1_ComboBox.SelectedItem!=null&& PKD2_ComboBox.SelectedItem!=null)
            {
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                var lines = File.ReadAllLines(DataFilePath);

                foreach (var line in lines.Skip(1)) // pomijamy nagłówek
                {
                    var parts = line.Split(';');

                    if (parts[(int)Kategorie.Data] == Year_ComboBox.SelectedItem.ToString()&& parts[(int)Kategorie.NAZWA_PKD] == PKD1_ComboBox.SelectedItem.ToString())
                    {
                        x.Add(double.Parse(parts[2]));
                        y.Add(double.Parse(parts[3]));
                    }
                    if (parts[(int)Kategorie.Data] == Year_ComboBox.SelectedItem.ToString() && parts[(int)Kategorie.NAZWA_PKD] == PKD2_ComboBox.SelectedItem.ToString())
                    {
                        x.Add(double.Parse(parts[2]));
                        y.Add(double.Parse(parts[3]));
                    }
                }

                var scatter = WykresPunktowy1.Plot.Add.Scatter(x.ToArray(), y.ToArray());
                scatter.LineWidth = 0;  //Skasowanie lini między punktami.

                WykresPunktowy1.Plot.Axes.SetLimits(x.Max() + 1, y.Max() + 1);  //Przeskalowanie wykresu.
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
            Year_ComboBox.Items.AddRange(Years_List.Distinct().Cast<Object>().ToArray());


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
            PKD1_ComboBox.Items.AddRange(PKD_List.Distinct().Cast<Object>().ToArray());
            PKD2_ComboBox.Items.AddRange(PKD_List.Distinct().Cast<Object>().ToArray());
        }

        private void Fill_ParamFinansowyComboBoxes()
        {
            var lines = File.ReadAllLines(DataFilePath);
            List<string> Headers_List = new List<string>();
            var headers = lines[0].Split(';');
            for (int i = 3; i < headers.Length; i++)
            {
                Headers_List.Add(headers[i]);
            }

            ParamFinansowy1_ComboBox.Items.AddRange(Headers_List.Distinct().Cast<Object>().ToArray());
            ParamFinansowy2_ComboBox.Items.AddRange(Headers_List.Distinct().Cast<Object>().ToArray());
        }

        private void AktualizujWykresPunktowy_Button_Click(object sender, EventArgs e)
        {
            LoadDataToPointChart();
        }

        public void SetPKD(int PKD)
        {
            PKD_number = PKD;
        }
    }
}
