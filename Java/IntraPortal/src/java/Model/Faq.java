/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.io.Serializable;
import javax.persistence.*;

/**
 *
 * @author ASerdar
 */
public class Faq implements Serializable {
    private int idFAQ;
    private int idLanguage;
    private int idCategory;
    private String categoryName;
    private String question;
    private String answer;

    public Faq() {
    }

    public Faq(int idFAQ, int idLanguage, int idCategory, String question, String answer) {
        this.idFAQ = idFAQ;
        this.idLanguage = idLanguage;
        this.idCategory = idCategory;
        this.question = question;
        this.answer = answer;
    }

    public Faq(int idFAQ, int idLanguage, int idCategory, String categoryName, String question, String answer) {
        this.idFAQ = idFAQ;
        this.idLanguage = idLanguage;
        this.idCategory = idCategory;
        this.categoryName = categoryName;
        this.question = question;
        this.answer = answer;
    }
    
    
    public Faq(int idFAQ) {
        this.idFAQ = idFAQ;
    }

    public int getIdFAQ() {
        return idFAQ;
    }

    public void setIdFAQ(int idFAQ) {
        this.idFAQ = idFAQ;
    }

    public int getIdLanguage() {
        return idLanguage;
    }

    public void setIdLanguage(int idLanguage) {
        this.idLanguage = idLanguage;
    }

    public int getIdCategory() {
        return idCategory;
    }

    public void setIdCategory(int idCategory) {
        this.idCategory = idCategory;
    }

    public String getQuestion() {
        return question;
    }

    public void setQuestion(String question) {
        this.question = question;
    }

    public String getAnswer() {
        return answer;
    }

    public void setAnswer(String answer) {
        this.answer = answer;
    }

    public String getCategoryName() {
        return categoryName;
    }

    public void setCategoryName(String categoryName) {
        this.categoryName = categoryName;
    }
    
    
}
