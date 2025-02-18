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
    public partial class Formula : Form
    {
        CrystalReport3 CR;
        public Formula()
        {
            InitializeComponent();
        }

        private void Formula_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
