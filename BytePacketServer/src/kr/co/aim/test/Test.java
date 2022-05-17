package kr.co.aim.test;

public class Test {
	
	public static void main(String[] args) {
		String name = "유미";
		byte[] buffers = name.getBytes();
		System.out.println(new String(buffers));
	}

}
