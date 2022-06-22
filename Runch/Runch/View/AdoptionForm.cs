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
            this.Visible = false;
            new ListForm().ShowDialog();
        }

        /*
            RecommendLunch; 점심추천 메뉴로 이동
            1. 카테고리 폼 생성
         */
        private void RecommendLunch(object sender, EventArgs e)
        {
            this.Visible = false;
            new CategoryForm().ShowDialog();
        }

        /*
            Logout
            1. 로그아웃
            2. 로그인 화면으로 이동
         */
        private void Logout(object sender, EventArgs e)
        {
            new User().Logout();
            this.Visible = false;
            new LoginForm().ShowDialog();
        }

        /*
            ShowMain
            1. 메인으로 이동
         */
        private void ShowMain(object sender, EventArgs e)
        {
            this.Visible = false;
            new MainForm().ShowDialog();
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

        /*
            ShowListByEnterKeyDown
            1. if문 입력 키가 엔터가 아닌지?
                > return
            2. ListRestaurant 호출
         */
        private void ShowListByEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            ListRestaurant(sender, e);
        }
    }
}
