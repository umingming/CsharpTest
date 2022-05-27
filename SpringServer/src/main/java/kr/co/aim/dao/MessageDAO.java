package kr.co.aim.dao;

import org.springframework.jdbc.core.JdbcTemplate;

import kr.co.aim.config.DBUtil;
import kr.co.aim.data.Message;

public class MessageDAO {
	private JdbcTemplate jdbcTemplate;
	
	public MessageDAO() {
		jdbcTemplate = new JdbcTemplate();
		jdbcTemplate.setDataSource(new DBUtil().getDataSource());
	}
	
	/*
		add; 메시지 저장
		1. 메시지 정보를 쿼리에 저장
		2. 업데이트 결과를 반환
	 */
	public int add(Message msg) {
		int result = 0;
		String sql = "insert into tblMessage (seq, seqUser, seqGroup, content) values (seqMessage.nextVal,?,?,?)";
		
		result = jdbcTemplate.update(sql, msg.getSeqUser(), msg.getSeqGroup(), msg.getContent());
		return result;
	}
}
