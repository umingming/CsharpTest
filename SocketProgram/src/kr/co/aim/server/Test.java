package kr.co.aim.server;

import java.util.Calendar;

public class Test {
	public static void main(String[] args) {
		Calendar cal = Calendar.getInstance();
		System.out.printf("%tF %tT", cal, cal);
	}

}
