package Controller.DataLayer;

import Model.Faq;
import com.mysql.jdbc.Connection;
import java.sql.CallableStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author ASerdar
 */
public class FaqAdapter {

    private Connection connection = null;
    CallableStatement cs = null;
    private ResultSet resultSet = null;

    public FaqAdapter() {
    }

    public ArrayList<Faq> select() throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call faq_FindAll}");
            resultSet = cs.executeQuery();

            ArrayList<Faq> list = new ArrayList<Faq>();
            while (resultSet.next()) {
                Faq faq = new Faq(resultSet.getInt("idFAQ"), resultSet.getInt("idLanguage"), resultSet.getInt("idCategory"), resultSet.getString("question"), resultSet.getString("answer"));
                list.add(faq);
            }
            return list;
        } finally {
            if (resultSet != null) {
                resultSet.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public Faq selectById(int id) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call faq_FindByPK(?)}");

            cs.setInt(1, id);

            resultSet = cs.executeQuery();
            Faq faq = null;
            while (resultSet.next()) {
                faq = new Faq(resultSet.getInt("idFAQ"), resultSet.getInt("idLanguage"), resultSet.getInt("idCategory"), resultSet.getString("question"), resultSet.getString("answer"));
            }
            return faq;
        } finally {
            if (resultSet != null) {
                resultSet.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public ArrayList<Faq> view(String lang, int idCat) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call faq_view(?,?)}");

            cs.setString(1, lang);
            cs.setInt(2, idCat);

            resultSet = cs.executeQuery();

            ArrayList<Faq> list = new ArrayList<Faq>();

            while (resultSet.next()) {
                Faq faq = new Faq(resultSet.getInt("idFAQ"), resultSet.getInt("idLanguage"), resultSet.getInt("idCategory"), resultSet.getString("question"), resultSet.getString("answer"));
                list.add(faq);
            }
            return list;
        } finally {
            if (resultSet != null) {
                resultSet.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public ArrayList<Faq> viewAll(String lang) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call faq_viewAll(?)}");

            cs.setString(1, lang);

            resultSet = cs.executeQuery();
            ArrayList<Faq> list = new ArrayList<Faq>();
            while (resultSet.next()) {
                Faq faq = new Faq(resultSet.getInt("idFAQ"), resultSet.getInt("idLanguage"), resultSet.getInt("idCategory"), resultSet.getString("category_name"), resultSet.getString("question"), resultSet.getString("answer"));
                list.add(faq);
            }
            return list;
        } finally {
            if (resultSet != null) {
                resultSet.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public void insert(Faq faq) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call faq_insert(?,?,?,?)}");

            cs.setInt(1, faq.getIdLanguage());
            cs.setInt(2, faq.getIdCategory());
            cs.setString(3, faq.getQuestion());
            cs.setString(4, faq.getAnswer());

            cs.execute();
        } finally {
            if (resultSet != null) {
                resultSet.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public boolean update(Faq faq) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call faq_Update(?,?,?,?,?)}");

            cs.setInt(1, faq.getIdFAQ());
            cs.setInt(2, faq.getIdLanguage());
            cs.setInt(3, faq.getIdCategory());
            cs.setString(4, faq.getQuestion());
            cs.setString(5, faq.getAnswer());

            cs.execute();
            return true;
        } finally {
            if (resultSet != null) {
                resultSet.close();
            }
            if (cs != null) {
                cs.close();
            }
            if (connection != null) {
                connection.close();
            }
        }
    }

    public boolean delete(int idFaq) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call faq_Delete(?)}");

            cs.setInt(1, idFaq);

            cs.execute();
            return true;
        } finally {
            if (resultSet != null) {
                resultSet.close();
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
