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
                    //string rolequery = "select Name from VaiTro";
                    //using (SqlCommand cmd = new SqlCommand(rolequery, conn))
                    //{
                    //    conn.Open();
                    //    using (SqlDataReader reader = cmd.ExecuteReader())
                    //    {
                    //       while(reader.Read())
                    //        {
                    //            role_cmbbox.Items.Add(reader["Name"].ToString());
                    //        }
                    //    }
                    //    conn.Close();
                    //}


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

        private void loadDataGridView()
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string accountQuery = "select Distinct E.EmpID, E.Name as EmpName, SDT, V.Name as RoleName, Gmail from Employee as E\r\njoin AccountData as A on E.EmpID = A.EmpID\r\njoin VaiTro as V on A.RoleID = V.RoleID\r\njoin Account as Acc on A.AccID = Acc.AccID";
                SqlDataAdapter adapter = new SqlDataAdapter(accountQuery, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
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
            Application.Exit();
        }

        private void xemTàiKhoảnHiệnTạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountDetail accountDetailsForm = new AccountDetail(value);
            accountDetailsForm.ShowDialog();
        }

      

        private void thToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void reload_bttn_Click(object sender, EventArgs e)
        {
           loadDataGridView();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void delete_bttn_Click(object sender, EventArgs e)
        {

        }

        private void edit_bttn_Click(object sender, EventArgs e)
        {

            DataGridViewRow selectedRow = dataGridView2.Rows[indexRows];

            selectedRow.Cells[0].Value = empid_txtbox.Text;
            selectedRow.Cells[1].Value = name_txtbox.Text;
            selectedRow.Cells[2].Value = sdt_txtbox.Text;
            selectedRow.Cells[3].Value = mail_txtbox.Text;
            selectedRow.Cells[4].Value = role_cmbbox.Text;
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

       
    }
}
