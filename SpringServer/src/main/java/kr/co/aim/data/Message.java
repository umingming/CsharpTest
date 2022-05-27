package kr.co.aim.data;

import lombok.Getter;
import lombok.Setter;

@Getter @Setter
public class Message {
	private int seq;
	private int seqUser;
	private int seqGroup;
	private String content;
}
