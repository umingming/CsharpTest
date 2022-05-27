package kr.co.aim.dao;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import kr.co.aim.config.DBUtil;
import kr.co.aim.data.User;

@Component
public class UserDAO {
	private JdbcTemplate jdbcTemplate;
	
	public UserDAO() {
		jdbcTemplate = new JdbcTemplate();
		jdbcTemplate.setDataSource(new DBUtil().getDataSource());
	}
	
	/*
	 	add; 유저 저장
		1. 유저 정보를 쿼리에 저장
		2. 해당 이름으로 데이터 찾고 번호 반환
	 */
	public int add(User user) {
		String sql = "insert into tblUser (seq, name) values (seqUser.nextVal,?)";
		jdbcTemplate.update(sql, user.getName());

		int seq = jdbcTemplate.queryForObject("select seq from tblUser where name = ?", Integer.class, user.getName());
		return seq;
	}
}
