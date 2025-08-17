using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerSystem
{
    public partial class ForgotPass: Form
    {
        public ForgotPass()
        {
            InitializeComponent();
            //If u wanna add sthing into the combobox, you can do it here
            role_comboBox.Items.Add("Manager");
            role_comboBox.Items.Add("Waiter");
            role_comboBox.Items.Add("Chef");
        }


        private void role_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
