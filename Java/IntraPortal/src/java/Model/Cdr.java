package Model;

import WebService.DATEANDTIME;
import WebService.FaxTypeEnum;
import javax.xml.bind.annotation.XmlElement;

/**
 *
 * @author asay
 */
public class Cdr {
    private int messageid;
    private int userid;
    private int companyid;
    private String desfaxnum;
    private String errorcode;
    private String countryname;
    private String countryprefix;
    private String creationtimed;
    private String faxtype;
    private int duration;
    private int pages;
    private String emaildestination;
    private String subject;
    private String imagefileprefix;
    private int faxdataid;
   
    private double rateuserm;
    private double ratecompanym;
    private double rateagentm;
    private double userm;
    private double companym;
    private double agentm;

    public Cdr() {
    
    }

    public int getMessageid() {
        return messageid;
    }

    public void setMessageid(int messageid) {
        this.messageid = messageid;
    }

    public int getUserid() {
        return userid;
    }

    public void setUserid(int userid) {
        this.userid = userid;
    }

    public int getCompanyid() {
        return companyid;
    }

    public void setCompanyid(int companyid) {
        this.companyid = companyid;
    }

    public String getDesfaxnum() {
        return desfaxnum;
    }

    public void setDesfaxnum(String desfaxnum) {
        this.desfaxnum = desfaxnum;
    }

    public String getErrorcode() {
        return errorcode;
    }

    public void setErrorcode(String errorcode) {
        this.errorcode = errorcode;
    }

    public String getCountryname() {
        return countryname;
    }

    public void setCountryname(String countryname) {
        this.countryname = countryname;
    }

    public String getCountryprefix() {
        return countryprefix;
    }

    public void setCountryprefix(String countryprefix) {
        this.countryprefix = countryprefix;
    }

    public String getCreationtimed() {
        return creationtimed;
    }

    public void setCreationtimed(String creationtimed) {
        this.creationtimed = creationtimed;
    }

    public String getFaxtype() {
        return faxtype;
    }

    public void setFaxtype(String faxtype) {
        this.faxtype = faxtype;
    }

    public int getDuration() {
        return duration;
    }

    public void setDuration(int duration) {
        this.duration = duration;
    }

    public int getPages() {
        return pages;
    }

    public void setPages(int pages) {
        this.pages = pages;
    }

    public String getEmaildestination() {
        return emaildestination;
    }

    public void setEmaildestination(String emaildestination) {
        this.emaildestination = emaildestination;
    }

    public String getSubject() {
        return subject;
    }

    public void setSubject(String subject) {
        this.subject = subject;
    }

    public String getImagefileprefix() {
        return imagefileprefix;
    }

    public void setImagefileprefix(String imagefileprefix) {
        this.imagefileprefix = imagefileprefix;
    }

    public int getFaxdataid() {
        return faxdataid;
    }

    public void setFaxdataid(int faxdataid) {
        this.faxdataid = faxdataid;
    }

    public double getRateuserm() {
        return rateuserm;
    }

    public void setRateuserm(double rateuserm) {
        this.rateuserm = rateuserm;
    }

    public double getRatecompanym() {
        return ratecompanym;
    }

    public void setRatecompanym(double ratecompanym) {
        this.ratecompanym = ratecompanym;
    }

    public double getRateagentm() {
        return rateagentm;
    }

    public void setRateagentm(double rateagentm) {
        this.rateagentm = rateagentm;
    }

    public double getUserm() {
        return userm;
    }

    public void setUserm(double userm) {
        this.userm = userm;
    }

    public double getCompanym() {
        return companym;
    }

    public void setCompanym(double companym) {
        this.companym = companym;
    }

    public double getAgentm() {
        return agentm;
    }

    public void setAgentm(double agentm) {
        this.agentm = agentm;
    }
}
