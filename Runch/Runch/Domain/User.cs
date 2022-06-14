using System;
using System.Collections.Generic;
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

        /*
            생성자 정의
            1. DBUtil 초기화 후 연결
         */
        public User()
        {
            dbutil = new DBUtil();
            dbutil.Connect();
        }

        /*
            로그인
            1. 존재하는 사용자인지 확인
            2. 사용자 정보 받기
         */
        public void Login(string id)
        {
            this.id = id;
        }

        public void IsValid()
        {
            string sql = "select * from vwUserInfo where user_id = "
        }
    }
}
