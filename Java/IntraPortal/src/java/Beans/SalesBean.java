package Beans;

import Controller.BussinesLayer.MessageProvider;
import Controller.DataLayer.PricingAdapter;
import Controller.DataLayer.SalesAdapter;
import Model.PaymentView;
import Model.Pricing;
import Model.Sales;
import java.io.IOException;
import java.io.Serializable;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.annotation.PostConstruct;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpServletRequest;
import org.apache.jasper.tagplugins.jstl.core.Redirect;
import org.apache.shiro.SecurityUtils;

/**
 *
 * @author ASerdar
 */
@ManagedBean(name = "SalesBean")
@ViewScoped
public class SalesBean implements Serializable {

    SalesAdapter adapter = new SalesAdapter();
    private int idSales;
    private int idMember;
    private int idPricing;
    private String date;
    private String time;
    private boolean isApproved;
    private Pricing pricing;
    private ArrayList<PaymentView> list;
    private String paymentType = "havale";

    public SalesBean() {
    }

    @PostConstruct
    public void init() {
        try {
            // System.out.println(this.getIdPricing()); 
            idMember = Integer.parseInt(SecurityUtils.getSubject().getSession().getAttribute("UserID").toString());
            idPricing = Integer.parseInt(SecurityUtils.getSubject().getSession().getAttribute("buyId").toString());
            pricing = new PricingAdapter().selectById(idPricing);
            FacesContext context = FacesContext.getCurrentInstance();
            HttpServletRequest request = (HttpServletRequest) context.getExternalContext().getRequest();

            if (request.getParameter("idSales") != null) {
                this.idSales = Integer.parseInt(request.getParameter("idSales"));
            }
        } catch (Exception ex) {
            Logger.getLogger(SalesBean.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public int getIdSales() {
        return idSales;
    }

    public void setIdSales(int idSales) {
        this.idSales = idSales;
    }

    public String getPaymentType() {
        return paymentType;
    }

    public void setPaymentType(String paymentType) {
        this.paymentType = paymentType;
    }

    public int getIdMember() {
        return idMember;
    }

    public void setIdMember(int idMember) {
        this.idMember = idMember;
    }

    public int getIdPricing() {
        return idPricing;
    }

    public void setIdPricing(int idPricing) {
        this.idPricing = idPricing;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public boolean getIsApproved() {
        return isApproved;
    }

    public void setIsApproved(boolean isApproved) {
        this.isApproved = isApproved;
    }

    public Pricing getPricing() {
        return pricing;
    }

    public void setPricing(Pricing pricing) {
        this.pricing = pricing;
    }

    public ArrayList<PaymentView> getList() {
        try {
            return adapter.view();
        } catch (SQLException ex) {
            Logger.getLogger(SalesBean.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    public ArrayList<PaymentView> getPendingList() {
        try {
            ArrayList<PaymentView> plist = new ArrayList<PaymentView>();
            list = adapter.view();


            for (PaymentView item : this.list) {
                if (item.getIsapproved() == 0) {
                    plist.add(item);
                }
            }
            return plist;


        } catch (SQLException ex) {
            Logger.getLogger(SalesBean.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }

    }

    public void setList(ArrayList<PaymentView> list) {
        this.list = list;
    }

    public void add() {
        try {


            Sales sl = new Sales(0, idMember, idPricing, null, false);

            adapter.insert(sl);

            FacesContext.getCurrentInstance().getExternalContext().redirect("shop_finish.xhtml");

        } catch (Exception ex) {
            Logger.getLogger(SalesBean.class.getName()).log(Level.SEVERE, null, ex);
            FacesMessage error = new FacesMessage(FacesMessage.SEVERITY_ERROR, new MessageProvider().getValue("message.error"), new MessageProvider().getValue("message.unsuccess"));
            FacesContext.getCurrentInstance().addMessage(null, error);

        }
    }

    public String redirect() throws IOException {
            FacesContext.getCurrentInstance().getExternalContext().redirect("buy.xhtml");

        return "buy.xhtml";
    }

    public void update() {
        try {

            Sales sl = adapter.selectById(idSales);
            sl.setDate(date + " " + time);
            adapter.update(sl);

            FacesMessage msg = new FacesMessage(FacesMessage.SEVERITY_INFO, new MessageProvider().getValue("message.info"), new MessageProvider().getValue("message.edit"));
            FacesContext.getCurrentInstance().addMessage(null, msg);

        } catch (Exception ex) {
            Logger.getLogger(SalesBean.class.getName()).log(Level.SEVERE, null, ex);
            FacesMessage error = new FacesMessage(FacesMessage.SEVERITY_ERROR, new MessageProvider().getValue("message.error"), new MessageProvider().getValue("message.unsuccess"));
            FacesContext.getCurrentInstance().addMessage(null, error);

        }
    }

    public void approve(PaymentView p) {

        try {
            Sales sl = adapter.selectById(p.getIdSales());
            
            if (sl.getIsApproved()) {
                sl.setIsApproved(false);
            } else {
                sl.setIsApproved(true);
            }
            adapter.update(sl);

            FacesMessage msg = new FacesMessage(FacesMessage.SEVERITY_INFO, new MessageProvider().getValue("message.info"), new MessageProvider().getValue("message.done"));
            FacesContext.getCurrentInstance().addMessage(null, msg);

        } catch (Exception ex) {
            Logger.getLogger(SalesBean.class.getName()).log(Level.SEVERE, null, ex);
            FacesMessage error = new FacesMessage(FacesMessage.SEVERITY_ERROR, new MessageProvider().getValue("message.error"), new MessageProvider().getValue("message.unsuccess"));
            FacesContext.getCurrentInstance().addMessage(null, error);
        }
    }

    public void delete(PaymentView p) {

        try {
            adapter.delete(p.getIdSales());

            FacesMessage msg = new FacesMessage(FacesMessage.SEVERITY_INFO, new MessageProvider().getValue("message.info"), new MessageProvider().getValue("message.delete"));
            FacesContext.getCurrentInstance().addMessage(null, msg);

        } catch (Exception ex) {
            Logger.getLogger(SalesBean.class.getName()).log(Level.SEVERE, null, ex);
            FacesMessage error = new FacesMessage(FacesMessage.SEVERITY_ERROR, new MessageProvider().getValue("message.error"), new MessageProvider().getValue("message.unsuccess"));
            FacesContext.getCurrentInstance().addMessage(null, error);

        }
    }
}
