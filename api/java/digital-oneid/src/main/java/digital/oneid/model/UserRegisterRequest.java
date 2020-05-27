package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;

/**
 * Created by hubinotech on 25/03/20.
 */
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class UserRegisterRequest {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private UserRegister user;

    public void setUser(UserRegister user){
        this.user = user;
    }
    public UserRegister getUser(){
        return this.user;
    }
}
