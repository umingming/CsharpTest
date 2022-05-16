package kr.co.aim.server;

import java.io.DataOutputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

/*
 	ClientGroup; 클라이언트들의 그룹을 정의함.
 */
public class ClientGroup {
	private Map<String, PrintWriter> map;
	private String name;
	private int total;
	
	public ClientGroup() {
		map = new HashMap<>();
	}
	
	public ClientGroup(int total) {
		this.total = total;
		map = new HashMap<>(total);
	}
	
	public Map<String, PrintWriter> getClientMap() {
		return map;
	}
	
	public void setMap(Map<String, PrintWriter> clientMap) {
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
		String[] clients = new String[map.size()];
		int index = 0;
		
		for(String client : map.keySet()) {
			clients[index] = client;
			index++;
		}
		
		return String.format("%s,%d%s", name, total, Arrays.toString(clients));
	}
}
