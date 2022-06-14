using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runch.Data;

namespace Runch.Domain
{
    public class User
    {
        private string id;
        private string name;

        private DBUtil dbutil;
        private Notification box;

        /*
            생성자 정의
            1. DBUtil 초기화 후 연결
         */
        public User()
        {
            dbutil = new DBUtil();
            box = new Notification();
        }

        /*
            Login
            1. if문 존재하는 사용자인지
            2. if문 로그인 된 사용자인지
            3. 유저 로그 추가 쿼리 할당
         */
        public void Login(string id)
        {
            this.id = id;

            if (!IsValid()) return;
            if (IsLoggedIn()) return;

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = dbutil.Connect();
            cmd.CommandText = "insert into user_log values (seq_user_log.nextVal, :id, 'in', sysdate)";
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        /*
            IsValid
            1. 유저 조회 쿼리 할당
            2. if문 해당 유저가 있는지?
                > id, name 저장
                > true 반환
         */
        public Boolean IsValid()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = dbutil.Connect();
            cmd.CommandText = "select * from vwUserInfo where user_id = :id";
            cmd.Parameters.AddWithValue("id", id);
            OleDbDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                id = reader["user_id"].ToString();
                name = reader["name"].ToString();
                return true;
            }
            return false;
        }

        /*
            IsLoggedIn
            1. 유저 조회 쿼리 할당
            2. if문 값 읽기 
                > if문 유저가 로그인 중인지?
         */
        public Boolean IsLoggedIn()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = dbutil.Connect();
            cmd.CommandText = "select * from user_log where user_id = :id and rownum = 1 order by user_log_id desc";
            cmd.Parameters.AddWithValue("id", id);
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                box.DisplayError(reader["log_type"].ToString());
                if (reader["log_type"].ToString() == "in") return true;
            }
            return false;
        }
    }
}
