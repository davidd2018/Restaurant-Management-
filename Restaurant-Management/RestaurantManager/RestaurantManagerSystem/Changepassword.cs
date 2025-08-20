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
    public partial class ForgotPass: Form
    {

        //using the server that u are using
        private string connectionString = "Server=WINDOWS-PC;Database=Restaurant;Trusted_Connection=True";
        
        public ForgotPass()
        {
            InitializeComponent();
            //If u wanna add sthing into the combobox, you can do it here
      
        }
        private void role_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ForgotPass_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT *  FROM VaiTro";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        role_comboBox.Items.Clear(); // Clear existing items
                        while (reader.Read())
                        {
                            string role = reader["Name"].ToString();
                            role_comboBox.Items.Add(role);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }

            }
        }

        private void submit_bttn_Click(object sender, EventArgs e)
        {
            string sdt = sdt_txtbox.Text.Trim();
            string empid = Id_txtbox.Text.Trim();
            string role = role_comboBox.SelectedItem?.ToString();

            //Here i use Dictionary to store the values that i will use later in the SubmitChangePass form
            //So that the EmpID will be passed to the SubmitChangePass form
            Dictionary<string, string> value = new Dictionary<string, string> 
            {
                {"SDT", sdt },
                { "EmpID", empid },
                { "Role", role }
            };

            if (string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(empid) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select B.EmpID, B.SDT " +
                                "from AccountData as A join Employee as B on A.EmpID = B.EmpID " +
                                "join VaiTro as C on A.RoleID = C.RoleID " +
                                "where SDT = @SDT and A.EmpID = @EmpID and C.Name = @Role";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpID", empid);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    

                    cmd.Parameters.AddWithValue("@Role", role);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            // User exists, proceed to reset password
                            MessageBox.Show("User found! You can now reset your password.");
                            // Here you can add logic to reset the password
                            
                            SubmitChangePass changePassForm = new SubmitChangePass(value);
                            changePassForm.Show();
                            Close(); // Close the current form
                        }
                        else
                        {
                            MessageBox.Show("No user found with the provided details.");
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
