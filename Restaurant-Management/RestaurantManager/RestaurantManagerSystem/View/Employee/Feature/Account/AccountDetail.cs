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
    public partial class AccountDetail : Form
    {
        private string connectionString = "Server=WINDOWS-PC;Database=Restaurant;Trusted_Connection=True";
        private Dictionary<string, string> value;
        public AccountDetail()
        {
            InitializeComponent();
        }
       
        public AccountDetail(Dictionary<string, string> value) : this()
        {
            this.value = value;
            empid_txtbox.Text = value["EmpID"];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AccountDetail_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select E.Name as EmpName, E.SDT, A.Gmail, V.Name as RoleName \r\nfrom AccountData as Acc\r\njoin Account as A on Acc.AccID = A.AccID\r\njoin VaiTro as V on V.RoleID = Acc.RoleID \r\njoin Employee as E on Acc.EmpID = E.EmpID \r\nwhere Acc.EmpID = @empID";

                //This here to read employee information from database to textboxes
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empID", value["EmpID"]);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            accid_txtbox.Text = value["AccID"];
                            name_txtbox.Text = reader["EmpName"].ToString();
                            sdt_txtbox.Text = reader["SDT"].ToString();
                            mail_txtbox.Text = reader["Gmail"].ToString();
                            role_cmbbox.Text = reader["RoleName"].ToString();
                        }
                    }

                    //This here to read all roles from database to combobox
                    using (SqlCommand roleCmd = new SqlCommand("select Name from VaiTro", conn))
                    {
                        using (SqlDataReader roleReader = roleCmd.ExecuteReader())
                        {
                            while (roleReader.Read())
                            {
                                role_cmbbox.Items.Add(roleReader["Name"].ToString());
                            }
                        }
                    }
                }
            }
        }

        private void empid_txtbox_TextChanged(object sender, EventArgs e)
        {
            empid_txtbox.Text = value["EmpID"];
        }

        private void edit_bttn_Click(object sender, EventArgs e)
        {
           
        }

        private void edit_bttn_Click_1(object sender, EventArgs e)
        { 
            string name = name_txtbox.Text;
            string sdt = sdt_txtbox.Text;
            string mail = mail_txtbox.Text;
            string role = role_cmbbox.Text;

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update Employee set Name = @name, SDT = @sdt where EmpID = @empID\r\nupdate Account set Gmail = @mail where AccID = @accID\r\nupdate AccountData set RoleID = (select RoleID from VaiTro where Name = @role) where EmpID = @empID";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@empID", value["EmpID"]);
                    cmd.Parameters.AddWithValue("@accID", value["AccID"]);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void return_bttn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
