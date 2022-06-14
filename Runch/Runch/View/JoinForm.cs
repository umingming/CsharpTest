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
    public partial class JoinForm : Form
    {
        Notification box;

        public JoinForm()
        {
            box = new Notification();
            InitializeComponent();
        }

        private void InitCmb(object sender, EventArgs e)
        {
            cmbGroup.DisplayMember = "Text";
            cmbGroup.ValueMember = "Value";
            cmbPosition.DisplayMember = "Text";
            cmbPosition.ValueMember = "Value";

            var groups = new[] {
                new { Text = "소속", Value = "0" },
                new { Text = "개발1그룹", Value = "2" },
                new { Text = "개발2그룹", Value = "3" },
                new { Text = "F/W 그룹", Value = "4" },
                new { Text = "WEB/UX그룹", Value = "5" },
            };
            cmbGroup.DataSource = groups;

            var positions = new[] {
                new { Text = "직위", Value = "0" },
                new { Text = "사원", Value = "6" },
                new { Text = "선임", Value = "7" },
                new { Text = "책임", Value = "8" },
                new { Text = "수석보", Value = "9" },
                new { Text = "수석", Value = "10" },
                new { Text = "이사", Value = "11" },
                new { Text = "상무", Value = "12" },
                new { Text = "전무", Value = "13" },
                new { Text = "부사장", Value = "14" },
                new { Text = "사장", Value = "15" },
            };
            cmbPosition.DataSource = positions;
        }

        /*
            CheckId
            1. If 아이디를 입력했는지?
            2. if 사용 가능한 
         */
        private void CheckId(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                box.DisplayWarning("ID 입력");
                return;
            }

            if(!new User().IsValid(txtId.Text))
            {
                btnIdChecked.BackColor = Color.Green;
            }

            box.DisplayWarning(cmbPosition.SelectedValue.ToString());
        }
    }
}
