using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runch.Data;

namespace Runch.Domain
{
    public class Restaurant
    {
        public int id;
        public string name;
        public string category;
        public int categoryId;
        public string signature;
        public int cntAdoption;
        public string recentAdoption;
        public string start;
        public string end;
        public string userName;
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
            string userId = Properties.Settings.Default.UserId;
            string sql = $@"select 
                                r.*,
                                case
                                    when restaurant_id not in (select restaurant_id
                                                               from restaurant_adoption
                                                               where user_id = '{userId}'
                                                                   and sysdate - adoption_time <= 7)
                                        then 0 
                                    else 1
                                end as recent_adoption
                            from vwRestaurantInfo r
                            where restaurant_id not in (select restaurant_id
                                                        from restaurant_block
                                                        where user_id = '{userId}')
                                and category_id in ({Properties.Settings.Default.CategoryList})
                                and rownum <= 5
                            order by recent_adoption, cnt desc";
                                    
            OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect());
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Restaurant restaurant = new Restaurant();
                restaurant.id = Int32.Parse(reader["restaurant_id"].ToString());
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
            Random rnd = new Random();
            int index = rnd.Next(recommendList.Count);
            return (Restaurant)recommendList[index];
        }

        /*
            Adopt; 레스토랑 채택
            1. DB 설정
            2. 쿼리 할당
         */        
        public void Adopt()
        {
            string user_id = Properties.Settings.Default.UserId;

            string sql = $@"insert into restaurant_adoption
                                values (seq_restaurant_adoption.nextVal, '{user_id}', {id}, sysdate)";
            OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect());

            cmd.ExecuteNonQuery();
        }

        /*
            List
            
         */
        public DataSet List()
        {
            string sql = "select * from vwRestaurantSimpleInfo";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, dbutil.Connect());
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }

        public DataSet Search()
        {
            string sql = $@"select * from vwrestaurantSimpleInfo where ""No"" in (SELECT restaurant_id
                            FROM VWRESTAURANTINFO
                            WHERE CATEGORY_ID IN ('{categoryId}')
                            	AND recent BETWEEN '{start}' AND '{end}'
	                            AND RESTAURANT_ID IN (SELECT RESTAURANT_ID 
						                              FROM RESTAURANT_ADOPTION 
						                              WHERE user_id IN (SELECT user_id 
                                                                        FROM users 
                                                                        WHERE name = '{userName}')))";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, dbutil.Connect());
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }

        public void Add()
        {
            string sql = $@"insert into restaurant
                                values (seq_restaurant.nextVal, '{name}', {categoryId}, '{signature}', 30, 30)";
            OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect());
            cmd.ExecuteNonQuery();

            string userId = Properties.Settings.Default.UserId;
            sql = $@"insert into restaurant_history
                        values (seq_restaurant_history.nextVal, (select max(restaurant_id) from restaurant), '{userId}', 'C', '{name}', {categoryId}, '{signature}', 30, 30, sysdate)";
            cmd = new OleDbCommand(sql, dbutil.Connect());
            cmd.ExecuteNonQuery();
        }

        public Restaurant FindById(int id)
        {
            string sql = $@"select * from vwRestaurantInfo where restaurant_id = {id}";
            OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect());
            OleDbDataReader reader = cmd.ExecuteReader();

            Restaurant restaurant = new Restaurant();
            
            if (reader.Read())
            {
                restaurant.id = Int32.Parse(reader["restaurant_id"].ToString());
                restaurant.name = reader["name"].ToString();
                restaurant.category = reader["category"].ToString();
                restaurant.signature = reader["signature"].ToString();
                restaurant.cntAdoption = Int32.Parse(reader["cnt"].ToString());
                restaurant.recentAdoption = reader["recent"].ToString();
            }

            return restaurant;
        }

        public void Block()
        {
            string userId = Properties.Settings.Default.UserId;
            string sql = $@"insert into restaurant_block
                                values (seq_restaurant_block.nextVal, '{userId}', {id})";
            OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect());
            cmd.ExecuteNonQuery();
        }

        public void Edit(Restaurant newRestaurant)
        {
            string sql = $@"update restaurant set name = '{newRestaurant.name}', category_id = {newRestaurant.categoryId}, signature = '{newRestaurant.signature}'
                                where restaurant_id = {id}";
            OleDbCommand cmd = new OleDbCommand(sql, dbutil.Connect());
            cmd.ExecuteNonQuery();

            string userId = Properties.Settings.Default.UserId;
            sql = $@"insert into restaurant_history
                        values (seq_restaurant_history.nextVal, {id}, '{userId}', 'U', '{newRestaurant.name}', {newRestaurant.categoryId}, '{newRestaurant.signature}', 30, 30, sysdate)";
            cmd = new OleDbCommand(sql, dbutil.Connect());
            cmd.ExecuteNonQuery();
        }
    }
}
