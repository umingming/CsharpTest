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
    public partial class SearchForm : Form
    {
        Notification box;

        public SearchForm()
        {
            box = new Notification();
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            box.DisplayWarning(dtpStart.Value.ToString().Substring(0, dtpStart.Value.ToString().IndexOf(" ")) + "");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.start = dtpStart.Value.ToString().Substring(0, dtpStart.Value.ToString().IndexOf(" ")) + "";
            restaurant.end = dtpEnd.Value.ToString().Substring(0, dtpEnd.Value.ToString().IndexOf(" ")) + "";
            restaurant.categoryId = Int32.Parse(cmbCategory.SelectedValue.ToString());
            restaurant.userName = txtUser.Text;

            new SearchListForm(restaurant).Show();
        }
    }
}
