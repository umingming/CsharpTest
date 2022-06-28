using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Runch.Data;

namespace Runch.Domain
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public int groupId { get; set; }
        public int positionId { get; set; }

        private DBUtil dbutil;
        private Notification box;

        /*
            생성자 정의
            1. DBUtil 초기화 후 연결
         */
        public User()
        {
            dbutil = DBUtil.This;
            box = new Notification();
        }

        /*
            IsValid
            1. 유저 조회 쿼리 할당
            2. if문 해당 유저가 있는지?
                > id, name 저장
                > true 반환
         */
        public Boolean IsValid(string id)
        {
            string sql = $@"select * from vwUserInfo where user_id = '{id}'";
            using (OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect()))
            {
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader["user_id"].ToString();
                        Properties.Settings.Default.UserId = id;

                        name = reader["name"].ToString();
                        Properties.Settings.Default.UserName = name;

                        Properties.Settings.Default.Save();
                        return true;
                    }
                    return false;
                }
            }
        }

        /*
            Add
            1. insert 쿼리 선언
            2. DB 작업 수행 
         */
        public void Add()
        {
            string sql = $@"insert into users values ('{id}', '{name}', {groupId}, {positionId})";
            using (OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect()))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /*
            IsLoggedIn
            1. 유저 조회 쿼리 할당
            2. if문 값 읽기 
                > if문 유저가 로그인 중인지?
         */
        public Boolean IsLoggedIn()
        {
            string sql = $@"select * from user_log where user_id = '{id}' and rownum = 1 order by user_log_id desc";
            using (OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect()))
            {
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["log_type"].ToString() == "IN") return true;
                    }
                    return false;
                }
            }
        }

        /*
            Login
            1. if문 존재하는 사용자인지
            2. if문 로그인 된 사용자인지
            3. 유저 로그 추가 쿼리 할당
         */
        public int Login(string id)
        {
            this.id = id;

            if (!IsValid(id))
            {
                box.DisplaySimpleWarning("미등록 사용자");
                return 0;
            }
            if (IsLoggedIn())
            {
                var result = MessageBox.Show("접속 사용자입니다. \n강제 로그아웃 하시겠습니까?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    Logout(id);
                }
                return 0;
            }

            string sql = $@"insert into user_log values (seq_user_log.nextVal, '{id}', 'IN', sysdate)";
            using (OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect()))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        /*
            Logout
            1. id 할당
            2. 로그아웃 쿼리 초기화
            3. DB 수행
         */
        public void Logout()
        {
            id = Properties.Settings.Default.UserId;

            string sql = $@"insert into user_log values (seq_user_log.nextVal, '{id}', 'OUT', sysdate)";
            using (OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect()))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /*
            Logout
            1. id 할당
            2. 로그아웃 쿼리 초기화
            3. DB 수행
         */
        public void Logout(string id)
        {
            string sql = $@"insert into user_log values (seq_user_log.nextVal, '{id}', 'OUT', sysdate)";
            using (OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect()))
            {
                if (!IsLoggedIn()) return;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
