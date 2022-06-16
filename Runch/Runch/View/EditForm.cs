using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.View
{
    public partial class EditForm : Form
    {
        Restaurant restaurant;
        public EditForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            cmbCategory.DisplayMember = "Text";
            cmbCategory.ValueMember = "Value";

            var categories = new[] {
                new { Text = " 한식", Value = "16" },
                new { Text = " 중식", Value = "17" },
                new { Text = " 일식", Value = "18" },
                new { Text = " 양식", Value = "19" },
                new { Text = " 기타", Value = "20" },
            };
            cmbCategory.DataSource = categories;
            cmbCategory.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Restaurant newRestaurant = new Restaurant();
            newRestaurant.name = txtName.Text;
            newRestaurant.categoryId = Int32.Parse(cmbCategory.SelectedValue.ToString());
            newRestaurant.signature = txtSignature.Text;
            restaurant.Edit(newRestaurant);
            this.Close();
        }
    }
}
