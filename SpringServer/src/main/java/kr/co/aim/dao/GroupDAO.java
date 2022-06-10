package kr.co.aim.dao;

import org.springframework.jdbc.core.JdbcTemplate;

import kr.co.aim.config.DBUtil;
import kr.co.aim.data.Group;

public class GroupDAO {
	private JdbcTemplate jdbcTemplate;
	
	public GroupDAO() {
		jdbcTemplate = new JdbcTemplate();
		jdbcTemplate.setDataSource(new DBUtil().getDataSource());
	}

	/*
	 	add; 그룹 저장
		1. 그룹 정보를 쿼리에 저장
		2. 그룹명으로 데이터 찾고 번호 반환
	 */
	public int add(Group group) {
		String sql = "insert into tblGroup (seq, name, total) values (seqGroup.nextVal,?,?)";
		jdbcTemplate.update(sql, group.getName(), group.getTotal());
		
		int seq = jdbcTemplate.queryForObject("select seq from tblGroup where name = ?", Integer.class, group.getName());
		return seq;
	}
	
	/*
	 	remove; 그룹 삭제
	 	1. 그룹의 번호로 데이터 삭제
	 	2. 결과 반환
	 */
	public int remove(Group group) {
		String sql = "delete from tblGroup where seq = ?";
		int result = jdbcTemplate.update(sql, group.getSeq());
		
		return result;
	}
}
