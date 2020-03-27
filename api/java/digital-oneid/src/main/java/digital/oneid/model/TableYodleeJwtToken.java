/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import javax.persistence.*;


@Entity
@Table(name = "yodlee_jwt_token_info")
public class TableYodleeJwtToken {
    @Id
    @GeneratedValue
    private int yid;
    @Column
    private int uid;
    @Column
    private String yodleejwttoken;
    @Column
    private long expiry;

    public int getYodleeTokenId() {
        return yid;
    }

    public void setYodleeTokenId(int yid) {
        this.yid = yid;
    }

    public int getUserId() {
        return uid;
    }

    public void setUserId(int uid) {
        this.uid = uid;
    }

    public String getYodleeJwtToken() {
        return yodleejwttoken;
    }

    public void setYodleeJwtToken(String yodleejwttoken) {
        this.yodleejwttoken = yodleejwttoken;
    }

    public long getExpiry() {
        return expiry;
    }

    public void setExpiry(long expiry) {
        this.expiry = expiry;
    }
}
