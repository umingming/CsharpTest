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
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }

        private void ListRestaurant(object sender, EventArgs e)
        {
            dgvRestaurant.DataSource = new Restaurant().List().Tables[0].DefaultView;
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
