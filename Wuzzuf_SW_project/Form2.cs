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
    public partial class Form2 : Form
    {
        string ordb = "Data source= orcl ; User Id= system ; Password= tiger;";
        OracleConnection conn;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                MessageBox.Show("Connected to Oracle database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to Oracle database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT COUNT(*) FROM users WHERE username = :username AND password = :password";
            cmd.Parameters.Add("username", usernameTextBox.Text);
            cmd.Parameters.Add("password", passwordTextBox.Text);
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int count = dr.GetInt32(0); // Get the value of the first column (COUNT(*))

                if (count > 0)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form3 applyForm = new Form3();    //Create the New Form Object
                    this.Hide();    //Hide the Old Form
                    applyForm.ShowDialog();    //Show the New Form
                    this.Close();    //Close the Old Form
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dr.Close();

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }


    }
}
