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
using RestaurantManagerSystem.View.Employee;


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
           this.Hide(); // Hide the current form

        }

        private void button1_Click(object sender, EventArgs e) //I changed the name of the button to "Login_bttn" in the designer file 
        {
            string empid = UserID_txtbox.Text.Trim();// Use trim to remove all leading and trailing whitespaces
            string password = Password_txt.Text.Trim();

            Dictionary<string, string> role_value = new Dictionary<string, string>
            {
                { "EmpID", empid },
                { "Password", password }
            };

            if (string.IsNullOrEmpty(empid) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both ID and password.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT A.AccID, C.EmpID,D.RoleID,D.Name,A.Password\r\nFROM Account AS A \r\nJOIN AccountData AS B ON A.AccID = B.AccID\r\nJOIN Employee AS C ON B.Empid = C.Empid \r\nJOIN VaiTro AS D ON B.Roleid = D.Roleid \r\nWHERE B.Empid = @empid and A.Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@Password", password);
                    

                    Dictionary<string, string> value = new Dictionary<string, string>
                    {
                        { "EmpID", empid },
                        { "Password", password}
                    };


                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        //The whole If Else method here is used to check if the user exists in the database
                        if (reader.HasRows)
                        {

                            if(reader.Read())
                            {

                                // Retrieve the role ID and name from the reader
                                string accID = reader["AccID"].ToString();
                                string empID = reader["EmpID"].ToString();
                                string roleID = reader["RoleID"].ToString();
                                string roleName = reader["Name"].ToString();
                                // Store the values in the dictionary
                                value["AccID"] = accID;
                                value["RoleID"] = roleID;
                                value["RoleName"] = roleName;
                                // Open the main employee form with the retrieved values
                                if(roleName == "Admin") 
                                {
                                    main_employee mainEmployeeForm = new main_employee(value);
                                    mainEmployeeForm.Show();
                                    
                                }
                                else
                                {
                                    MessageBox.Show("LEAVE NOW.");
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid ID or password.");
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



            //+++++ Here just to test if the connection to the database is working +++++ //


            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    string query = "\r\nSELECT A.Empid, C.Password FROM AccountData as A \r\njoin AccountData as B on A.AccID = B.AccID\r\njoin Account as C on B.AccID = C.AccID";
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        try
            //        {
            //            conn.Open();
            //            SqlDataReader reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                // Assuming AccID is a string, you can adjust the type as needed
            //                string empid = reader["Empid"].ToString();
            //                string password = reader["Password"].ToString();
            //                dataGridView1.Rows.Add(empid);

            //                //when change to "count-1" it will add the last row of the datagridview
            //                //and when change to "count-2" it will add the second last row of the datagridview
            //                //++ REMEMBER TO CHANGE THE COLUMN INDEX IF YOU ADD MORE COLUMNS ++
            //                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value = password; // Assuming the second column is for Password
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("An error occurred: " + ex.Message);
            //        }
            //    }
            //}
        }

        private void Password_txt_TextChanged(object sender, EventArgs e)
        {
            Password_txt.UseSystemPasswordChar = true; // This will hide the password characters
        }

        private void UserID_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
