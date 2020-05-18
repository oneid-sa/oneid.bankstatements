package digital.oneid.model;

import javax.persistence.*;

/**
 * Created by hubinotech on 04/05/20.
 */

@Entity
@Table(name = "audit_log")
public class TableAuditLog {
    @Id
    @GeneratedValue
    private int id;
    @Column
    private int companyId;
    @Column
    private int  roleId;
    @Column
    private String message;
    @Column
    private String createdAt;

    public int getRoleId() {
        return roleId;
    }
    public void setRoleId(int roleId) {
        this.roleId = roleId;
    }

    public String getMessage() {
        return message;
    }
    public void setMessage(String message) {
        this.message = message;
    }

    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
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
}
