using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Runch.Domain
{
    internal class Notification
    {
        public void DisplayWarning(string text)
        {
            MessageBox.Show(text + "(을)를 확인해주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void DisplaySimpleWarning(string text)
        {
            MessageBox.Show(text + "입니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void DisplayInfo(string text)
        {
            MessageBox.Show(text + "입니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DisplaySimpleInfo(string text)
        {
            MessageBox.Show(text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
