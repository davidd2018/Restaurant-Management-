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
                string query = "select A.FoodDrinkID,B.Name, C.Name as N'Loại món', D.Name as N'Nhóm món'\r\nfrom Menu as A\r\njoin FoodDrink as B on A.FoodDrinkID = B.FoodDrinkID\r\njoin Type as C on B.TypeID = C.TypeID\r\njoin Category as D on B.CateID = D.CateID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            // Assuming you have columns named "FoodID", "FoodName", "FoodDrink", "Type", and "Price" in your DataGridView
                            string id = reader["FoodID"].ToString();
                            string name = reader["FoodName"].ToString();
                            string fooddrink = reader["FoodDrink"].ToString();
                            string type = reader["Type"].ToString();
                            string price = (decimal)reader["Price"] + " VND";
                            dataGridView1.Rows.Add(id);
                            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value = name;
                            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value = fooddrink;
                            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[3].Value = type;
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
