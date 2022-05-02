package kr.co.aim;

import java.util.Calendar;
import java.util.Scanner;

/*
	로그
	- 시스템의 현재 상황을 안내함.
 */
public class Log {
	private Calendar now;
	private Scanner scanner;
	
	/*
		생성자 정의
		1. 현재 시각으로 Calendar를 초기화함.
		2. 시스템 입력으로 Scanner 초기화
	 */
	public Log() {
		this.now = Calendar.getInstance();
		this.scanner = new Scanner(System.in);
	}

	/*
		print; 현재 상황을 출력함.
		1. 현재 시각과 info를 출력
	 */
	public void print(String info) {
		System.out.printf("[%tF %tT] %s%n", now, now, info);
	}
	
	/*
		inputInt
		1. 입력에 대한 안내 출력
		2. 입력 값 반환함.
	 */
	public int inputInt(String variable) {
		System.out.printf("%s을(를) 입력하세요. %n ☞ ", variable);
		return scanner.nextInt();
	}
	
	/*
		input
		1. 입력에 대한 안내 출력
		2. 입력 값 반환함.
	 */
	public String input(String variable) {
		System.out.printf("%s을(를) 입력하세요. %n ☞ ", variable);
		return scanner.nextLine();
	}
}
