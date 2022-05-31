package kr.co.aim.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.domain.Member;
import kr.co.aim.domain.MemberByRoom;

public interface MemberByRoomRepository extends JpaRepository<MemberByRoom, Integer> {
}
