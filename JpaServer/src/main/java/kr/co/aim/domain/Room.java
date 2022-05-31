package kr.co.aim.domain;

import java.util.Date;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import lombok.Getter;
import lombok.Setter;

@Entity
@Getter @Setter
public class Room {
	@Id @GeneratedValue(strategy = GenerationType.SEQUENCE)
	private int seq;
	
	@Column(nullable = false, length = 30)
	private String name;
	
	@Column(nullable = false)
	private int total;
	
	@Temporal(TemporalType.TIMESTAMP)
	private Date regDate = new Date();
	
	@OneToMany(mappedBy = "room")
	private List<MemberByRoom> members;
}
