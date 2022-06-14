using System;
using System.Windows.Forms;

namespace ClientWithRoom
{
    /*
        MainForm
        - Port와 IP를 입력 받아 서버에 연결할 것
     */
    public partial class MainForm : Form
    {
        private Client client;
        private Notification box;

        public MainForm()
        {
            box = new Notification();
            InitializeComponent();
        }

        /*
            Start 메소드; start 버튼을 클릭하면 서버에 접속
            1. ip와 port 변수 선언 후 해당 텍스트를 초기화
            2. if문 port가 범위 내인지?
                > ip, port를 매개로 Connect 호출
                > 범위 내가 아니면 FormatException 예외 생성
            3. 예외 처리; box 객체의 Display 메소드 사용
                > 잘못된 port 번호; 범위 내의 숫자가 아니거나, 서버가 열리지 않음.
                > IP가 올바르지 않은 경우
                > 그 외 오류
         */
        private void Start(object sender, EventArgs e)
        {
            try
            {
                String ip = txtIp.Text;
                int port = Convert.ToInt32(txtPort.Text);
                if(port < 0 || port > 65535) throw new FormatException();

                client = new Client(ip, port);
                if (!client.IsConnected()) return;

                (new NameForm(client)).Show();
                this.Visible = false;
            }
            catch (FormatException)
            {
                box.DisplayWarning("Port 번호");
            }
            catch (Exception)
            {
                box.DisplayError();
            }
        }

        /*
            EnterMsgByEnterKeyDown; port 박스에서 엔터를 누를 경우 실행시킴
            1. if문 입력 키가 엔터가 아닌지?
                > return
            2. Start 호출
         */
        private void StartByEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Start(sender, e);
        }
    }
}
