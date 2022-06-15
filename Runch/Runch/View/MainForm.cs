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

        public MainForm()
        {
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
            btnUser.Text = user.name + "님";
        }

        /*
            RecommendLunch; 점심추천 메뉴로 이동
            1. 카테고리 폼 생성
         */
        private void RecommendLunch(object sender, EventArgs e)
        {
            new CategoryForm().Show();
            this.Visible = false;
        }

        private void ListRestaurant(object sender, EventArgs e)
        {
            new ListForm().Show();
            this.Visible = false;
        }
    }
}
