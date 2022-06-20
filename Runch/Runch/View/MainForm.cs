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
    /*
        MainForm
        1. 사용자 정보 안내
        2. 원하는 페이지로 이동
      */
    public partial class MainForm : Form
    {
        User user;
        Notification box;

        public MainForm()
        {
            box = new Notification();
            InitializeComponent();
        }

        /*
            InitUserInfo
            1. 사용자 정보를 초기화함.
         */
        private void InitUserInfo(object sender, EventArgs e)
        {
            user = new User();
            user.id = Properties.Settings.Default.UserId;
            user.name = Properties.Settings.Default.UserName;
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
            ListRestaurant; 레스토랑 목록 출력
            1. ListForm 호출
         */
        private void ListRestaurant(object sender, EventArgs e)
        {
            this.Visible = false;
            new ListForm().ShowDialog();
        }

        /*
            ShowMypage
            1. 마이페이지로 이동
        */
        private void ShowMypage(object sender, EventArgs e)
        {
            box.DisplaySimpleWarning("준비 중");
        }

        /*
            Logout
            1. 로그아웃
            2. 로그인 화면으로 이동
         */
        private void Logout(object sender, EventArgs e)
        {
            user.Logout();
            this.Visible = false;
            new LoginForm().ShowDialog();
        }

        /*
            Quit
            1. 로그아웃
            2. 어플리케이션을 종료
         */
        private void Quit(object sender, FormClosedEventArgs e)
        {
            user.Logout();
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
