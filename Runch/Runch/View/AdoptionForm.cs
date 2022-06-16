using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.View
{
    public partial class AdoptionForm : Form
    {
        Restaurant restaurant;

        public AdoptionForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        private void ShowLunch(object sender, EventArgs e)
        {
            txtAdoption.Text += restaurant.name;
        }

        private void ListRestaurant(object sender, EventArgs e)
        {
            new ListForm().Show();
            this.Visible = false;
        }
    }
}
