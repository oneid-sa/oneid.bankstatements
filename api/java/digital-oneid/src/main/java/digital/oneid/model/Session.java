package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 * Created by hubinotech on 26/03/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class Session
{
    private String userSession;

    public void setUserSession(String userSession){
        this.userSession = userSession;
    }
    public String getUserSession(){
        return this.userSession;
    }
}