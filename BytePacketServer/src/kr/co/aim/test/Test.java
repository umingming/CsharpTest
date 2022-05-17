package kr.co.aim.test;

import java.nio.ByteBuffer;

public class Test {
	
	public static void main(String[] args) {
		String name = "유미";
		byte[] body = name.getBytes();
		int len = 350;//body.length;
//		byte[] header = new byte[4];
		ByteBuffer b = ByteBuffer.allocate(len);
		b.putInt(0xAABBCCDD);
//		for(int i=0; i<body.length; i++) {
//			System.out.print(body[i] + ", ");
//		}
		byte[] header = intToByteArray(len);
		for(int i=0; i<header.length; i++) {
			System.out.println(header[i]);
		}
		int length = ByteBuffer.wrap(header).getInt();
		System.out.println(length);
		
	}
	
	public static byte[] intToByteArray(int length) {
		byte[] byteArr = ByteBuffer.allocate(4).putInt(length).array();
		return byteArr;
	}

}
