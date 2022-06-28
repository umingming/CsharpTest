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
        SearchListForm; 레스토랑 검색 목록
        1. 조건에 따른 레스토랑 목록 나열
        2. 클릭시 상세 화면으로 이동
        3. 버튼으로 추가 또는 검색
     */
    public partial class SearchListForm : Form
    {
        Restaurant restaurant;

        public SearchListForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        /*
            ListRestaurant
            1. 검색 조건을 토대로 dataGridView 초기화
         */
        private void ListRestaurant(object sender, EventArgs e)
        {
            dgvRestaurant.DataSource = restaurant.Search().Tables[0].DefaultView;
            dgvRestaurant.Columns[0].HeaderText = "No.";
            dgvRestaurant.Columns[0].Width = 40;
            dgvRestaurant.Columns[1].HeaderText = "     식당명";
            dgvRestaurant.Columns[1].Width = 100;

            if(dgvRestaurant.Rows.Count > 0)
            {
                dgvRestaurant.Rows[0].Selected = false;
            }
            else
            {
                txtEmpty.Visible = true;
            }
        }

        /*
            SelectRowByClick
            1. 셀 클릭으로 로우 선택
         */
        private void SelectRowByClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRestaurant.CurrentRow.Selected = true;
            ShowDetail(sender, e);
        }

        /*
            ShowDetail
            1. 클릭한 셀의 레스토랑 아이디 값을 변수에 초기화
            2. 해당 레스토랑을 인자로 디테일 폼 생성
         */
        private void ShowDetail(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvRestaurant.CurrentRow.Cells[0].Value.ToString());
            new DetailForm(new Restaurant().FindById(id)).ShowDialog();
            //new SearchListForm(restaurant).Show();
            //this.Visible = false;
        }

        /*
            SearchRestaurant
            1. SearchForm 호출
         */
        private void SearchRestaurant(object sender, EventArgs e)
        {
            new SearchForm().ShowDialog();
            this.Visible = false;
        }

        /*
            ShowList
            1. 리스트 폼 호출
         */
        private void ShowList(object sender, EventArgs e)
        {
            this.Visible = false;
            new ListForm().Show();
        }

        /*
            RecommendLunch; 점심추천 메뉴로 이동
            1. 카테고리 폼 생성
         */
        private void RecommendLunch(object sender, EventArgs e)
        {
            this.Visible = false;
            new CategoryForm().Show();
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
            new LoginForm().Show();
        }

        /*
            ShowMain
            1. 메인으로 이동
         */
        private void ShowMain(object sender, EventArgs e)
        {
            this.Visible = false;
            new MainForm().Show();
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
    }
}
