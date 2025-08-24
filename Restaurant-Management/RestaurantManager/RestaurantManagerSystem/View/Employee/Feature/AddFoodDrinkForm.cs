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

namespace RestaurantManagerSystem.View.Employee.Feature
{
    public partial class AddFoodDrinkForm : Form
    {

        private string connectionString = "Server=WINDOWS-PC;Database=Restaurant;Trusted_Connection=True";
        public AddFoodDrinkForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cate = category_cmbbox.Text;
            string type = type_cmbbox.Text;
            string name = fooddrinkname_txtbox.Text;
            string ingredient = ingredient_txtbox.Text;
            string size = size_cmbbox.Text;
            string unit = unit_cmbbox.Text;
            decimal price = decimal.Parse(price_txtbox.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Menu (FoodDrinkName, FoodDrink, Type, Ingredient, Size, Unit, Price) " +
                               "VALUES (@name, @cate, @type, @ingredient, @size, @unit, @price)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@cate", cate);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@ingredient", ingredient);
                    cmd.Parameters.AddWithValue("@size", size);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@price", price);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            DialogResult result = MessageBox.Show("Are you sure you want to add this item?", "Confirm Addition", MessageBoxButtons.YesNo);

                            if (result == DialogResult.No)
                            {
                                return; // Exit if the user selects "No"
                            }
                            else
                            {
                                MessageBox.Show("Food/Drink item added successfully!");
                            }
                            this.Close(); // Close the form after successful addition
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the item. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }

            }
        }

        private void AddFoodDrinkForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string querry = "select * from Category ";

                using (SqlCommand cmd = new SqlCommand(querry, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        category_cmbbox.Items.Clear(); // Clear existing items
                        while (reader.Read())
                        {
                            string category = reader["Name"].ToString();
                            category_cmbbox.Items.Add(category);
                        }

                        //Every time after using a SqlDataReader, close it before executing another command
                        reader.Close(); // Close the reader before executing another command
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }

                    string querry2 = "select * from Type ";
                    using (SqlCommand cmd2 = new SqlCommand(querry2, conn))
                    {
                        try
                        {
                            
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            type_cmbbox.Items.Clear(); // Clear existing items
                            while (reader2.Read())
                            {
                                string type = reader2["Name"].ToString();
                                type_cmbbox.Items.Add(type);
                            }
                            reader2.Close(); // Close the reader before executing another command
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
            } 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select an Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void category_cmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
