﻿using System;
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
        RecommendForm; 선택한 카테고리를 바탕으로 식당 추천
        1. 식당 리스트 초기화
        2. 그 중 하나를 선정함.
     */
    public partial class RecommendForm : Form
    {
        Restaurant restaurant;
        Restaurant recommend;

        public RecommendForm(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
        }

        /*
            RecommendLunch; 점심 추천
            1. 레스토랑 추천 받음.
            2. 텍스트 초기화
         */
        private void RecommendLunch(object sender, EventArgs e)
        {
            recommend = restaurant.Recommend();
            txtName.Text = recommend.name;
            txtCategory.Text += recommend.category;
            txtSignature.Text = recommend.signature;
            txtAdoption.Text = recommend.cntAdoption.ToString();
        }

        /*
            AgainRecommend; 재추천
            1. 레스토랑을 인자로 다시 폼 생성
         */
        private void AgainRecommend(object sender, EventArgs e)
        {
            new RecommendForm(restaurant).Show();
            this.Visible = false;
        }

        /*
            AdoptRestaurant; 레스토랑 채택
            1. 추천 받은 레스토랑의 adopt 메소드 호출해 채택함.
            2. recommend를 인자로 AdoptionForm 호출
         */
        private void AdoptRestaurant(object sender, EventArgs e)
        {
            recommend.Adopt();
            new AdoptionForm(recommend).Show();
            this.Visible = false;
        }

        /*
            ShowList
            1. 리스트 폼 호출
         */
        private void ShowList(object sender, EventArgs e)
        {
            new ListForm().Show();
            this.Visible = false;
        }

        /*
            SelectCategory; 점심추천 메뉴로 이동
            1. 카테고리 폼 생성
         */
        private void SelectCategory(object sender, EventArgs e)
        {
            new CategoryForm().Show();
            // this.Visible = false;
        }

        /*
            Logout
            1. 로그아웃
            2. 로그인 화면으로 이동
         */
        private void Logout(object sender, EventArgs e)
        {
            new User().Logout();
            new LoginForm().Show();
            this.Visible = false;
        }

        /*
            ShowMain
            1. 메인으로 이동
         */
        private void ShowMain(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Visible = false;
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
