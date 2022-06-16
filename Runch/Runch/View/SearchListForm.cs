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
    public partial class SearchListForm : Form
    {
        Restaurant restaurant;

        public SearchListForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        private void ListRestaurant(object sender, EventArgs e)
        {
            dgvRestaurant.DataSource = restaurant.Search().Tables[0].DefaultView;
        }

        private void ShowDetail(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvRestaurant.CurrentRow.Cells["No"].Value.ToString());
            new DetailForm(new Restaurant().FindById(id)).Show();
        }

        private void AddRestaurant(object sender, EventArgs e)
        {
            new AddForm().Show();
        }

        private void SearchRestaurant(object sender, EventArgs e)
        {
            new SearchForm().Show();
        }
    }
}
