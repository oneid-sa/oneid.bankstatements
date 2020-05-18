/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import javax.persistence.*;

@Entity
@Table(name = "user_accounts")
public class TableUserRegistration {

    @Id
    @GeneratedValue
    private int id;
    @Column
    private int companyId;
    @Column
    private String loginName;
    @Column
    private String email;
    @Column
    private String password;
    @Column
    private String createdAt;
    @Column
    private String updatedAt;
    @Column
    private long createdYodleeId;

    public String getLoginName() {
        return loginName;
    }
    public void setLoginName(String loginName) {
        this.loginName = loginName;
    }

    public String getPassword() {
        return password;
    }
    public void setPassword(String password) {
        this.password = password;
    }

    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }


    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }

    public long getCreatedYodleeId() {
        return createdYodleeId;
    }
    public void setCreatedYodleeId(long createdYodleeId) {
        this.createdYodleeId = createdYodleeId;
    }

    public int getCompanyId() {
        return companyId;
    }
    public void setCompanyId(int companyId) {
        this.companyId = companyId;
    }


    public String getCreatedAt() {
        return createdAt;
    }
    public void setCreatedAt(String createdAt) {
        this.createdAt = createdAt;
    }

    public String getUpdatedAt() {
        return updatedAt;
    }
    public void setUpdatedAt(String updatedAt) {
        this.updatedAt = updatedAt;
    }
}