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
        Notification box;

        public AddForm()
        {
            box = new Notification();
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
            레스토랑 추가
            1. 객체 생성 후 값 초기화
            2. Add 메소드 호출
         */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "")
            {
                box.DisplayWarning("식당명");
                txtName.Focus();
                return;
            }

            if (cmbCategory.Text == "")
            {
                box.DisplayWarning("카테고리");
                cmbCategory.Focus();
                cmbCategory.DroppedDown = true;
                return;
            }

            if (txtSignature.Text == "")
            {
                box.DisplayWarning("추천 메뉴");
                txtSignature.Focus();
                return;
            }

            Restaurant restaurant = new Restaurant();
            restaurant.name = txtName.Text;
            restaurant.categoryId = Int32.Parse(cmbCategory.SelectedValue.ToString());
            restaurant.signature = txtSignature.Text;
            restaurant.Add();

//            MessageBox.Show(this.ParentForm + "");
//            new ListForm().Show();
            this.Close();
        }

        /*
            AddByEnterKeyDown
            1. if문 입력 키가 엔터가 아닌지?
                > return
            2. Add 호출
         */
        private void AddByEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnAdd_Click(sender, e);
        }

        /*
            화면 닫기
         */
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
            InvalidateInput;키 입력 막음
            1. 키 입력 이벤트 true로
         */
        private void InvalidateInput(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
