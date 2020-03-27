package digital.oneid.model;

/**
 * Created by hubinotech on 26/03/20.
 */
public class FastlinkResponse {

    private String fastlink;

    private String jwttoken;

    private long finappid;

    private boolean redirectReq;

    private String callbackUrl;

    public void setFastLink(String fastlink){
        this.fastlink = fastlink;
    }
    public String getFastLink(){
        return this.fastlink;
    }
    public void setFastLinkJwtToken(String jwttoken){
        this.jwttoken = jwttoken;
    }
    public String getFastLinkJwtToken(){
        return this.jwttoken;
    }
    public void setFinAppid(long finappid){
        this.finappid = finappid;
    }
    public long getFinAppid(){
        return this.finappid;
    }
    public void setRedirectReq(boolean redirectReq){
        this.redirectReq = redirectReq;
    }
    public boolean getRedirectReq(){
        return this.redirectReq;
    }
    public void setCallbackUrl(String callbackUrl){
        this.callbackUrl = callbackUrl;
    }
    public String getCallbackUrl(){
        return this.callbackUrl;
    }
}
