using System;
using System.Collections;
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
        CategoryForm
        1. All 클릭시 모든 카테고리 선택
        2. 해당 카테고리 값 할당; ToString으로 받아올 수 있는가?
            > Text와 Value 분리
            > 선택된 값들을 문자열로 변환
            > 카테고리 리스트 설정
     */
    public partial class CategoryForm : Form
    {
        Notification box;

        public CategoryForm()
        {
            box = new Notification(); 
            InitializeComponent();
        }

        /*
            InitCklCate
            1. 카테고리 리스트 텍스와 값 명시
            2. 값 할당 후 지정
         */
        private void InitCklCate(object sender, EventArgs e)
        {
            cklCategory.DisplayMember = "Text";
            cklCategory.ValueMember = "Value";

            cklCategory.Items.Insert(0, new { Text = "한식", Value = "16" });
            cklCategory.Items.Insert(1, new { Text = "중식", Value = "17" });
            cklCategory.Items.Insert(2, new { Text = "일식", Value = "18" });
            cklCategory.Items.Insert(3, new { Text = "양식", Value = "19" });
            cklCategory.Items.Insert(4, new { Text = "기타", Value = "20" });
        }

        /*
            SelectCategory
            1. 선택된 카테고리 리스트에 할당
            2. 해당 리스트 문자열 설정에 저장

         */
        private void SelectCategroy(object sender, EventArgs e)
        {
            ArrayList categorys = new ArrayList();

            for(int i=0; i<cklCategory.Items.Count; i++)
            {
                if (cklCategory.GetItemChecked(i))
                {
                    string category = cklCategory.Items[i].ToString();
                    string value = category.Substring(category.LastIndexOf('=') + 2, 2);
                    categorys.Add(value);
                }
            }

            Properties.Settings.Default.CategoryList = string.Join<object>(",", categorys.ToArray());

            Restaurant restaurant = new Restaurant();
            restaurant.InitRecommendList();

            new RecommendForm(restaurant).Show();
            this.Visible = false;
        }

        /*
            CheckAll; 모두 선택
            1. 전체 선택 여부 판단 해 초기화함.
            2. for문 체크리스트 아이템 반복
                > 해당 박스를 체크 설정
         */
        private void CheckAll(object sender, EventArgs e)
        {
            bool isAllChecked = chkAll.Checked;

            for(int i=0; i<cklCategory.Items.Count; i++)
            {
                cklCategory.SetItemChecked(i, isAllChecked);
            }
        }
    }
}
