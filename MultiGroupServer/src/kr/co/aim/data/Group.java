package kr.co.aim.data;

import java.time.LocalDateTime;
import java.util.ArrayList;

/*
 	ClientGroup; 클라이언트들의 그룹을 정의함.
 */
public class Group {
	private int seq;
	private String name;
	private int total;
	private LocalDateTime regDate;
	private ArrayList<User> userList;
}
