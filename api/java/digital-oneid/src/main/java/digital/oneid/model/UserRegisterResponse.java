package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 * Created by hubinotech on 25/03/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class UserRegisterResponse {
    private UserRegister user;
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
