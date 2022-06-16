using System;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.View
{
    /*
        AddForm; 레스토랑 추가
        1. 카테고리 설정
        2. X 버튼으로 창 닫기
        3. 
     */
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        /*
            초기 설정
            1. 카테고리 텍스트와 값 분리
            2. 해당 배열 콤보 박스에 할당
         */
        private void AddForm_Load(object sender, EventArgs e)
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
        }

        /*
            레스토랑 추가
            1. 객체 생성 후 값 초기화
            2. Add 메소드 호출
         */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.name = txtName.Text;
            restaurant.categoryId = Int32.Parse(cmbCategory.SelectedValue.ToString());
            restaurant.signature = txtSignature.Text;
            restaurant.Add();
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
