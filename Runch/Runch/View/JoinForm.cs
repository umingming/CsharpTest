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
        User user;

        public JoinForm(User user)
        {
            this.user = user;
            InitializeComponent();
        }
    }
}
