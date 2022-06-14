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
        public void DisplayError(string text)
        {
            MessageBox.Show(text + "오류 입니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DisplayError()
        {
            MessageBox.Show("알 수 없는 오류 입니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DisplayWarning(string text)
        {
            MessageBox.Show(text + "(을)를 확인해주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
