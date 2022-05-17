using System;
using System.Collections;
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

            SetMsg();
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
            SetMsg
            1. 발신 메시지를 형식화 해서 msg 변수에 초기화함.
            2. msg를 매개로 AddMsg 호출함.
            3. Communicate 호출
            4. txtMsg의 텍스트 비우기
         */
        private void SetMsg()
        {
            String msg = String.Format("나: {0} [{1}]\n"
                                        , txtMsg.Text
                                        , DateTime.Now.ToString("HH:mm:ss"));
            AddMsg(msg);
            Communicate();
            txtMsg.Text = "";
        }

        /*
            Communicate
            1. byte 배열 생성 후, msg 저장
            2. msg를 서버에 전송
            3. byte 배열 초기화
            4. 서버로부터 받은 메시지를 변환해 echo 변수에 초기화
            5. if문 echo가 null이 아닌지?
                > AddMsg 호출
         */
        private void Communicate()
        {
            String echo = client.Echo(txtMsg.Text);

            if (echo != null)
            {
                AddMsg(echo + "\n");
            }
        }
        
        /*
            AddMsg
            1. echo를 msgList와 콤보 박스, 대화 내용에 추가함.
            2. UpdateChat 호출
         */
        private void AddMsg(String msg)
        {
            msgList.Add(msg);
            rtxChat.Text += msg;

            UpdateChat();
        }

        /*
            UpdateChat; 범위 내의 최신 대화를 보여줄 것.
            1. if문 메시지 리스트의 수가 최대값을 초과하는지?
                > list의 0번째 요소부터 초과하는 만틈 삭제함.
                > 채팅 박스 초기화
                > for문 리스트 크기 반복
                    > list의 요소를 채팅 박스에 추가함.
            2. 채팅 박스의 캐럿 위치를 문자열 끝으로 설정
            3. 스크롤을 미틍로 이동함.
         */
        private void UpdateChat()
        {
            if (msgList.Count > max)
            {
                msgList.RemoveRange(0, msgList.Count - max);
                rtxChat.Text = "";

                for (int i = 0; i < msgList.Count; i++)
                {
                    rtxChat.Text += msgList[i];
                }
            }

            rtxChat.SelectionStart = rtxChat.Text.Length;
            rtxChat.ScrollToCaret();
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
            IsEnterKey
            1. if문 입력 키가 엔터인지?
                > EnterMsg 호출
         */
        private void IsEnterKey(object sender, KeyEventArgs e)
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
        }
    }
}
