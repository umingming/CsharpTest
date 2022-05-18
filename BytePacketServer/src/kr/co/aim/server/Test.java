package kr.co.aim.server;

import java.nio.ByteBuffer;

public class Test {

	public static void main(String[] args) {
		
		String name = "abc";
		byte[] byteArr = name.getBytes();
		for(int i=0; i<byteArr.length; i++){
			System.out.println(byteArr[i]);
		}
				
	}
}
