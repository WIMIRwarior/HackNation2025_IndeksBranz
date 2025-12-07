using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndeksBranz
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            StartAnalysis_Button.Location = new System.Drawing.Point(this.Width / 2 - StartAnalysis_Button.Width/2, this.Height / 2 - StartAnalysis_Button.Height/2);
        }

        private void StartAnalysis_Button_Click(object sender, EventArgs e)
        {
            InsertPKDNumForm InsertPKDForm = new InsertPKDNumForm();
            this.Close();
            InsertPKDForm.ShowDialog();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            StartAnalysis_Button.Location = new System.Drawing.Point(this.Width / 2 - StartAnalysis_Button.Width / 2, this.Height / 2 - StartAnalysis_Button.Height / 2);
        }
    }
}
