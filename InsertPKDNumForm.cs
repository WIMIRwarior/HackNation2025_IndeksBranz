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
    public partial class InsertPKDNumForm : Form
    {
        public int PKD_number=0;

        public InsertPKDNumForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InsertPKD_TextBox.Text != null)
            {
                PKD_number = int.Parse(InsertPKD_TextBox.Text);

                AnalysisForm analysisForm = new AnalysisForm();
                analysisForm.SetPKD(PKD_number);
                this.Close();
                analysisForm.Show();
            }
        }

        private void InsertPKDNumForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
