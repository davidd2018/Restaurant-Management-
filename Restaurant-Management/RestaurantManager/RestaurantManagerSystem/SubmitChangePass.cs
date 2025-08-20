using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerSystem
{
    public partial class SubmitChangePass: Form
    {
        private Dictionary<string, string> value;

        public SubmitChangePass()
        {
            InitializeComponent();

        }
        public SubmitChangePass(Dictionary<string, string> value) : this()
        {
            this.value = value;
        }

        private void SubmitChangePass_Load(object sender, EventArgs e)
        {
            empid_txtbox.Text = value["EmpID"];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            newpass_txtbox.UseSystemPasswordChar = true; // Hide the password characters
            confirmpass_txtbox.UseSystemPasswordChar = true; // Hide the confirm password characters
        }

        private void confirm_bttn_Click(object sender, EventArgs e)
        {
            string newPassword = newpass_txtbox.Text;
            string confirmPassword = confirmpass_txtbox.Text;
            


            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                // Assuming you have a method to get the connection string
                string connectionString = "Server=WINDOWS-PC;Database=Restaurant;Trusted_Connection=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (newPassword == confirmPassword)
                    {
                        string query = "update Account set Password = @newPassword where AccID = (select AccID from AccountData where EmpID = @empid)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@newPassword", newPassword);
                            cmd.Parameters.AddWithValue("@empid", value["EmpID"]);



                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password changed successfully.");
                                this.Close(); // Close the form after successful password change
                                Login loginForm = new Login(); // Assuming you want to return to the login form
                                loginForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Failed to change password. Please check your phone number.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Passwords do not match. Please try again.");
                    }
                }
            }
        }
    }
}
