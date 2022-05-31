package kr.co.aim;


import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.domain.Room;
import kr.co.aim.repository.RoomRepository;

@Component
public class RoomTest {
	@Autowired
	private RoomRepository roomRepository;
	
	@PostConstruct
	public void init() {
		Room room = new Room();
		room.setName("헤이니4");
		room.setTotal(3);
		
		roomRepository.save(room);
	}
}
