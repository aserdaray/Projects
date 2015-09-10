package Model;

import java.io.Serializable;

/**
 *
 * @author asay
 */
public class Users implements Serializable {

    private int idUser;
    private int idAgent;
    private int idCompany;
    private String username;
    private String password;
    private String userType;
    private short isActive;
    private String apiUsername;
    private String apiPassword;
    private int idApi;
    

    public Users() {
    }

    public Users(int idUser) {
        this.idUser = idUser;
    }

    public Users(int idUser, int idAgent, int idCompany, String username, String password, String userType, short isActive, String apiUsername, String apiPassword, int idApi) {
        this.idUser = idUser;
        this.idAgent = idAgent;
        this.idCompany = idCompany;
        this.username = username;
        this.password = password;
        this.userType = userType;
        this.isActive = isActive;
        this.apiUsername = apiUsername;
        this.apiPassword = apiPassword;
        this.idApi = idApi;
    }

    public Users(int idUser, String password) {
        this.idUser = idUser;
        this.password = password;
    }
    
    

    public int getIdUser() {
        return idUser;
    }

    public void setIdUser(int idUser) {
        this.idUser = idUser;
    }

    public int getIdAgent() {
        return idAgent;
    }

    public void setIdAgent(int idAgent) {
        this.idAgent = idAgent;
    }

    public int getIdCompany() {
        return idCompany;
    }

    public void setIdCompany(int idCompany) {
        this.idCompany = idCompany;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getUserType() {
        return userType;
    }

    public void setUserType(String userType) {
        this.userType = userType;
    }

    public short getIsActive() {
        return isActive;
    }

    public void setIsActive(short isActive) {
        this.isActive = isActive;
    }

    public String getApiUsername() {
        return apiUsername;
    }

    public void setApiUsername(String apiUsername) {
        this.apiUsername = apiUsername;
    }

    public String getApiPassword() {
        return apiPassword;
    }

    public void setApiPassword(String apiPassword) {
        this.apiPassword = apiPassword;
    }

    public int getIdApi() {
        return idApi;
    }

    public void setIdApi(int idApi) {
        this.idApi = idApi;
    }
    
}
