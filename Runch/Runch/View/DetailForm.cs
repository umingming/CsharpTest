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
        Notification box;
        Boolean isEdited = false;

        public DetailForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            this.box = new Notification();
            InitializeComponent();
        }

        /*
            기본 화면
            1. 이름, 카테고리, 시그니처, 채택 수, 최근 채택 일자 텍스트 초기화
         */
        private void DetailForm_Load(object sender, EventArgs e)
        {
            if(restaurant.IsBlock())
            {
                btnUnblock.Visible = true;
                btnBlock.Visible = false;
                btnBlockTxt.Text = "차단 해제";
            }
            txtName.Text = restaurant.name;
            txtCategory.Text = "/ " + restaurant.category;
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
            if(btnUnblock.Visible)
            {
                btnUnblock_Click(sender, e);
                return;
            }

            restaurant.Block();
            btnUnblock.Visible = true;
            btnBlock.Visible = false;
            btnBlockTxt.Text = "차단 해제";
            box.DisplaySimpleInfo($@"[{restaurant.name}]이(가) 차단되었습니다.");
        }

        /*
            레스토랑 언블락
            1. 언블락 호출
         */
        private void btnUnblock_Click(object sender, EventArgs e)
        {
            restaurant.Unblock(); 
            btnUnblock.Visible = false;
            btnBlock.Visible = true;
            btnBlockTxt.Text = "차단";
            box.DisplaySimpleInfo($@"[{restaurant.name}]이(가) 차단 해제되었습니다.");
        }

        /*
            레스토랑 편집
            1. 편집 폼 호출
         */
        private void btnEdit_Click(object sender, EventArgs e)
        {
            new EditForm(restaurant).ShowDialog();
            Restaurant newRestaurant = new Restaurant().FindById(restaurant.id);
            restaurant = newRestaurant;
            txtName.Text = newRestaurant.name;
            txtCategory.Text = "/ " + newRestaurant.category;
            txtSignature.Text = newRestaurant.signature;
            txtAdoption.Text = restaurant.cntAdoption.ToString();
            txtRecentAdoption.Text = restaurant.recentAdoption;
            isEdited = true;
            //this.Close();
        }

        /*
            레스토랑 삭제
            1. 삭제하기
         */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            restaurant.Delete();
            this.Close();
            box.DisplaySimpleInfo($@"[{restaurant.name}]이(가) 삭제되었습니다.");
        }

        /*
            화면 닫기
         */
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isEdited)
            {
                this.Close();
            }

            this.Visible = false;
        }
    }
}
