package kr.co.aim.server;

import java.nio.ByteBuffer;

public class Test {
	public static void main(String[] args) {
		byte[] byteArr = ByteBuffer.allocate(4).putInt(10).array();
		for(int i=0; i<4; i++) {
			System.out.println(byteArr[i]);
		}
	}

}
