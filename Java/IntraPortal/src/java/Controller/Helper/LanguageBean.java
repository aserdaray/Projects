package Controller.Helper;

/**
 *
 * @author ASerdar
 */
import Controller.DataLayer.LanguageAdapter;
import Model.Languages;
import java.io.Serializable;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Locale;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import javax.faces.event.ValueChangeEvent;

@ManagedBean(name = "LanguageBean")
@SessionScoped
public class LanguageBean implements Serializable {

    private static final long serialVersionUID = 1L;
    private String localeCode;
    private static Map<String, Languages> countries;
    private Locale locale = FacesContext.getCurrentInstance().getViewRoot().getLocale();

    static {
        try {
            countries = new LinkedHashMap<String, Languages>();

            ArrayList<Languages> list = new LanguageAdapter().select();
            for (Languages lang : list) {
                countries.put(lang.getIsoCode(), lang);
            }
        } catch (SQLException ex) {
            Logger.getLogger(LanguageBean.class.getName()).log(Level.SEVERE, null, ex);
        }


    }

    public Map<String, Languages> getCountriesInMap() {
        return countries;
    }

    public String getLocaleCode() {
        return localeCode;
    }

    public void setLocaleCode(String localeCode) {
        this.localeCode = localeCode;
    }

    public Locale getLocale() {
        return locale;
    }

    public void setLocale(Locale locale) {
        this.locale = locale;
        FacesContext.getCurrentInstance().getViewRoot().setLocale(locale);

    }

    public String getLanguage() {
        return locale.getLanguage();
    }

    public void setLanguage(String language) {
        locale = new Locale(language);
        FacesContext.getCurrentInstance().getViewRoot().setLocale(locale);

    }

    //value change event listener
    public void countryLocaleCodeChanged(ValueChangeEvent e) {

        String newLocaleValue = e.getNewValue().toString();

        //loop country map to compare the locale code
        for (Map.Entry<String, Languages> entry : countries.entrySet()) {
            if (entry.getValue().toString().equals(newLocaleValue)) {
                FacesContext.getCurrentInstance().getViewRoot().setLocale(entry.getValue().getLocale());
//                SecurityUtils.getSubject().getSession().setAttribute("PrefLocale", entry.getValue().getLocale());
                //  setLanguage(entry.getValue().getLocale().getLanguage());
                setLocale(entry.getValue().getLocale());

            }
        }
    }

    public void LocaleCodeChange(String e) {
        String newLocaleValue = e;

        for (Map.Entry<String, Languages> entry : countries.entrySet()) {

            if (entry.getValue().getIsoCode().equals(newLocaleValue)) {

                FacesContext.getCurrentInstance().getViewRoot().setLocale(entry.getValue().getLocale());
//                SecurityUtils.getSubject().getSession().setAttribute("PrefLocale", entry.getValue().getLocale());

                // setLanguage(entry.getValue().getLocale().getLanguage());
                setLocale(entry.getValue().getLocale());
            }
        }
    }

    public static int getCurrentLanguageId() {

        return countries.get(FacesContext.getCurrentInstance().getViewRoot().getLocale().getLanguage().toString()).getIdLanguages();
    }
}
