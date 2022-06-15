using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runch.Data;

namespace Runch.Domain
{
    public class Restaurant
    {
        public string id;
        public string name;
        public string category;
        public string signature;
        public int cntAdoption;
        public ArrayList recommendList;

        private DBUtil dbutil;
        private Notification box;

        public Restaurant()
        {
            recommendList = new ArrayList();
            dbutil = new DBUtil();
            box = new Notification();
        }

        /*
            InitRecommendList
            1. DB 설정
            2. for문 데이터 읽기
                > 레스토랑 객체 생성
                > 객체에 칼럼 값 할당 후 리스트에 추가
         */
        public void InitRecommendList()
        {
            string id = "2203001";
            string sql = "SELECT r.*, CASE WHEN RESTAURANT_ID NOT IN (SELECT RESTAURANT_ID FROM RESTAURANT_ADOPTION WHERE USER_ID = " + id + " AND SYSDATE - ADOPTION_TIME <= 7) THEN 0 ELSE 1 END AS \"recent adoption\" FROM VWRESTAURANTINFO r WHERE RESTAURANT_ID NOT IN (SELECT RESTAURANT_ID FROM RESTAURANT_BLOCK WHERE user_id = " + id + ") AND CATEGORY_ID IN (" + Properties.Settings.Default.CategoryList + ") AND rownum <= 5 ORDER BY \"recent adoption\", CNT DESC";
            OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect());
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Restaurant restaurant = new Restaurant();
                restaurant.id = reader["restaurant_id"].ToString();
                restaurant.name = reader["name"].ToString();
                restaurant.category = reader["category"].ToString();
                restaurant.signature = reader["signature"].ToString();
                restaurant.cntAdoption = Int32.Parse(reader["cnt"].ToString());

                recommendList.Add(restaurant);
            }
        }

        /*
            Recommend
            1. 랜덤 객체 생성해 인덱스 초기화
            2. 리스트 중 해당 인덱스의 요소를 리턴함.
         */
        public Restaurant Recommend()
        {

        }
    }
}
