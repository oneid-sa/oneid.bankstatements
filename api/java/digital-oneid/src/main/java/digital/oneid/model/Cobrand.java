package digital.oneid.model;

public class Cobrand
{
    private String cobrandLogin;

    private String cobrandPassword;

    private String locale;

    public void setCobrandLogin(String cobrandLogin){
        this.cobrandLogin = cobrandLogin;
    }
    public String getCobrandLogin(){
        return this.cobrandLogin;
    }
    public void setCobrandPassword(String cobrandPassword){
        this.cobrandPassword = cobrandPassword;
    }
    public String getCobrandPassword(){
        return this.cobrandPassword;
    }
    public void setLocale(String locale){
        this.locale = locale;
    }
    public String getLocale(){
        return this.locale;
    }
}