package digital.oneid.model;

import javax.persistence.*;

/**
 * Created by hubinotech on 25/03/20.
 */
@Entity
@Table(name = "cobrandinfo")
public class TableCobrandInfo {
    @Id
    @GeneratedValue
    private int cid;
    @Column
    private String cobrandname;

    public String getUsername() {
        return cobrandname;
    }

    public void setUsername(String cobrandname) {
        this.cobrandname = cobrandname;
    }

}
