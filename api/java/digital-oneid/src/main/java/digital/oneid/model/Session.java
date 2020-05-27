package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;

/**
 * Created by hubinotech on 26/03/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_EMPTY)
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