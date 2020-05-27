package digital.oneid.model;

import javax.persistence.*;

/**
 * Created by hubinotech on 26/03/20.
 */
@Entity
@Table(name = "user_session_token")
public class TableUserSessionToken {
    @Id
    @GeneratedValue
    private int id;
    @Column
    private int usessionid;
    @Column
    private String usersessiontoken;
    @Column
    private String jwttoken;

    public String getUserSessionToken() {
        return usersessiontoken;
    }

    public void setUserSessionToken(String usersessiontoken) {
        this.usersessiontoken = usersessiontoken;
    }

    public String getJwttoken() {
        return jwttoken;
    }

    public void setJwttoken(String jwttoken) {
        this.jwttoken = jwttoken;
    }
}
