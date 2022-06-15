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
    }
}
