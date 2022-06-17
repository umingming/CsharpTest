using System;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.View
{
    /*
        JoinForm; 회원가입
        1. 콤보박스 초기화
        2. 회원 존재여부 판별
        3. 입력 값 토대로 사용자 추가
     */
     
    public partial class JoinForm : Form
    {
        Notification box;
        User user;

        Boolean isIdChecked = false;

        public JoinForm()
        {
            box = new Notification();
            user = new User();
            InitializeComponent();
        }

        /*
            InitCmb; 콤보박스 초기화
            1. 원하는 데이터로 배열 생성
            2. 소속과, 직위 콤보박스에 할당
         */
        private void InitCmb(object sender, EventArgs e)
        {
            cmbGroup.DisplayMember = "Text";
            cmbGroup.ValueMember = "Value";
            cmbPosition.DisplayMember = "Text";
            cmbPosition.ValueMember = "Value";

            var groups = new[] {
                new { Text = " 개발1그룹", Value = "2" },
                new { Text = " 개발2그룹", Value = "3" },
                new { Text = " F/W 그룹", Value = "4" },
                new { Text = " WEB/UX그룹", Value = "5" },
            };
            cmbGroup.DataSource = groups;
            cmbGroup.Text = " 소속";

            var positions = new[] {
                new { Text = " 사원", Value = "6" },
                new { Text = " 선임", Value = "7" },
                new { Text = " 책임", Value = "8" },
                new { Text = " 수석보", Value = "9" },
                new { Text = " 수석", Value = "10" },
                new { Text = " 이사", Value = "11" },
                new { Text = " 상무", Value = "12" },
                new { Text = " 전무", Value = "13" },
                new { Text = " 부사장", Value = "14" },
                new { Text = " 사장", Value = "15" },
            };
            cmbPosition.DataSource = positions;
            cmbPosition.Text = " 직위";
        }

        /*
            CheckId
            1. If 아이디를 입력했는지?
            2. if 사용 가능한 사번인지?
         */
        private void CheckId(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                box.DisplayWarning("ID 입력");
                return;
            }

            if(!user.IsValid(txtId.Text))
            {
                user.id = txtId.Text;
                btnIdUnChecked.Visible = false;
            }

            isIdChecked = true;
        }
        
        /*
            Join
            1. 이름, 소속, 직위 설정
            2. 사용자 추가
            3. 로그인 화면으로 이동
         */
        private void Join(object sender, EventArgs e)
        {
            try
            {
                if(isIdChecked == false)
                {
                    box.DisplayWarning("사원번호");
                    return;
                }

                if(txtId.Text == string.Empty || txtId.Text == "사번")
                {
                    box.DisplayWarning("사원번호");
                    txtId.Focus();
                    return;
                }

                user.name = txtName.Text;
                user.groupId = Int32.Parse(cmbGroup.SelectedValue.ToString());
                user.positionId = Int32.Parse(cmbPosition.SelectedValue.ToString());

                user.Add();

                new LoginForm().Show();
                this.Visible = false;

            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
