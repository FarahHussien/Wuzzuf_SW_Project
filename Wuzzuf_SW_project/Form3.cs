using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace swe_project
{
    public partial class Form3 : Form
    {
        private string ordb = "Data source=orcl;User Id=system;Password=tiger;";
        private OracleConnection conn;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT NAME_JOB FROM JOBS";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    jobTitlesComboBox.Items.Add(dr["NAME_JOB"].ToString());
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching job titles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void jobTitlesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Get_Jops";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("JTitle", OracleDbType.Varchar2).Value = jobTitlesComboBox.SelectedItem.ToString();

                cmd.Parameters.Add("CID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    CompanytextBox.Text = dr["NAME_COMPANY"].ToString();
                    TypejobtextBox.Text = dr["TYBE_OF_JOB"].ToString();
                    LocationtextBox.Text = dr["LOCATIONS"].ToString();
                    WebsitetextBox.Text = dr["WEBSITE"].ToString();
                    SalarytextBox.Text = dr["AVG_SALARY"].ToString();
                }
                else
                {
                    MessageBox.Show("Job details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving job details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
