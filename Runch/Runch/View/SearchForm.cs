using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.View
{
    /*
        SearchForm
        1. 카테고리 할당
        2. 검색 조건 설정
     */
    public partial class SearchForm : Form
    {
        Notification box;

        public SearchForm()
        {
            box = new Notification();
            InitializeComponent();
        }

        /*
            기본 화면
            1. 콤보박스에 카테고리의 텍스트와 값 할당
         */
        private void SearchForm_Load(object sender, EventArgs e)
        {
            cmbCategory.DisplayMember = "Text";
            cmbCategory.ValueMember = "Value";

            var categories = new[] {
                new { Text = " 한식", Value = "39" },
                new { Text = " 중식", Value = "40" },
                new { Text = " 일식", Value = "41" },
                new { Text = " 양식", Value = "42" },
                new { Text = " 기타", Value = "43" },
            };
            cmbCategory.DataSource = categories;
            cmbCategory.Text = "";
        }

        /*
            레스토랑 검색 조건 설정
            1. 레스토랑 객체 생성
            2. 조건을 토대로 변수 설정
            3. 레스토랑 인자로 SearchListForm 생성
         */
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex < 0)
            {
                box.DisplayWarning("카테고리");
                cmbCategory.DroppedDown = true;
                return;
            }

            if (txtName.Text == "")
            {
                box.DisplayWarning("사용자 이름");
                txtName.Focus();
                return;
            }
            Restaurant restaurant = new Restaurant();
            restaurant.start = dtpStart.Value.ToString().Substring(0, dtpStart.Value.ToString().IndexOf(" ")) + "";
            restaurant.end = dtpEnd.Value.ToString().Substring(0, dtpEnd.Value.ToString().IndexOf(" ")) + "";
            restaurant.categoryId = Int32.Parse(cmbCategory.SelectedValue.ToString());
            restaurant.userName = txtName.Text;

            new SearchListForm(restaurant).Show();
            this.Close();
        }

        /*
            화면 닫기
         */
        private void btnClose_Click(object sender, EventArgs e)
        {
            new ListForm().Show();
            this.Visible = false;
        }

        /*
            InvalidateInput;키 입력 막음
            1. 키 입력 이벤트 true로
         */
        private void InvalidateInput(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        /*
            카테고리 콤보박스 클릭
            1. DroppedDown 이벤트
         */
        private void cmbCategory_Click(object sender, EventArgs e)
        {
            cmbCategory.DroppedDown = true; 
        }

        /*
            SearchByEnterKeyDown
            1. if문 입력 키가 엔터가 아닌지?
                > return
            2. 검색하기
         */
        private void SearchByEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnSearch_Click(sender, e);
        }
    }
}
