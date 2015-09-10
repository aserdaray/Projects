package Controller.DataLayer;

import Model.Users;
import com.mysql.jdbc.Connection;
import java.io.Serializable;
import java.sql.CallableStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author ASerdar
 */
public class UsersAdapter implements Serializable {

    private Connection connection = null;
    CallableStatement cs = null;
    private ResultSet rs = null;

    public ArrayList<Users> select() throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call users_FindAll()}");
            rs = cs.executeQuery();

            ArrayList<Users> list = new ArrayList<Users>();
            while (rs.next()) {
                Users u = new Users(rs.getInt("idUser"), rs.getInt("idAgent"), rs.getInt("idCompany"), rs.getString("Username"), rs.getString("PPassword"), rs.getString("UserType"), rs.getShort("isActive"), rs.getString("apiUsername"), rs.getString("apiPassword"), rs.getInt("idApi"));
                list.add(u);
            }
            return list;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public Users selectById(int id) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call users_FindByUserID(?)}");

            cs.setInt(1, id);

            rs = cs.executeQuery();
            Users u = null;
            while (rs.next()) {
                u = new Users(rs.getInt("idUser"), rs.getInt("idAgent"), rs.getInt("idCompany"), rs.getString("Username"), rs.getString("PPassword"), rs.getString("UserType"), rs.getShort("isActive"), rs.getString("apiUsername"), rs.getString("apiPassword"), rs.getInt("idApi"));
            }
            return u;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public Users selectByUsername(String username) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call users_FindByUsername(?)}");

            cs.setString(1, username);

            rs = cs.executeQuery();
            Users u = null;
            while (rs.next()) {
                u = new Users(rs.getInt("idUser"), rs.getInt("idAgent"), rs.getInt("idCompany"), rs.getString("Username"), rs.getString("PPassword"), rs.getString("UserType"), rs.getShort("isActive"), rs.getString("apiUsername"), rs.getString("apiPassword"), rs.getInt("idApi"));
            }
            return u;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public ArrayList<Users> selectByCompanyId(int id) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call users_FindByCompanyID(?)}");
            cs.setInt(1, id);

            rs = cs.executeQuery();
            ArrayList<Users> list = new ArrayList<Users>();
            while (rs.next()) {
                Users u = new Users(rs.getInt("idUser"), rs.getInt("idAgent"), rs.getInt("idCompany"), rs.getString("Username"), rs.getString("PPassword"), rs.getString("UserType"), rs.getShort("isActive"), rs.getString("apiUsername"), rs.getString("apiPassword"), rs.getInt("idApi"));
                list.add(u);
            }
            return list;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public ArrayList<Users> selectByAgentId(int id) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call users_FindByAgentID(?)}");
            cs.setInt(1, id);

            rs = cs.executeQuery();
            ArrayList<Users> list = new ArrayList<Users>();
            while (rs.next()) {
                Users u = new Users(rs.getInt("idUser"), rs.getInt("idAgent"), rs.getInt("idCompany"), rs.getString("Username"), rs.getString("PPassword"), rs.getString("UserType"), rs.getShort("isActive"), rs.getString("apiUsername"), rs.getString("apiPassword"), rs.getInt("idApi"));
                list.add(u);
            }
            return list;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public ArrayList<Users> SelectByUserType(String UserType) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call users_FindByUserType(?)}");
            cs.setString(1, UserType);

            rs = cs.executeQuery();
            ArrayList<Users> list = new ArrayList<Users>();
            while (rs.next()) {
                Users u = new Users(rs.getInt("idUser"), rs.getInt("idAgent"), rs.getInt("idCompany"), rs.getString("Username"), rs.getString("PPassword"), rs.getString("UserType"), rs.getShort("isActive"), rs.getString("apiUsername"), rs.getString("apiPassword"), rs.getInt("idApi"));
                list.add(u);
            }
            return list;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public ArrayList<Users> SelectAgentUserByUserType(String UserType,int agentID) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call users_FindAgentUserByUserType(?,?)}");
            cs.setString(1, UserType);
            cs.setInt(2, agentID);

            rs = cs.executeQuery();
            ArrayList<Users> list = new ArrayList<Users>();
            while (rs.next()) {
                Users u = new Users(rs.getInt("idUser"), rs.getInt("idAgent"), rs.getInt("idCompany"), rs.getString("Username"), rs.getString("PPassword"), rs.getString("UserType"), rs.getShort("isActive"), rs.getString("apiUsername"), rs.getString("apiPassword"), rs.getInt("idApi"));
                list.add(u);
            }
            return list;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }
    
    public int insert(Users u) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call users_insert(?,?,?,?,?,?,?,?,?)}");

            cs.setInt(1, u.getIdAgent());
            cs.setInt(2, u.getIdCompany());
            cs.setString(3, u.getUsername());
            cs.setString(4, u.getPassword());
            cs.setString(5, u.getUserType());
            cs.setShort(6, u.getIsActive());
            cs.setString(7, u.getApiUsername());
            cs.setString(8, u.getApiPassword());
            cs.setInt(9, u.getIdApi());

            rs = cs.executeQuery();
            int ret = 0;
            while (rs.next()) {
                ret = rs.getInt("idUser");
            }
            return ret;

        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public boolean update(Users u) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call users_Update(?,?,?,?,?,?,?,?,?,?)}");

            cs.setInt(1, u.getIdUser());
            cs.setInt(2, u.getIdAgent());
            cs.setInt(3, u.getIdCompany());
            cs.setString(4, u.getUsername());
            cs.setString(5, u.getPassword());
            cs.setString(6, u.getUserType());
            cs.setShort(7, u.getIsActive());
            cs.setString(8, u.getApiUsername());
            cs.setString(9, u.getApiPassword());
            cs.setInt(10, u.getIdApi());

            cs.execute();
            return true;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public boolean changePassword(Users u) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call users_ChangePassword(?,?)}");

            cs.setInt(1, u.getIdUser());
            cs.setString(2, u.getPassword());

            cs.execute();
            return true;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public boolean delete(int idUser) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call users_delete(?)}");

            cs.setInt(1, idUser);

            cs.execute();
            return true;
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public boolean hasFaxService(int idUser) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call has_faxService(?)}");

            cs.setInt(1, idUser);

            rs = cs.executeQuery();
            boolean ret = false;
            while (rs.next()) {
                ret = rs.getInt("isActive") == 1 ? true : false;
            }
            return ret;

        } finally {
            if (rs != null) {
                rs.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }
}
