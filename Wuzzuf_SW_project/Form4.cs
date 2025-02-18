using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace swe_project
{
    public partial class Form4 : Form
    {
        OracleDataAdapter adaptor;
        DataSet ds;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data source = orcl ; user id = system; password = tiger;";
            string select_statement = "select * from users where username =: name and password =: p";
            adaptor = new OracleDataAdapter(select_statement, constr);
            adaptor.SelectCommand.Parameters.Add("name", textBox1.Text.ToString());
            adaptor.SelectCommand.Parameters.Add("p", textBox2.Text.ToString());
            ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommandBuilder builder = new OracleCommandBuilder(adaptor);
            adaptor.Update(ds.Tables[0]);
            MessageBox.Show("Database updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
