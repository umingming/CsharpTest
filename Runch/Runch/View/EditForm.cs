﻿using System;
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
        EditForm; 레스토랑 편집
        1. 편집 전 내용 안내
        2. 버틀 클릭시, 레스토랑 수정
     */
    public partial class EditForm : Form
    {
        Restaurant restaurant;

        public EditForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        /*
            편집 창
            1. 콤보박스의 텍스트와 값 분리
            2. 배열 할당
         */
        private void EditForm_Load(object sender, EventArgs e)
        {
            cmbCategory.DisplayMember = "Text";
            cmbCategory.ValueMember = "Value";

            var categories = new[] {
                new { Text = " 한식", Value = "16" },
                new { Text = " 중식", Value = "17" },
                new { Text = " 일식", Value = "18" },
                new { Text = " 양식", Value = "19" },
                new { Text = " 기타", Value = "20" },
            };
            cmbCategory.DataSource = categories;
            cmbCategory.Text = "";

            txtName.Text = restaurant.name;
            cmbCategory.Text = " " + restaurant.category;
            txtSignature.Text = restaurant.signature;
        }

        /*
            레스토랑 편집
            1. 수정된 내용으로 레스토랑 변수 초기화
            2. Edit 메소드 호출해 데이터 수정
         */
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Restaurant newRestaurant = new Restaurant();
            newRestaurant.name = txtName.Text;
            newRestaurant.categoryId = Int32.Parse(cmbCategory.SelectedValue.ToString());
            newRestaurant.signature = txtSignature.Text;
            restaurant.Edit(newRestaurant);

            new DetailForm(new Restaurant().FindById(restaurant.id)).Show();
            this.Close();
        }

        /*
            창 닫기
         */
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
            EditByEnterKeyDown
            1. if문 입력 키가 엔터가 아닌지?
                > return
            2. 수정 
         */
        private void EditByEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnEdit_Click(sender, e);
        }
    }
}
