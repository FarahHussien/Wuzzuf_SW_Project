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
    public partial class Form5 : Form
    {
        private string ordb = "Data Source=orcl;User Id=system;Password=tiger;";
        OracleConnection conn;

        public Form5()
        {
            InitializeComponent();
        }

        private void Registeration_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(ordb))
                {
                    conn.Open();

                    int jobId;
                    if (!int.TryParse(cmb_Job_Id.Text, out jobId))
                    {
                        MessageBox.Show("Invalid job_id selected.");
                        return;
                    }

                    // Validate the job_id against the jobs table
                    string validateJobQuery = "SELECT COUNT(*) FROM jobs WHERE job_id = :jobId";
                    using (OracleCommand validateCmd = new OracleCommand(validateJobQuery, conn))
                    {
                        validateCmd.Parameters.Add("jobId", OracleDbType.Int32).Value = jobId;

                        int jobCount = Convert.ToInt32(validateCmd.ExecuteScalar());

                        if (jobCount == 0)
                        {
                            MessageBox.Show("Selected job_id does not exist in the jobs table.");
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO users (USERNAME, PASSWORD, ID_USER, PHONE, JOPTITLE, CURRENT_CAREER_LEVEL, CATIGORY_INTERESTED_IN, JOB_ID) " +
                                         "VALUES (:USERNAME, :PASSWORD, :ID_USER, :PHONE, :JOPTITLE, :CURRENT_CAREER_LEVEL, :CATIGORY_INTERESTED_IN, :JOB_ID)";

                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("USERNAME",  txt_Name.Text);
                        cmd.Parameters.Add("PASSWORD",  txt_Password.Text);
                        cmd.Parameters.Add("ID_USER", OracleDbType.Int32).Value = Convert.ToInt32(cmb_Id.Text);
                        cmd.Parameters.Add("PHONE",  txt_Phone.Text);
                        cmd.Parameters.Add("JOPTITLE", txt_JopTitle.Text);
                        cmd.Parameters.Add("CURRENT_CAREER_LEVEL",txt_Current_Career_Level.Text);
                        cmd.Parameters.Add("CATIGORY_INTERESTED_IN",txt_Category_Interested_In.Text);
                        cmd.Parameters.Add("JOB_ID", OracleDbType.Int32).Value = jobId; // Use the validated jobId

                        int rowsInserted = cmd.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            cmb_Id.Items.Add(cmb_Id.Text);
                            cmb_Job_Id.Items.Add(cmb_Job_Id.Text);
                            MessageBox.Show("Registration Successful :D");
                        }
                        else
                        {
                            MessageBox.Show("No rows inserted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
