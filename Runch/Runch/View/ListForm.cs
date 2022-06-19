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
        ListForm; 레스토랑 목록
        1. 레스토랑 목록 나열
        2. 셀 클릭시 레스토랑 정보 출력
        3. 조회와 수정 버튼으로 폼 생성
     */
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }

        /*
            ListRestaurant
            1. DataGridView에 레스토랑 목록 데이터셋 할당
         */
        private void ListRestaurant(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dataSet1.VWRESTAURANTSIMPLEINFO' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.vWRESTAURANTSIMPLEINFOTableAdapter.Fill(this.dataSet1.VWRESTAURANTSIMPLEINFO);
            dgvRestaurant.DataSource = new Restaurant().List().Tables[0].DefaultView;
        }

        /*
            ShowDetail
            1. 클릭한 셀의 레스토랑Id를 변수에 초기화
            2. 해당 Id로 찾은 레스토랑을 인자로 Detail 폼 호출
         */
        private void ShowDetail(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvRestaurant.CurrentRow.Cells[0].Value.ToString());
            new DetailForm(new Restaurant().FindById(id)).Show();
        }

        /*
            SelectRowByClick
            1. 셀 클릭으로 로우 선택
         */
        private void SelectRowByClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRestaurant.CurrentRow.Selected = true;
        }



        /*
            AddRestaurant
            1. 레스토랑 추가 폼 호출
         */
        private void AddRestaurant(object sender, EventArgs e)
        {
            new AddForm().Show();
        }

        /*
            SearchRestaurant
            1. 레스토랑 검색 폼 호출
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
