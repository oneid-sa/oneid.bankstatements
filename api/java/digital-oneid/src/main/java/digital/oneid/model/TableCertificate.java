/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;
import javax.persistence.*;

@Entity
@Table(name = "certification_info")
public class TableCertificate {
    @Id
    @GeneratedValue
    private int cid;
    @Column
    private int uid;
    @Column
    private String privatekey;
    @Column
    private String issuerid;
    @Column
    private String appversion;

    public int getCerticiateInfoId() {
        return cid;
    }

    public void setCerticiateInfoId(int cid) {
        this.cid = cid;
    }

    public int getUserId() {
        return uid;
    }

    public void setUserId(int uid) {
        this.uid = uid;
    }

    public String getPrivateKey() {
        return privatekey;
    }

    public void setPrivateKey(String privatekey) {
        this.privatekey = privatekey;
    }

    public String getIssuerID() {
        return issuerid;
    }

    public void setIssuerID(String issuerid) {
        this.issuerid = issuerid;
    }

    public String getAppVersion() {
        return appversion;
    }

    public void setAppVersion(String appversion) {
        this.appversion = appversion;
    }
}
