using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration; 


namespace RestaurantManagerSystem
{
    public partial class Login: Form
    {
        private string connectionString = "Server=WINDOWS-PC;Database=Restaurant;Trusted_Connection=True";
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           ForgotPass forgotpass = new ForgotPass();
           forgotpass.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) //I changed the name of the button to "Login_bttn" in the designer file 
        {
            string empid = UserID_txtbox.Text.Trim();// Use trim to remove all leading and trailing whitespaces
            string password = Password_txt.Text.Trim();

            if (string.IsNullOrEmpty(empid) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT A.AccID, C.EmpID,D.RoleID,D.Name,A.Password FROM Account AS A JOIN AccountData AS B ON A.AccID = B.AccID JOIN Employee AS C ON B.Empid = C.Empid JOIN VaiTro AS D ON B.Roleid = D.Roleid" +
                                " WHERE B.Empid = @empid AND A.Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@Password", password);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        //The whole If Else method here is used to check if the user exists in the database
                        if (reader.HasRows)
                        {
                            // User exists, proceed to the next form
                            MessageBox.Show("Login successful!");
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void email_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Empid FROM AccountData";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // Assuming AccID is a string, you can adjust the type as needed
                            string empid = reader["Empid"].ToString();
                            dataGridView1.Rows.Add(empid);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
}
