package Model;

import java.io.Serializable;
import java.util.ArrayList;

/**
 *
 * @author ASerdar
 */
public class FaqCategories implements Serializable {

    private int idFAQCategories;
    private int idLanguage;
    private String categoryName;
    private String categoryDescription;
    private ArrayList<Faq> faqList = new ArrayList<Faq>();

    public FaqCategories() {
    }

    public FaqCategories(int idFAQCategories, int idLanguage, String categoryName, String categoryDescription) {
        this.idFAQCategories = idFAQCategories;
        this.idLanguage = idLanguage;
        this.categoryName = categoryName;
        this.categoryDescription = categoryDescription;

    }

    public FaqCategories(int idFAQCategories, int idLanguage, String categoryName, String categoryDescription, ArrayList<Faq> faqList) {
        this.idFAQCategories = idFAQCategories;
        this.idLanguage = idLanguage;
        this.categoryName = categoryName;
        this.categoryDescription = categoryDescription;
        this.faqList = faqList;
    }

    public String getCategoryDescription() {
        return categoryDescription;
    }

    public void setCategoryDescription(String categoryDescription) {
        this.categoryDescription = categoryDescription;
    }

    public String getCategoryName() {
        return categoryName;
    }

    public void setCategoryName(String categoryName) {
        this.categoryName = categoryName;
    }

    public int getIdFAQCategories() {
        return idFAQCategories;
    }

    public void setIdFAQCategories(int idFAQCategories) {
        this.idFAQCategories = idFAQCategories;
    }

    public int getIdLanguage() {
        return idLanguage;
    }

    public void setIdLanguage(int idLanguage) {
        this.idLanguage = idLanguage;
    }

    public ArrayList<Faq> getFaqList() {
        return faqList;
    }

    public void setFaqList(ArrayList<Faq> faqList) {
        this.faqList = faqList;
    }

   

   
}
