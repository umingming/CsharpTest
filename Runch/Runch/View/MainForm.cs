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
        MainForm
        1. 사용자 정보 안내
        2. 원하는 페이지로 이동
      */
    public partial class MainForm : Form
    {
        User user;

        public MainForm(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        /*
            InitUserInfo
            1. 사용자 정보를 초기화함.
         */
        private void InitUserInfo(object sender, EventArgs e)
        {
            btnUser.Text = user.name + "님";
        }
    }
}
