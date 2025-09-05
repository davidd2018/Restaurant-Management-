using RestaurantManagerSystem.Model;
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

namespace RestaurantManagerSystem.View.Employee
{
    public partial class main_employee : Form
    {

        private string connectionString = "Server=WINDOWS-PC;Database=Restaurant;Trusted_Connection=True";
        private List<FoodDrink> menuList = new List<FoodDrink>();


        int indexRows;


        int selectedRow;


        private Dictionary<string, string> value;

        public main_employee(Dictionary<string, string> value) : this()
        {
            this.value = value;
            roleToolStripMenuItem.Text = value["EmpID"];
        }

        public main_employee()
        {
            InitializeComponent();
        }

        private void main_employee_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // This query retrieves Menu data from the joined tables
                string query = "SELECT  Distinct\r\n    A.FoodDrinkID,\r\n    B.Name,\r\n    C.Name,\r\n    D.Name,\r\n    A.Price\r\nFROM Menu AS A\r\nJOIN FoodDrink AS B ON A.FoodDrinkID = B.FoodDrinkID\r\nJOIN Category AS C ON B.CateID = C.CateID\r\nJOIN Type AS D ON D.TypeID = D.TypeID;\r\n";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            // Assuming you have columns named "FoodID", "Name", "FoodDrink", "Type", and "Price" in your DataGridView
                            string id = reader["FoodDrinkID"].ToString();
                            string name = reader["Name"].ToString();
                            string fooddrink_name = reader["Name"].ToString();
                            string cate_name = reader["Name"].ToString();
                            string type_name = reader["Name"].ToString();

                            string price = (decimal)reader["Price"] + " VND";
                            dataGridView1.Rows.Add(id);
                            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value = name;
                            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value = fooddrink_name;
                            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[3].Value = type_name;
                            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[4].Value = price;


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }

                //Accounts list
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string accountQuery = "select Distinct E.EmpID, E.Name as EmpName, SDT, V.Name as RoleName, Gmail from Employee as E\r\njoin AccountData as A on E.EmpID = A.EmpID\r\njoin VaiTro as V on A.RoleID = V.RoleID\r\njoin Account as Acc on A.AccID = Acc.AccID";
                    using (SqlCommand accCmd = new SqlCommand(accountQuery, conn))
                    {
                        SqlDataReader accReader = accCmd.ExecuteReader();
                        while (accReader.Read())
                        {
                            string empID = accReader["EmpID"].ToString();
                            string empName = accReader["EmpName"].ToString();
                            string sdt = accReader["SDT"].ToString();
                            string gmail = accReader["Gmail"].ToString();
                            string role = accReader["RoleName"].ToString();

                            dataGridView2.Rows.Add(empID);
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[1].Value = empName;
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[2].Value = sdt;
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[3].Value = gmail;
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[4].Value = role;
                        }
                    }
                }


                //This here to read all roles from database to combobox
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string rolequery = "SELECT RoleID, Name FROM VaiTro"; // adjust column names
                    SqlDataAdapter da = new SqlDataAdapter(rolequery, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    role_cmbbox.DataSource = dt;
                    role_cmbbox.DisplayMember = "Name";   // what user sees
                    role_cmbbox.ValueMember = "RoleID";   //What is actually stored in the combobox
                }


                //Sum of employee
                int employeeCount = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(DISTINCT EmpID) AS EmployeeCount FROM Employee";
                    using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                    {
                        employeeCount = (int)countCmd.ExecuteScalar();//ExecuteScalar is used to retrieve a single value from the database like COUNT, SUM, AVG
                        sumemp_txtbox.Text = employeeCount.ToString();
                    }
                }
            }
        }

        private void UpdateEmpCount()
        {
            int employeeCount = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string countQuery = "SELECT COUNT(DISTINCT EmpID) AS EmployeeCount FROM Employee";
                using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                {
                    employeeCount = (int)countCmd.ExecuteScalar();//ExecuteScalar is used to retrieve a single value from the database like COUNT, SUM, AVG
                    sumemp_txtbox.Text = employeeCount.ToString();
                }
            }
        }



        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            roleToolStripMenuItem.Text = value["EmpID"];
        }

        private void add_bttn_Click(object sender, EventArgs e)
        {
            Feature.AddFoodDrinkForm addFoodDrinkForm = new Feature.AddFoodDrinkForm();
            addFoodDrinkForm.ShowDialog();
        }


        //this will check if the ID exist in the database
        public bool checkIDExist(string ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Menu WHERE FoodDrinkID = @FoodDrinkID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodDrinkID", ID);
                return true;
            }

        }


        private void searchbyID_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void price_txtbox_TextChanged(object sender, EventArgs e)
        {

        }
        private void fooddrink_cmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog();

        }

        private void xemTàiKhoảnHiệnTạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountDetail accountDetailsForm = new AccountDetail(value);
            accountDetailsForm.ShowDialog();
        }



        private void thToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }






        private void delete_bttn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView2.Rows[selectedRow];

            string empID = empid_txtbox.Text;
            string name = name_txtbox.Text;
            string sdt = sdt_txtbox.Text;
            string mail = mail_txtbox.Text;
            string role = role_cmbbox.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM AccountData WHERE EmpID = @empID;\r\n" +
                                     "DELETE FROM Account WHERE AccID = (SELECT AccID FROM AccountData WHERE EmpID = @empID);\r\n" +
                                     "DELETE FROM Employee WHERE EmpID = @empID;";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee deleted successfully.");
                        //Remove the deleted row from the DataGridView
                        dataGridView2.Rows.RemoveAt(selectedRow);
                        //Clear the textboxes after deletion
                        empid_txtbox.Clear();
                        name_txtbox.Clear();
                        sdt_txtbox.Clear();
                        mail_txtbox.Clear();
                        role_cmbbox.SelectedIndex = -1; // Deselect combobox
                        UpdateEmpCount();
                    }
                    else
                    {
                        MessageBox.Show("Deletion failed. Please try again.");
                    }
                }
            }
        }

        private void edit_bttn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView2.Rows[selectedRow];

            string empID = empid_txtbox.Text;
            string name = name_txtbox.Text;
            string sdt = sdt_txtbox.Text;
            string mail = mail_txtbox.Text;
            string role = role_cmbbox.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = "Update Employee set Name = @name, SDT = @sdt where EmpID = @empID\r\n" +
                                     "Update Account set Gmail = @gmail where AccID = (select AccID from AccountData where EmpID = @empID)\r\n" +
                                     "Update AccountData set RoleID = (select RoleID from VaiTro where Name = @role) where EmpID = @empID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@gmail", mail);
                    cmd.Parameters.AddWithValue("@role", role);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee information updated successfully.");

                        //This worked but it will add a new row instead of updating the current row

                        //row.Cells[0].Value = empID; 
                        //row.Cells[1].Value = name;
                        //row.Cells[2].Value = sdt;
                        //row.Cells[3].Value = mail;
                        //row.Cells[4].Value = role;


                        //This one will update the current row and not add a new row
                        //Update the DataGridView to reflect changes
                        //Show the updated values in the DataGridView right away
                        dataGridView2.CurrentRow.Cells[0].Value = empID;
                        dataGridView2.CurrentRow.Cells[1].Value = name;
                        dataGridView2.CurrentRow.Cells[2].Value = sdt;
                        dataGridView2.CurrentRow.Cells[3].Value = mail;
                        dataGridView2.CurrentRow.Cells[4].Value = role;

                        dataGridView2.Refresh();

                    }
                    else
                    {
                        MessageBox.Show("Update failed. Please check the details and try again.");
                    }
                }
            }



        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                empid_txtbox.Text = row.Cells[0].Value.ToString();
                name_txtbox.Text = row.Cells[1].Value.ToString();
                sdt_txtbox.Text = row.Cells[2].Value.ToString();
                mail_txtbox.Text = row.Cells[3].Value.ToString();
                role_cmbbox.Text = row.Cells[4].Value.ToString();
            }
        }

        private void sumemp_txtbox_TextChanged(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void searchByID_bttn_Click(object sender, EventArgs e)
        {
            string searchEmpID = searchID_txtbox.Text.Trim();
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string searchquery = "select Distinct A.EmpID, E.Name as EmpName, E.SDT, B.Gmail, V.Name as RoleName " +
                              "from AccountData as A " +
                              "join Account as B on A.AccID = B.AccID " +
                              "join VaiTro as V on A.RoleID = V.RoleID " +
                              "join Employee as E on A.EmpID = E.EmpID " +
                              "where A.EmpID like @empID";


                //if the search box not empty, show all employees with partial match
                using (SqlCommand cmd = new SqlCommand(searchquery, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", "%" + searchEmpID + "%");
                    SqlDataReader reader = cmd.ExecuteReader();
                    dataGridView2.Rows.Clear(); // Clear existing rows
                    while (reader.Read())
                    {
                        string empID = reader["EmpID"].ToString();
                        string empName = reader["EmpName"].ToString();
                        string sdt = reader["SDT"].ToString();
                        string gmail = reader["Gmail"].ToString();
                        string role = reader["RoleName"].ToString();
                        dataGridView2.Rows.Add(empID);
                        dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[1].Value = empName;
                        dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[2].Value = sdt;
                        dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[3].Value = gmail;
                        dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[4].Value = role;
                    }
                    reader.Close(); // Close the reader before executing another command

                    if(dataGridView2.Rows.Count == 1)
                    {
                        MessageBox.Show("Không tồn tại mã nhân viên này.");
                    }
                }

                if(searchEmpID == null)
                {
                    // Show all employees if search box is empty
                    string query = "select Distinct A.EmpID, E.Name as EmpName, E.SDT, B.Gmail, V.Name as RoleName " +
                            "from AccountData as A " +
                            "join Account as B on A.AccID = B.AccID " +
                            "join VaiTro as V on A.RoleID = V.RoleID " +
                            "join Employee as E on A.EmpID = E.EmpID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        dataGridView2.Rows.Clear(); // Clear existing rows
                        while (reader.Read())
                        {
                            string empID = reader["EmpID"].ToString();
                            string empName = reader["EmpName"].ToString();
                            string sdt = reader["SDT"].ToString();
                            string gmail = reader["Gmail"].ToString();
                            string role = reader["RoleName"].ToString();
                            dataGridView2.Rows.Add(empID);
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[1].Value = empName;
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[2].Value = sdt;
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[3].Value = gmail;
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[4].Value = role;
                        }
                        reader.Close(); // Close the reader before executing another command
                    }
                }
            }
        }
        private void searchID_txtbox_TextChanged(object sender, EventArgs e)
        {
            //string searchEmpID = searchID_txtbox.Text.Trim();

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    string query;
            //    SqlCommand cmd;

            //    if (string.IsNullOrEmpty(searchEmpID))
            //    {
            //        // Show all employees if search box is empty
            //        query = "select Distinct A.EmpID, E.Name as EmpName, E.SDT, B.Gmail, V.Name as RoleName " +
            //                "from AccountData as A " +
            //                "join Account as B on A.AccID = B.AccID " +
            //                "join VaiTro as V on A.RoleID = V.RoleID " +
            //                "join Employee as E on A.EmpID = E.EmpID";
            //        cmd = new SqlCommand(query, conn);
            //    }
            //    else
            //    {
            //        // Partial match search
            //        query = "select Distinct A.EmpID as MaNv, E.Name as EmpName, E.SDT, B.Gmail, V.Name as RoleName " +
            //                "from AccountData as A " +
            //                "join Account as B on A.AccID = B.AccID " +
            //                "join VaiTro as V on A.RoleID = V.RoleID " +
            //                "join Employee as E on A.EmpID = E.EmpID " +
            //                "where A.EmpID like @empID";
            //        cmd = new SqlCommand(query, conn);
            //        cmd.Parameters.AddWithValue("@empID", "%" + searchEmpID + "%");
                
            //    }
            //}
        }
    }
}

