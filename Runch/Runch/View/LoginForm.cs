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
using Runch.View;

namespace Runch
{
    /*
        LoginForm
        1. 사원 번호 밸리데이션 후 로그인
        2. 회원가입으로 이동
     */
    public partial class LoginForm : Form
    {
        User user;
        Notification box;

        public LoginForm()
        {
            user = new User();
            box = new Notification();
            InitializeComponent();
        }

        /*
            Login
            1. if 텍스트가 공백인지?
            2. if 로그인 되는지?
         */
        private void Login(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                box.DisplayWarning("ID 입력");
                txtId.Focus();
                return;
            }

            if (user.Login(txtId.Text) != 0)
            {
                this.Visible = false;
                new MainForm().ShowDialog();
            }
        }

        /*
            Join
            1. 회원가입 창 호출
         */
        private void Join(object sender, EventArgs e)
        {
            new JoinForm().ShowDialog();
        }

        /*
            LoginByEnterKeyDown
            1. if문 입력 키가 엔터가 아닌지?
                > return
            2. Login 호출
         */
        private void LoginByEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Login(sender, e);
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
    }

}
