using RestaurantManagerSystem.View.Employee;
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

//TO MY FUTURE SELF//
//++ READ THE COMMENTS CAREFULLY BROTHER ++//

namespace RestaurantManagerSystem
{
    public partial class Register : Form
    {
        private string connectionString = "Server=WINDOWS-PC;Database=Restaurant;Trusted_Connection=True";
        private main_employee _main_Employee;
        public Register(main_employee mainform)
        {
            InitializeComponent();
            _main_Employee = mainform;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Here, we are dealing with 4 tables: Account, Employee, AccountData, VaiTro

            string name = name_txtbox.Text;
            string password = password_txtbox.Text;
            string sdt = sdt_txtbox.Text;
            string gmail = gmail_txtbox.Text;
            string role = role_cmbbox.SelectedItem?.ToString();

            //Here i created RolePrefix to generate EmpID and AccID based on role and same goes to Emp
            string roleprefix = role == "Employee" ? "E" : role == "Admin" ? "AD" : "E";
            string empID = generateCustomEmpID(roleprefix);
            string accRoleprefix = role == "Employee" ? "EM" : role == "Admin" ? "ADMIN" : "STAFF";
            string accID = generateCustomAccID(accRoleprefix);

            //Query strings for each table
            //query account
            string account_query = "INSERT INTO Account(AccID, Gmail, Password) " +
                                   "VALUES(@accID, @gmail, @password)";
            //query employee
            string emp_query = "INSERT INTO Employee(EmpID, Name, SDT) " +
                               "VALUES(@empID, @name, @sdt)";

            //query accountdata (NOTE: this one is the main table that links acc and emp with role)
            string accountdata_query = "INSERT INTO AccountData(AccID, EmpID, RoleID) " +
                                       "VALUES(@accID,@empID,@roleID)";
            //query roleid from vaitro
            string role_query = "SELECT RoleID FROM VaiTro WHERE Name = @role";


            // Use a transaction to ensure all inserts succeed or fail together
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection
                conn.Open();

                //*TRANSACTION*//
                //transaction is a temporary workspace where you can group multiple database operations together.
                //It ensures that either all of them SUCCEED, or none of them do — no half-done inserts, no broken data.
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Get RoleID from VaiTro
                    string roleID = null;
                    using (SqlCommand cmd = new SqlCommand(role_query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@role", role);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            roleID = result.ToString();
                        }
                        else
                        {
                            throw new Exception("Invalid role selected. Role does not exist in VaiTro table.");
                        }
                    }

                    // Insert into Account
                    using (SqlCommand cmd = new SqlCommand(account_query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@accID", accID);
                        cmd.Parameters.AddWithValue("@gmail", gmail);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into Employee
                    using (SqlCommand cmd = new SqlCommand(emp_query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@empID", empID);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@sdt", sdt);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into AccountData (with real RoleID)
                    using (SqlCommand cmd = new SqlCommand(accountdata_query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@accID", accID);
                        cmd.Parameters.AddWithValue("@empID", empID);
                        cmd.Parameters.AddWithValue("@roleID", roleID);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();//SAVE all inserts permanently to the database
                    MessageBox.Show("Register account successfully!");
                    if(_main_Employee != null)
                    {
                        _main_Employee.RefreshAccountDataGridView(); // Call the method to refresh the DataGridView
                    }
                    
                    
                    this.Hide();
                    this.Close();




                    name_txtbox.Clear();
                    sdt_txtbox.Clear();
                    gmail_txtbox.Clear();
                    password_txtbox.Clear();
                    role_cmbbox.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();//UNDO all inserts if any error occurs
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        //The idea here is to get the last inserted ID with the same prefix, extract the numeric part, increment it, and then combine it back with the prefix.
        //It will based on the role prefix to generate IDs like EM001, EM002 for Employees and ADMIN001, ADMIN002 for Admins.


        //Custom ID generator for Account based on role prefix
        private string generateCustomAccID(string AccrolePrefix)
        {
            string newID = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 AccID FROM Account WHERE AccID LIKE @rolePrefix + '%' ORDER BY AccID DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@rolePrefix", AccrolePrefix);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastID = result.ToString();
                        int numericPart = int.Parse(lastID.Substring(AccrolePrefix.Length));
                        numericPart++;
                        newID = AccrolePrefix + numericPart.ToString("D3");
                    }
                    else
                    {
                        newID = AccrolePrefix + "001";
                    }
                    conn.Close();
                }
            }
            return newID;
        }

        //Custom ID generator for Employee based on role prefix
        private string generateCustomEmpID(string EmprolePrefix)
        {
            string newID = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 EmpID FROM Employee WHERE EmpID LIKE @rolePrefix + '%' ORDER BY EmpID DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@rolePrefix", EmprolePrefix);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastID = result.ToString();
                        int numericPart = int.Parse(lastID.Substring(EmprolePrefix.Length));
                        numericPart++;
                        newID = EmprolePrefix + numericPart.ToString("D3");
                    }
                    else
                    {
                        newID = EmprolePrefix + "001";
                    }
                    conn.Close();
                }
            }
            return newID;
        }



        private void Register_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string role_query = "select Name from VaiTro";
                using (SqlCommand cmd = new SqlCommand(role_query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            role_cmbbox.Items.Add(reader.GetString(0));
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void password_txtbox_TextChanged(object sender, EventArgs e)
        {
            password_txtbox.UseSystemPasswordChar = true;//This here will mask the password input dots like ******
        }
    }
}
