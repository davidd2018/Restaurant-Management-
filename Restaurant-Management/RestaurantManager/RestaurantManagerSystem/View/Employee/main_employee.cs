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
    }
}
