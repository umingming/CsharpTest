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

namespace Runch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox1.Width, textBox1.Height, 33, 33));
            pictureBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox1.Width, pictureBox1.Height, 33, 33));
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 5, 5));
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 5, 5));
        }
    }
}
