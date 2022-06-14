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
    public partial class LoginForm : Form
    {
        User user;

        public LoginForm()
        {
            user = new User();
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
                return;
            }
            if (user.Login(txtId.Text) == 0)
            {
                return;
            }
            new JoinForm(user).Show();
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
    }

}
