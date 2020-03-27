/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import javax.persistence.*;

@Entity
@Table(name = "user_registration")
public class TableUserRegistration {

    @Id
    @GeneratedValue
    private int uid;
    @Column
    private String username;
    @Column
    private String password;
    @Column
    private int role_id;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public int getRoleID() {
        return role_id;
    }

    public void setRoleID(int role_id) {
        this.role_id = role_id;
    }


    public int getUserID() {
        return uid;
    }

    public void setUserID(int uid) {
        this.uid = uid;
    }
}