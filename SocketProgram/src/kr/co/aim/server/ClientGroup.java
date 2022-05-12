package kr.co.aim.server;

import java.io.DataOutputStream;
import java.util.HashMap;

public class ClientGroup {
	private HashMap<String, DataOutputStream> map;
	private String name;
	private int total;
	
	public ClientGroup() {
		map = new HashMap<String, DataOutputStream>();
	}
	
	public ClientGroup(int total) {
		this.total = total;
		map = new HashMap<String, DataOutputStream>(total);
	}
	
	public HashMap<String, DataOutputStream> getClientMap() {
		return map;
	}
	public void setClientMap(HashMap<String, DataOutputStream> clientMap) {
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
}
