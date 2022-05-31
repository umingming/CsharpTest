package kr.co.aim.domain;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

import lombok.Getter;
import lombok.Setter;

@Entity
@Getter @Setter
public class MemberByRoom {
	@Id @GeneratedValue(strategy = GenerationType.SEQUENCE)
	private int seq;
	
	@ManyToOne
	@JoinColumn(name = "seqMember")
	private Member member;
	
	@ManyToOne
	@JoinColumn(name = "seqRoom")
	private Room room;
}
