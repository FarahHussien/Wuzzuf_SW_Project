using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swe_project
{
    public partial class Form6 : Form
    {
        CrystalReport5 CR;

        public Form6()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport5();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jobTitle = textBox1.Text.Trim();

            CR.SetParameterValue(0, jobTitle);

            crystalReportViewer1.ReportSource = CR;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }


    }
}
