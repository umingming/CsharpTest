using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.View
{
    /*
        ListForm; 레스토랑 목록
        1. 레스토랑 목록 나열
        2. 셀 클릭시 레스토랑 정보 출력
        3. 조회와 수정 버튼으로 폼 생성
     */
    public partial class ListForm : Form
    {
        Thread listThread;

        public ListForm()
        {
            listThread = new Thread(() => ListRestaurant());
            listThread.IsBackground = true;
            InitializeComponent();
        }

        /*
         */
        private void LoadForm(object sender, EventArgs e)
        {
            listThread.Start();
        }

        /*
            ListRestaurant
            1. DataGridView에 레스토랑 목록 데이터셋 할당
         */
        private void ListRestaurant()
        {
            // TODO: 이 코드는 데이터를 'dataSet1.VWRESTAURANTSIMPLEINFO' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.

            if (dgvRestaurant.Columns.Count > 0)
            {
               UpdateDgv(dgvRestaurant);
            }
            dgvRestaurant.Rows[0].Selected = false;
        }

        /*
            ListRestaurant; 리프레쉬 버튼 클릭시
         */
        private void ListRestaurant(object sender, EventArgs e)
        {
            if (dgvRestaurant.Columns.Count > 0)
            {
                UpdateDgv(dgvRestaurant);
            }
            dgvRestaurant.Rows[0].Selected = false;
        }

        public static void UpdateDgv(DataGridView dgv)
        {
            if (dgv.InvokeRequired)
            {
                dgv.Invoke(new MethodInvoker(delegate
                {
                    dgv.DataSource = new Restaurant().List().Tables[0].DefaultView;
                    dgv.DataSource = new Restaurant().List().Tables[0].DefaultView;
                    dgv.Columns[0].HeaderText = "No.";
                    dgv.Columns[0].Width = 40;
                    dgv.Columns[1].HeaderText = "     식당명";
                    dgv.Columns[1].Width = 100;
                }));
            }
            else
            {
                dgv.DataSource = new Restaurant().List().Tables[0].DefaultView;
                dgv.DataSource = new Restaurant().List().Tables[0].DefaultView;
                dgv.Columns[0].HeaderText = "No.";
                dgv.Columns[0].Width = 40;
                dgv.Columns[1].HeaderText = "     식당명";
                dgv.Columns[1].Width = 100;
            }
        }

        /*
            ShowDetail
            1. 클릭한 셀의 레스토랑Id를 변수에 초기화
            2. 해당 Id로 찾은 레스토랑을 인자로 Detail 폼 호출
         */
        private void ShowDetail(object sender, DataGridViewCellEventArgs e)
        {
            SelectRowByClick(sender, e);
            int id = Int32.Parse(dgvRestaurant.CurrentRow.Cells[0].Value.ToString());
            new DetailForm(new Restaurant().FindById(id)).Show();
        }

        /*
            SelectRowByClick
            1. 셀 클릭으로 로우 선택
         */
        private void SelectRowByClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRestaurant.CurrentRow.Selected = true;
        }

        /*
            AddRestaurant
            1. 레스토랑 추가 폼 호출
         */
        private void AddRestaurant(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();

            ListRestaurant();
        }

        /*
            SearchRestaurant
            1. 레스토랑 검색 폼 호출
         */
        private void SearchRestaurant(object sender, EventArgs e)
        {
            new SearchForm().Show();
            //this.Visible = false;
        }

        /*
            ShowList
            1. 리스트 폼 호출
         */
        private void ShowList(object sender, EventArgs e)
        {
            this.Visible = false;
            new ListForm().Show();
        }

        /*
            RecommendLunch; 점심추천 메뉴로 이동
            1. 카테고리 폼 생성
         */
        private void RecommendLunch(object sender, EventArgs e)
        {
            this.Visible = false;
            new CategoryForm().Show();
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
            new LoginForm().Show();
        }

        /*
            ShowMain
            1. 메인으로 이동
         */
        private void ShowMain(object sender, EventArgs e)
        {
            this.Visible = false;
            new MainForm().Show();
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
    }
}
