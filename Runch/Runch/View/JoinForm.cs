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
        }
    }
}
