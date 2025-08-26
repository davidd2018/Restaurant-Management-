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



        //Generate a unique ID for the new food/drink item
       //private string GenerateUniqueCateID(List<FoodDrink> list)
       // {
       //     using (SqlConnection conn = new SqlConnection(connectionString))
       //     {
       //         string query = "insert into FoodDrink";
       //     }
       // }

        private void button1_Click(object sender, EventArgs e)
        {

            //testing category ID
            int count = 0;
            string category = category_cmbbox.Text;

            if (category == "Food")
            {
                category = "C" + (count + 1);
                
            }
            else if (category == "Drink")
            {
                category = "D" + (count + +1);
            }
            else
            {
                MessageBox.Show("Please select a valid category.");
            }

            //end of testing type ID

            int count2 = 0;
            string type = type_cmbbox.Text;
            if (type == "Vietnamese")
            {
                type = "T" + (count2 ++);
            }
            else if (type == "Western")
            {
                type = "T" + (count2 ++);

            }
           
            else
            {
                MessageBox.Show("Please select a valid type.");
            }

            string chosen_category = category;
            string chosen_type = type;

            string name = fooddrinkname_txtbox.Text;
            string ingredient = ingredient_txtbox.Text;
            string size = size_cmbbox.Text;
            string unit = unit_cmbbox.Text;
            decimal price = decimal.Parse(price_txtbox.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO FoodDrink (FoodDrinkID, CateID, TypeID, Name,Ingredients, Size, Unit, Price) " +
                               "VALUES (@FoodDrinkID,@cateID,@type,@name, @size, @unit)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FoodDrinkID", chosen_category);
                    cmd.Parameters.AddWithValue("@cateID", chosen_category);
                    cmd.Parameters.AddWithValue("@type", chosen_type);
                    cmd.Parameters.AddWithValue("@name", name);
                    //cmd.Parameters.AddWithValue("@ingredient", ingredient);
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

                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                string query = "insert into FoodDrink(ImgURL)" +
                                "values(@imgurl)";
                using(SqlCommand cmd = new SqlCommand(query))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@imgurl", imagePath);
                }    
            }
            }
                
        }

        private void category_cmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
