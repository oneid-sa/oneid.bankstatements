package digital.oneid.model;

import javax.persistence.*;

/**
 * Created by hubinotech on 25/03/20.
 */
@Entity
@Table(name = "cobrand_session_token")
public class TableCobrandSession {

    @Id
    @GeneratedValue
    private int cobsesid;
    @Column
    private String cobrandtoken;
    @Column
    private String jwttoken;
    @Column
    private String cobrandname;

    public String getCobrandSessionToken() {
        return cobrandtoken;
    }

    public void setCobrandSessionToken(String cobrandtoken) {
        this.cobrandtoken = cobrandtoken;
    }

    public String getJwtToken() {
        return jwttoken;
    }

    public void setJwtToken(String jwttoken) {
        this.jwttoken = jwttoken;
    }

    public String getCobrandName() {
        return cobrandname;
    }

    public void setCobrandName(String cobrandname) {
        this.cobrandname = cobrandname;
    }

    public int getCobSessionAIID() {
        return cobsesid;
    }

    public void setCobSessionAIID(int cobsesid) {
        this.cobsesid = cobsesid;
    }
}
