package kr.co.aim.test;

import java.nio.ByteBuffer;

public class Test {
	
	public static void main(String[] args) {
		int[] num1 = {1, 2, 3, 4};
		int[] num2 = {5, 6, 7, 8};
		int length = num1.length + num2.length;
		int[] num3 = new int[length];
		System.arraycopy(num1,  0, num3, 0, num1.length);
		System.arraycopy(num2, 0, num3, num1.length, num2.length);
		for(int i=0; i<num3.length; i++) {
			System.out.println(num3[i]);
		}
	}
	
	public static byte[] intToByteArray(int length) {
		byte[] byteArr = ByteBuffer.allocate(4).putInt(length).array();
		return byteArr;
	}

}
