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
    public partial class DetailForm : Form
    {
        Restaurant restaurant;

        public DetailForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            txtName.Text = restaurant.name;
            txtCategory.Text += restaurant.category;
            txtSignature.Text = restaurant.signature;
            txtAdoption.Text = restaurant.cntAdoption.ToString();
            txtRecentAdoption.Text = restaurant.recentAdoption;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            restaurant.Block();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new EditForm(restaurant).Show();
            this.Close();
        }
    }
}
