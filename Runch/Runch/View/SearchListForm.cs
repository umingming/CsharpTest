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
        }

        /*
            ShowDetail
            1. 클릭한 셀의 레스토랑 아이디 값을 변수에 초기화
            2. 해당 레스토랑을 인자로 디테일 폼 생성
         */
        private void ShowDetail(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvRestaurant.CurrentRow.Cells["No"].Value.ToString());
            new DetailForm(new Restaurant().FindById(id)).Show();
        }

        /*
            AddRestaurant
            1. AddForm 호출
         */
        private void AddRestaurant(object sender, EventArgs e)
        {
            new AddForm().Show();
        }

        /*
            SearchRestaurant
            1. SearchForm 호출
         */
        private void SearchRestaurant(object sender, EventArgs e)
        {
            new SearchForm().Show();
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
