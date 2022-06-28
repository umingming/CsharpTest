using System;
using System.Collections;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.View
{
    /*
        CategoryForm
        1. All 클릭시 모든 카테고리 선택
        2. 해당 카테고리 값 할당; ToString으로 받아올 수 있는가?
            > Text와 Value 분리
            > 선택된 값들을 문자열로 변환
            > 카테고리 리스트 설정
     */
    public partial class CategoryForm : Form
    {
        Notification box;

        public CategoryForm()
        {
            box = new Notification(); 
            InitializeComponent();
        }

        /*
            InitCklCate
            1. 카테고리 리스트 텍스와 값 명시
            2. 값 할당 후 지정
         */
        private void InitCklCate(object sender, EventArgs e)
        {
            cklLike.DisplayMember = "Text";
            cklLike.ValueMember = "Value";

            cklLike.Items.Insert(0, new { Text = "한식", Value = "39" });
            cklLike.Items.Insert(1, new { Text = "중식", Value = "40" });
            cklLike.Items.Insert(2, new { Text = "일식", Value = "41" });
            cklLike.Items.Insert(3, new { Text = "양식", Value = "42" });
            cklLike.Items.Insert(4, new { Text = "기타", Value = "43" });

            cklDislike.DisplayMember = "Text";
            cklDislike.ValueMember = "Value";

            cklDislike.Items.Insert(0, new { Text = "한식", Value = "39" });
            cklDislike.Items.Insert(1, new { Text = "중식", Value = "40" });
            cklDislike.Items.Insert(2, new { Text = "일식", Value = "41" });
            cklDislike.Items.Insert(3, new { Text = "양식", Value = "42" });
            cklDislike.Items.Insert(4, new { Text = "기타", Value = "43" });
        }

        /*
            SelectCategory
            1. 선택된 카테고리 리스트에 할당
            2. 해당 리스트 문자열 설정에 저장
            3. 레스토랑 객체 생성 후 추천 폼 보여주기
         */
        private void SelectCategroy(object sender, EventArgs e)
        {
            ArrayList categorys = new ArrayList();

            if(cklLike.SelectedItems.Count == 0 && !chkLikeAll.Checked)
            {
                box.DisplayWarning("카테고리");
                return;
            }

            for(int i=0; i<cklLike.Items.Count; i++)
            {
                if (cklLike.GetItemChecked(i))
                {
                    string category = cklLike.Items[i].ToString();
                    string value = category.Substring(category.LastIndexOf('=') + 2, 2);
                    categorys.Add(value);
                }
            }
            Properties.Settings.Default.CategoryList = string.Join<object>(",", categorys.ToArray());

            Restaurant restaurant = new Restaurant();
            restaurant.InitRecommendList();

            restaurant = restaurant.Recommend();
            if (restaurant == null)
            {
                box.DisplaySimpleInfo("추천 가능한 식당이 존재하지 않습니다.");
                return;
            }

            this.Visible = false;
            new RecommendForm(restaurant).ShowDialog();
        }

        /*
            CheckAll; 모두 선택
            1. 전체 선택 여부 판단해 초기화함.
            2. for문 체크리스트 아이템 반복
                > 해당 박스를 체크 설정
         */
        private void LikeAll(object sender, EventArgs e)
        {
            if (chkDislikeAll.Checked)
            {
                chkDislikeAll.Checked = !chkLikeAll.Checked;
            }

            for(int i=0; i<cklLike.Items.Count; i++)
            {
                cklLike.SetItemChecked(i, chkLikeAll.Checked);

                if(cklDislike.GetItemChecked(i))
                {
                    cklDislike.SetItemChecked(i, false);
                }
            }
        }

        /*
            DislikeAll; All 버튼 클릭으로 비선호 할당;
         */
        private void DislikeAll(object sender, EventArgs e)
        {
            if (chkLikeAll.Checked)
            {
                chkLikeAll.Checked = !chkDislikeAll.Checked;
            }

            for (int i=0; i<cklDislike.Items.Count; i++)
            {
                cklDislike.SetItemChecked(i, chkDislikeAll.Checked);

                if (cklLike.GetItemChecked(i))
                {
                    cklLike.SetItemChecked(i, false);
                }
            }
        }

        /*
            ShowList
            1. 리스트 폼 호출
         */
        private void ShowList(object sender, EventArgs e)
        {
            this.Visible = false;
            new ListForm().ShowDialog();
        }

        /*
            RecommendLunch; 점심추천 메뉴로 이동
            1. 카테고리 폼 생성
         */
        private void RecommendLunch(object sender, EventArgs e)
        {
            this.Visible = false;
            new CategoryForm().ShowDialog();
        }

        /*
            Logout
            1. 로그아웃
            2. 로그인 화면으로 이동
         */
        private void Logout(object sender, EventArgs e)
        {
            new User().Logout();
            this.Visible = false;
            new LoginForm().ShowDialog();
        }

        /*
            ShowMain
            1. 메인으로 이동
         */
        private void ShowMain(object sender, EventArgs e)
        {
            this.Visible = false;
            new MainForm().ShowDialog();
        }

        /*
            Quit
            1. 로그아웃
            2. 어플리케이션을 종료
         */
        private void Quit(object sender, FormClosedEventArgs e)
        {
            new User().Logout();
            Application.Exit();
        }

        /*
            ProcessCmdKey; 오버로딩
         */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*
            DislikeOnlyByCheck
            1. if문 비선호 카테고리 체크될 예정인지?
                > 선호 내 해당 카테고리 체크 해제
                > 체크 해제될 경우, 전체 체크박스가 선택되어 있는지
                    > 전체 체크박스 해제
         */
        private void DislikeOnlyByCheck(object sender, ItemCheckEventArgs e)
        {
            if (!cklDislike.GetItemChecked(e.Index))
            {
                cklLike.SetItemChecked(e.Index, false);
            }
            else
            {
                if (chkDislikeAll.Checked)
                {
                    chkDislikeAll.Checked = false;
                }
            }
        }

        /*
            LikeOnlyByCheck
            1. if문 선호 카테고리 체크될 예정인지?
                > 비선호 내 해당 카테고리 체크 해제
                > 체크 해제될 경우, 전체 체크박스가 선택되어 있는지
                    > 전체 체크박스 해제
         */
        private void LikeOnlyByCheck(object sender, ItemCheckEventArgs e)
        {
            if (!cklLike.GetItemChecked(e.Index))
            {
                cklDislike.SetItemChecked(e.Index, false);
            }
            else
            {
                if (chkLikeAll.Checked)
                {
                    chkLikeAll.Checked = false;
                }
            }
        }

        /*
            SelectCateByEnterKeyDown
            1. if문 입력 키가 엔터가 아닌지?
                > return
            2. 카테고리 설정
         */
        private void SelectCateByEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            SelectCategroy(sender, e);
        }
    }
}
