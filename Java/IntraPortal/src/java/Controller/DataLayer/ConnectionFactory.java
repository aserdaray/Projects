package Controller.DataLayer;

import com.mysql.jdbc.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 *
 * @author ASerdar
 */
public class ConnectionFactory {

    String driverClassName = "com.mysql.jdbc.Driver";
    String connectionUrl = "jdbc:mysql://localhost:3306/intrafax?characterSetResults=UTF-8&characterEncoding=UTF-8&useUnicode=true";
    String dbUser = "root";

    String dbPwd = "";
    private static ConnectionFactory instance = null;
    private static Object mutex = new Object();

    private ConnectionFactory() {
        try {
            Class.forName(driverClassName);
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    public Connection getConnection() throws SQLException {
        Connection conn = null;
        conn = (Connection) DriverManager.getConnection(connectionUrl, dbUser, dbPwd);

        return conn;
    }

    public static ConnectionFactory getInstance() {
        if (instance == null) {
            synchronized (mutex) {
                if (instance == null) {
                    instance = new ConnectionFactory();
                }
            }
        }
        return instance;
    }
}
