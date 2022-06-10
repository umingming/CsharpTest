package kr.co.aim.config;

import org.springframework.jdbc.datasource.DriverManagerDataSource;
import org.springframework.stereotype.Component;

public class DBUtil {
	private String driver = "oracle.jdbc.OracleDriver";
	private String url = "jdbc:oracle:thin:@//localhost:1521/ORCL";
	private String username = "hr";
	private String password = "java1234";

	private DriverManagerDataSource dataSource;
	
	public DBUtil() {
		dataSource = new DriverManagerDataSource();
		dataSource.setDriverClassName(driver);
		dataSource.setUrl(url);
		dataSource.setUsername(username);
		dataSource.setPassword(password);
	}
	
	public DriverManagerDataSource getDataSource() {
		return dataSource;
	}
}
