using System;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.View
{
    /*
        AdoptionForm; 레스토랑 채택
        1. 오늘의 점심을 보여줌.
        2. 목록으로 이동
     */
    public partial class AdoptionForm : Form
    {
        Restaurant restaurant;

        public AdoptionForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        /*
            ShowLunch
            1. 레스토랑 이름 채택 텍스트 박스에 추가
         */
        private void ShowLunch(object sender, EventArgs e)
        {
            txtAdoption.Text += restaurant.name;
        }

        /*
            ListRestaurant
            1. 리스트 폼 호출
         */
        private void ListRestaurant(object sender, EventArgs e)
        {
            new ListForm().Show();
            this.Visible = false;
        }
    }
}
