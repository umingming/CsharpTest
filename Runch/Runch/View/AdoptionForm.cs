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

        /*
            RecommendLunch; 점심추천 메뉴로 이동
            1. 카테고리 폼 생성
         */
        private void RecommendLunch(object sender, EventArgs e)
        {
            new CategoryForm().Show();
            // this.Visible = false;
        }

        /*
            Logout
            1. 로그아웃
            2. 로그인 화면으로 이동
         */
        private void Logout(object sender, EventArgs e)
        {
            new User().Logout();
            new LoginForm().Show();
            this.Visible = false;
        }

        /*
            ShowMain
            1. 메인으로 이동
         */
        private void ShowMain(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Visible = false;
        }

        /*
            Quit
            1. 로그아웃
            2. 어플리케이션을 종료
         */
        private void Quit(object sender, FormClosedEventArgs e)
        {
            new User().Logout();
            Application.Exit();
        }

        /*
            ProcessCmdKey; 오버로딩
         */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
