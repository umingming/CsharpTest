package kr.co.aim.domain;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import lombok.Getter;
import lombok.Setter;

@Entity
@Getter @Setter
public class Message {
	@Id @GeneratedValue(strategy = GenerationType.SEQUENCE)
	private int seq;
	
	@ManyToOne
	@JoinColumn(name = "seqMember")
	private Member member;
	
	@ManyToOne
	@JoinColumn(name = "seqRoom")
	private Room room;
	
	@Column(nullable = false, length = 300)
	private String content;
	
	@Temporal(TemporalType.TIMESTAMP)
	private Date regDate = new Date();
}
