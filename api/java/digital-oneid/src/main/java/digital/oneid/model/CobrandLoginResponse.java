package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class CobrandLoginResponse
{
    private long cobrandId;

    private String applicationId;

    private String locale;

    private CobrandSession session;

    private ErrorResponse errorResponse;

    public void setCobrandId(long cobrandId){
        this.cobrandId = cobrandId;
    }
    public long getCobrandId(){
        return this.cobrandId;
    }
    public void setApplicationId(String applicationId){
        this.applicationId = applicationId;
    }
    public String getApplicationId(){
        return this.applicationId;
    }
    public void setLocale(String locale){
        this.locale = locale;
    }
    public String getLocale(){
        return this.locale;
    }
    public void setSession(CobrandSession session){
        this.session = session;
    }
    public CobrandSession getSession(){
        return this.session;
    }

    public void setErrorResponse(ErrorResponse errorResponse){
        this.errorResponse = errorResponse;
    }
    public ErrorResponse getErrorResponse(){
        return this.errorResponse;
    }
}