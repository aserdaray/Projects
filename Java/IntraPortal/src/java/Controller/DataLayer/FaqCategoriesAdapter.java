package Controller.DataLayer;

import Model.Faq;
import Model.FaqCategories;
import com.mysql.jdbc.Connection;
import java.sql.CallableStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author ASerdar
 */
public class FaqCategoriesAdapter {

    private Connection connection = null;
    CallableStatement cs = null;
    private ResultSet resultSet = null;

    public FaqCategoriesAdapter() {
    }

    public ArrayList<FaqCategories> select() throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call faq_categories_FindAll}");
            resultSet = cs.executeQuery();

            ArrayList<FaqCategories> list = new ArrayList<FaqCategories>();
            while (resultSet.next()) {
                FaqCategories faqc = new FaqCategories(resultSet.getInt("idFAQ_Categories"), resultSet.getInt("idLanguage"), resultSet.getString("categoy_name"), resultSet.getString("category_description"));
                list.add(faqc);
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

    public FaqCategories selectById(int id) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call faq_categories_FindByPK(?)}");

            cs.setInt(1, id);

            resultSet = cs.executeQuery();
            FaqCategories faqc = null;
            while (resultSet.next()) {
                faqc = new FaqCategories(resultSet.getInt("idFAQ_Categories"), resultSet.getInt("idLanguage"), resultSet.getString("category_name"), resultSet.getString("category_description"));
            }
            return faqc;
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

    public ArrayList<FaqCategories> view(String lang) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{call faq_categories_view(?)}");

            cs.setString(1, lang);

            resultSet = cs.executeQuery();

            ArrayList<FaqCategories> list = new ArrayList<FaqCategories>();
            while (resultSet.next()) {
                FaqAdapter faqadp = new FaqAdapter();
                ArrayList<Faq> fqlist = faqadp.view(lang, resultSet.getInt("idFAQ_Categories"));

                FaqCategories faqc = new FaqCategories(resultSet.getInt("idFAQ_Categories"), resultSet.getInt("idLanguage"), resultSet.getString("category_name"), resultSet.getString("category_description"), fqlist);
                list.add(faqc);
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

    public void insert(FaqCategories faqc) throws SQLException {
        try {

            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call faq_categories_insert(?,?,?)}");

            cs.setInt(1, faqc.getIdLanguage());
            cs.setString(2, faqc.getCategoryName());
            cs.setString(3, faqc.getCategoryDescription());

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

    public boolean update(FaqCategories faqc) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call faq_categories_Update(?,?,?,?)}");

            cs.setInt(1, faqc.getIdFAQCategories());
            cs.setInt(2, faqc.getIdLanguage());
            cs.setString(3, faqc.getCategoryName());
            cs.setString(4, faqc.getCategoryDescription());

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

    public boolean delete(int idFaqc) throws SQLException {
        try {
            connection = ConnectionFactory.getInstance().getConnection();
            cs = connection.prepareCall("{Call faq_categories_Delete(?)}");

            cs.setInt(1, idFaqc);

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