package kr.co.aim.server;

import java.io.DataOutputStream;
import java.util.HashMap;
import java.util.Map;

/*
 	ClientGroup; 클라이언트들의 그룹을 정의함.
 */
public class ClientGroup {
	private Map<String, DataOutputStream> map;
	private String name;
	private int total;
	
	public ClientGroup() {
		map = new HashMap<>();
	}
	
	public ClientGroup(int total) {
		this.total = total;
		map = new HashMap<>(total);
	}
	
	public Map<String, DataOutputStream> getClientMap() {
		return map;
	}
	
	public void setClientMap(Map<String, DataOutputStream> clientMap) {
		this.map = clientMap;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public boolean isFull() { 
		return map.size() == total;
	}

	@Override
	public String toString() {
		return String.format("%s", name);
	}
}
