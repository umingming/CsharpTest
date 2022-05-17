using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace BytePacketClient
{
    /*
        ChatForm
        - 메시지를 입력 받고 서버와 통신 내용을 텍스트 박스에 출력
     */
    public partial class ChatForm : Form
    {
        Client client;
        ArrayList msgList;
        Notification box;

        int max;

        public ChatForm(Client client)
        {
            this.client = client;
            msgList = new ArrayList(200);
            box = new Notification();

            Thread msgThread = new Thread(() => ReceiveMsg());
            msgThread.IsBackground = true;
            msgThread.Start();
            InitializeComponent();
        }

        /*
            EnterMsg
            1. if문 max가 0인지?
                > 최대 메시지 갯수 설정 경고 
                > SelectMax 호출 후 리턴함.
            2. if문 텍스트가 존재 안 하는지?
                > 메시지 입력 경고 후 리턴
            3. SetMsg 호출함.
         */
        private void EnterMsg(object sender, EventArgs e)
        {
            if (max == 0)
            {
                box.DisplayWarning("최대 메시지 갯수");
                SelectMax(sender, e);
                return;
            }
            else if ((txtMsg.Text).Equals(""))
            {
                box.DisplayWarning("입력 메시지");
                return;
            }
            SendMsg();
        }

        /*
            SelectMax
            1. cmbMax에 포커싱함.
            2. 콤보 박스의 리스트 열기
            3. 스타일을 DropDownList로 변경
         */
        private void SelectMax(object sender, EventArgs e)
        {
            cmbMax.Select();
            cmbMax.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMax.DroppedDown = true;  
        }

        /*
            SelectMax; 마우스 클릭 이벤트라 오버로딩함.
         */
        private void SelectMax(object sender, MouseEventArgs e)
        {
            cmbMax.Select();
            cmbMax.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMax.DroppedDown = true;  
        }

        /*
            SetMax; 콤보박스의 선택 값에 따라 메시지 보관 갯수를 설정함.
            1. 콤보 박스 값을 int로 변환해 max 변수에 초기화함.
            2. UpdateChat 호출
            3. 메시지 입력으로 포커스 이동
         */
        private void SetMax(object sender, EventArgs e)
        {
            max = Convert.ToInt32(cmbMax.SelectedItem);

            UpdateChat();
            txtMsg.Select();
        }

        /*
            SendMsg
            1. 입력 텍스트를 인자로 SendMsg 호출
            2. 텍스트 초기화
         */
        private void SendMsg()
        {
            client.SendMsg(txtMsg.Text);
            txtMsg.Text = "";
        }

        /*
            ReceiveMsg
            1. msg 선언
            2. while문 ReceiveMsg의 반환 값을 msg에 초기화하고, 존재하는지를 조건으로 반복함.
                > msg를 List에 추가함.
                > SetRtx 호출
            3. UpdateChat() 호출
         */
        private void ReceiveMsg()
        {
            var msg = "";
            while((msg = client.ReceiveMsg()) != null)
            {
                msgList.Add(msg);
                AddToRtx(rtxChat, msg);
                UpdateChat();   
            }
        }

        /*
            UpdateChat; 범위 내의 최신 대화를 보여줄 것.
            1. if문 메시지 리스트의 수가 최대값을 초과하는지?
                > list의 0번째 요소부터 초과하는 만큼 삭제함.
                > 채팅 박스 초기화
                > for문 리스트 크기 반복
                    > list의 요소를 채팅 박스에 추가함.
            2. 채팅 박스의 캐럿 위치를 문자열 끝으로 설정
            3. 스크롤을 밑로 이동함.
         */
        private void UpdateChat()
        {
            if (msgList.Count > max)
            {
                msgList.RemoveRange(0, msgList.Count - max);
                ClearRtx(rtxChat);

                for (int i = 0; i < msgList.Count; i++)
                {
                    AddToRtx(rtxChat, (string)msgList[i]);
                }
            }
            UpdateRtx(rtxChat);
        }

        /*
            AddRtx; 
            1. if문 컨트롤에 접근하는 스레드가, 컨트롤 생성 스레드가 아닌지 판별
            2. 박스에 해당 메시지를 추가함.
         */
        public static void AddToRtx(RichTextBox rtx, string msg)
        {
            if (rtx.InvokeRequired)
            {
                rtx.Invoke(new MethodInvoker(delegate
                {
                    rtx.Text += msg + "\n";
                }));
            }
            else
            {
                rtx.Text += msg + "\n";
            }
        }

        /*
            UpdateRtx
            1. if문 컨트롤에 접근하는 스레드가, 컨트롤 생성 스레드가 아닌지 판별
            2. 채팅 박스의 캐럿 위치를 문자열 끝으로 설정
            3. 스크롤을 밑로 이동함.
         */
        public static void UpdateRtx(RichTextBox rtx)
        {
            if (rtx.InvokeRequired)
            {
                rtx.Invoke(new MethodInvoker(delegate
                {
                    rtx.SelectionStart = rtx.Text.Length;
                    rtx.ScrollToCaret();
                }));
            }
            else
            {
                rtx.SelectionStart = rtx.Text.Length;
                rtx.ScrollToCaret();
            }
        }

        /*
            ClearRtx; Rtx 초기화
            1. if문 컨트롤에 접근하는 스레드가, 컨트롤 생성 스레드 인지 판별
            2. rtx 비움.
         */
        public static void ClearRtx(RichTextBox rtx)
        {
            if (rtx.InvokeRequired)
            {
                rtx.Invoke(new MethodInvoker(delegate
                {
                    rtx.Text = "";
                }));
            }
            else
            {
                rtx.Text = "";
            }
        }

        /*
            EnterMsgByEnterKeyDown
            1. if문 입력 키가 엔터아니면 리턴함.
            2. EnterMsg 호출
         */
        private void EnterMsgByEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            EnterMsg(sender, e);
        }

        /*
            Quit
            1. 어플리케이션을 종료함.
         */
        private void Quit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            client.Close();
        }
    }
}
