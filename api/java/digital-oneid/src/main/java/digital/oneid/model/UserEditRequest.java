package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;

/**
 * Created by hubinotech on 23/05/20.
 */
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class UserEditRequest {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private UserEdit user;
    private int userId;

    public void setUserId(int userId){
        this.userId = userId;
    }
    public int getUserId(){
        return this.userId;
    }

    public void setUser(UserEdit user){
        this.user = user;
    }
    public UserEdit getUser(){
        return this.user;
    }
}
