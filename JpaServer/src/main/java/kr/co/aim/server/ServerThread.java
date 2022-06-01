package kr.co.aim.server;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.domain.Member;
import kr.co.aim.domain.MemberRoom;
import kr.co.aim.domain.Message;
import kr.co.aim.domain.Room;
import kr.co.aim.repository.MemberRepository;
import kr.co.aim.repository.MemberRoomRepository;
import kr.co.aim.repository.MessageRepository;
import lombok.Getter;
import lombok.Setter;
import kr.co.aim.domain.Packet;

@Getter @Setter
public class ServerThread implements Runnable {
	private Socket client;
	private InputStream in;
	private OutputStream out;
	private Member member;
	private Room room;
	
	private MemberRoomRepository memberRoomRepository;
	private MemberRepository memberRepository;
	private MessageRepository messageRepository;

	public ServerThread() {
		this.client = null;
	}
	
	public ServerThread(Socket client, Room room) {
		this.client = client;
		this.room = room;
	}

	/*
	 	run; 클라이언트가 그룹에 연결되어, 메시지를 보냄.
	 	1. 스트림 변수에 client 소켓 스트림 값을 초기화함.
	 	2. registerMember 호출
	 	3. while문 스트림이 존재하면 반복.
	 		> 메시지 패킷 생성
	 		> if문 읽을 내용이 있는지?
	 			> 메시지 패킷 초기화
	 			> 해당 메시지를 room에 보내기 위해 send 메소드 호출함.
	 */
	@Override
	public void run() {
		try {
			in = client.getInputStream();
			out = client.getOutputStream();
			
			registerMember();

			while(in != null) {
				Packet msgPacket = new Packet(in);
				
				if(msgPacket.isAvailable()) {
					msgPacket.init();
					send(msgPacket, room);
				}
			}
		} catch (Exception e) {
			System.out.println("[사용자 접속 실패]");
		}
	}

	/*
	 	registerMember; 사용자 설정
		1. 이름 패킷 생성 후 초기화
		2. 패킷을 문자열로 변환한 값으로 멤버의 이름 설정
		3. 멤버 데이터 저장함.
		4. 해당 대화방에 멤버 추가
			> 멤버룸 객체 생성 후, 사용자와 대화방 할당
			> DB 연동
	 	5. 사용자 접속 안내
	 */
	private void registerMember() {
		Packet namePacket = new Packet(in);
		namePacket.init();
		
		member = new Member();
		member.setName(namePacket.toString());
		member.setOut(out);
		memberRepository.save(member);
		
		room.getMemberList().add(member);
		MemberRoom memberRoom = new MemberRoom();
		memberRoom.setMember(member);
		memberRoom.setRoom(room);
		memberRoomRepository.save(memberRoom);
		
		System.out.printf("[사용자 접속 성공] %s님이 접속했습니다.%n", member.getName());
	}
	
	/*
		send; 메시지를 대화방에 전송함.
		1. 해당 메시지 출력
		2. 메시지 객체 생성 후, 발신인, 대화방, 내용 설정
		3. 메시지 데이터 추가
		4. for문 해당 대화방의 인원 수 만큼 반복
		  > 대화방 멤버들의 OutputStream을 변수에 초기화함.
		  > 해당 메시지의 바이트배열을 스트림으로 전송함.
	 */
	private void send(Packet msgPacket, Room room) {
		try {
			System.out.println(msgPacket.toString());
			
			Message msg = new Message();
			msg.setMember(member);
			msg.setRoom(room);
			msg.setContent(msgPacket.toString());
			messageRepository.save(msg);
			
			for(int i=0; i<room.getMemberList().size(); i++) {
				OutputStream out = room.getMemberList().get(i).getOut();
				out.write(msgPacket.toByteArr());
				out.flush();
			}
		} catch (Exception e) {
			System.out.println("[메시지 송신 오류]");
		}
	}
}
