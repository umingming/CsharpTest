package kr.co.aim.data;

import java.io.InputStream;
import java.nio.ByteBuffer;

public class Packet {
	private InputStream stream;
	private byte[] header;
	private byte[] body;
	
	private final int HEADER_LENGTH = 4;
}
