package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;

/**
 * Created by hubinotech on 25/03/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class UserRegisterResponse {
    private UserRegister user;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private ErrorResponse errorResponse;
    public void setUser(UserRegister user){
        this.user = user;
    }
    public UserRegister getUser(){
        return this.user;
    }
    public void setErrorResponse(ErrorResponse errorResponse){
        this.errorResponse = errorResponse;
    }
    public ErrorResponse getErrorResponse(){
        return this.errorResponse;
    }
}
