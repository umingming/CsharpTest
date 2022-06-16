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
        DetailForm; 레스토랑 상세 화면
        1. 텍스트 박스에 해당하는 값 할당
        2. 레스토랑 차단 관리
     */
    public partial class DetailForm : Form
    {
        Restaurant restaurant;

        public DetailForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        /*
            기본 화면
            1. 이름, 카테고리, 시그니처, 채택 수, 최근 채택 일자 텍스트 초기화
         */
        private void DetailForm_Load(object sender, EventArgs e)
        {
            txtName.Text = restaurant.name;
            txtCategory.Text += restaurant.category;
            txtSignature.Text = restaurant.signature;
            txtAdoption.Text = restaurant.cntAdoption.ToString();
            txtRecentAdoption.Text = restaurant.recentAdoption;
        }

        /*
            레스토랑 블락
            1. 블락 호출
         */
        private void btnBlock_Click(object sender, EventArgs e)
        {
            restaurant.Block();
        }

        /*
            레스토랑 편집
            1. 편집 폼 호출
         */
        private void btnEdit_Click(object sender, EventArgs e)
        {
            new EditForm(restaurant).Show();
            this.Close();
        }

        /*
            화면 닫기
         */
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
