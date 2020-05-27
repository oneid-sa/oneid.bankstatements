package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;

/**
 * Created by hubinotech on 23/05/20.
 */
public class EditUserRequestYodlee {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private UserEdit user;

    public void setUser(UserEdit user){
        this.user = user;
    }
    public UserEdit getUser(){
        return this.user;
    }
}
