package kr.co.aim.data;

import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Component;

import lombok.Getter;
import lombok.Setter;

/*
 	ClientGroup; 클라이언트들의 그룹을 정의함.
 */
@Component
@Getter @Setter
public class Group {
	private int seq;
	private String name;
	private int total;
	private List<User> userList;
	
	/*
		total값을 정의하지 않으면 그룹을 무한대로 만듦.
	 */
	public Group() {
		userList = new ArrayList<>();
	}
	
	/*
		total값을 매개로 받아, 해당 크기 만큼 map을 생성함.
	 */
	public Group(int total) {
		this.total = total;
		userList = new ArrayList<>();
	}
	
	/*
	  	isFull()
	  	1. 존재하는 요소와 total의 크기가 같은지를 리턴함.
	 */
	public boolean isFull() {
		return userList.size() == total;
	}
}