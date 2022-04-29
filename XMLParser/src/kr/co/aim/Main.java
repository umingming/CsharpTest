package kr.co.aim;

import java.io.File;
import java.util.Scanner;

import org.jdom2.Element;

import kr.co.aim.Parser;
import kr.co.aim.Tag;

public class Main {
	private static String path;
	
	private static Parser parser;
	private static Scanner scan;
	
	static {
		scan = new Scanner(System.in);
	}
	
	/*
		XML Parser
		- 파일을 파싱하고 원하는 기능 실행
		
		1. parseFile() 호출
		2. while문 무한 루프
			> showMenu() 호출
			> switch문 입력을 조건으로 기능 선택
				> 파일 출력/요소 수정/요소 추가/주석 처리/요소 제거/다른 이름으로 저장
				ysum
	 */
	public static void main(String[] args) {
		try {
			parseFile();
			
			while(true) {
				showMenu();
				
				switch(scan.nextLine()) {
					case "1" : 
						parser.printFile();
						break;
					case "2" :
						modifyElement();
						break;
					case "3" :
						createChild();
						break;
					case "4" :
						parser.commentOutElement(getTag());
						break;
					case "5" :
						parser.removeElement(getTag());
						break;
					case "6" :
						saveAs();
						break;
					default :
						System.out.println("Please Enter again.");
						break;
				}
				pause();
			}
		} catch (Exception e) {
			e.getStackTrace();
		}
	}

	/*
		parseFile(); XML Parsing
		1. 입력 값을 path 변수에 저장
		2. if문 해당 파일이 존재하는지?
			> parser 객체 생성
	 */
	private static void parseFile() throws Exception {
		System.out.print("Enter a File Path to parse. \r\n 👉 ");
		path = scan.nextLine();
		
		if(new File(path).exists()) {
			parser = new Parser(path); 
		}
	}

	/*
		getTag(); 태그를 설정 후 리턴함.
		1. 태그 객체 생성
		2. 입력 값으로 타입과 이름 설정
		3. 태그 리턴
	 */
	private static Tag getTag() {
		Tag tag= new Tag();
		
		System.out.print("Enter a tag type. \r\n 👉 ");
		tag.setType(scan.nextLine());
		
		System.out.print("Enter the tag name. \r\n 👉 ");
		tag.setName(scan.nextLine());
		
		return tag;
	}
	
	/*
		showMenu; 메뉴 보여줌
	 */
	private static void showMenu() {
		System.out.println("\r\n1. Print the File");
		System.out.println("2. Add an Element");
		System.out.println("3. Modify an Element");
		System.out.println("4. Comment out an Element");
		System.out.println("5. Remove an Element");
		System.out.print("6. Save as the File\r\n 👉 ");
	}
	
	/*
		pause; 일시 정지
	 */
	private static void pause() {
		System.out.print("\r\n(Please press enter.)");
		scan.nextLine();
	}
	
	/*
		createChild; 요소에 자식 생성
		1. 태그를 인자로 요소 찾고, 이를 Element 객체에 초기화함.
		2. if문 element가 있는지?
			> 해당 요소에 원하는 자식 요소를 추가함.
	 */
	private static void createChild() {
		Element element = parser.navigateElement(getTag());
		
		if(element != null) {
			parser.createChild(element, getTag());
		}
	}
	
	/*
		modifyElement; 요소 수정
		1. 태그 인자로 찾은 요소를 element에 초기화
		2. if문 요소가 있는지?
			> 입력 값으로 attribute와 value 초기화
			> 해당 요소 속성의 값을 수정함.
	 */
	private static void modifyElement() {
		Element element = parser.navigateElement(getTag());
		
		if(element != null) {
			System.out.print("Enter a Attribute to be modified. \r\n 👉 ");
			String attr = scan.nextLine();
			System.out.print("Enter a Value for the attribute. \r\n 👉 ");
			String value = scan.nextLine();
			
			parser.modifyElement(element, attr, value);
		}
	}
	
	/*
		saveAs; 다른 이름으로 저장
		1. 새로운 이름을 입력 받아, 저장함.
	 */
	private static void saveAs() throws Exception {
		System.out.print("Enter a new name. \r\n 👉 ");
		parser.saveAs(scan.nextLine());
	}
}
