using System;
using System.Drawing;
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
            try
            {
                Convert.ToInt32(txtId.Text);

                if (txtId.Text.Equals(""))
                {
                    box.DisplayWarning("사원 번호 입력");
                    txtId.Focus();
                    return;
                }

                if(user.IsValid(txtId.Text))
                {
                    box.DisplaySimpleWarning("등록된 사용자");
                    txtId.Focus();
                    return;
                }

                user.id = txtId.Text;
                btnIdUnChecked.Visible = false;
                isIdChecked = true;

                box.DisplayInfo("등록 가능한 사원 번호");
            }
            catch (FormatException)
            {
                box.DisplayWarning("사원 번호");
                txtId.Focus();
            }
        }

        /*
            InitIdByClick
            1. 텍스트 초기화
         */
        private void InitIdByClick(object sender, EventArgs e)
        {
            txtId.Text = "";
        }

        /*
            InitNameByClick
            1. 텍스트 초기화
         */
        private void InitNameByClick(object sender, EventArgs e)
        {
            txtName.Text = "";
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
                    txtId.Focus();
                    return;
                }

                if(txtName.Text == "이름")
                {
                    box.DisplayWarning("이름");
                    txtName.Focus();
                    return;
                }

                if(cmbGroup.SelectedIndex == 0)
                {
                    box.DisplayWarning("소속");
                    cmbGroup.Focus();
                    return;
                }

                if(cmbPosition.SelectedIndex == 0)
                {
                    box.DisplayWarning("직위");
                    cmbPosition.Focus();
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

        /*
            SelectGroup
            1. cmbGroup에 포커싱함.
            2. 콤보 박스의 리스트 열기
            3. 스타일을 DropDownList로 변경
         */
        private void ShowGroup(object sender, EventArgs e)
        {
            cmbGroup.Select();
            cmbGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGroup.DroppedDown = true;
        }

        /*
            SelectGroup; 마우스 클릭 이벤트라 오버로딩함.
         */
        private void ShowGroup(object sender, MouseEventArgs e)
        {
            cmbGroup.Select();
            cmbGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGroup.DroppedDown = true;
        }

        /*
            Quit
            1. 어플리케이션을 종료
         */
        private void Quit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /*
            ProcessCmdKey; 오버로딩
         */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
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
