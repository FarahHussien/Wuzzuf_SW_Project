using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace swe_project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void Login_button_Click(object sender, EventArgs e)
        {
            Form2 login = new Form2();
            login.Show();
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            Form3 apply = new Form3();
            apply.Show();
        }

        private void Profile_button_Click(object sender, EventArgs e)
        {
            Form4 profile = new Form4();
            profile.Show();
        }

        private void Sign_in_Click(object sender, EventArgs e)
        {
            Form5 sign = new Form5();
            sign.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Formula c1 = new Formula();
            c1.Show();
            Form6 c2 = new Form6();
            c2.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
