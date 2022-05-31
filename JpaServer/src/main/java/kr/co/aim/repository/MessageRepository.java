package kr.co.aim.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.domain.Member;
import kr.co.aim.domain.MemberByRoom;
import kr.co.aim.domain.Message;

public interface MessageRepository extends JpaRepository<Message, Integer> {
}
