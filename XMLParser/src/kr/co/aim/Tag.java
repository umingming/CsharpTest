package kr.co.aim;

/*
	XML 태그를 분류하기 위한 클래스
 */
public class Tag {
	private String type;
	private String name;
	
	public Tag() {
	}
	
	public Tag(String type) {
		this.setType(type);
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
}
