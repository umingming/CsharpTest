package kr.co.aim.data;

import java.io.OutputStream;

import lombok.Getter;
import lombok.Setter;

@Getter @Setter
public class User {
	private int seq;
	private String name;
	private OutputStream out;
	private Group group;
}
