package digital.oneid.model;

import javax.persistence.*;

/**
 * Created by hubinotech on 03/05/20.
 */
@Entity
@Table(name = "transaction_category")
public class TableTransactionCategory {
    @Id
    @GeneratedValue
    private int id;
    @Column
    private int companyId;
    @Column
    private int userId;
    @Column
    private String categoryName;
    @Column
    private long parentId;
    @Column
    private String createdAt;
    @Column
    private String updatedAt;


    public String getCategoryName() {
        return categoryName;
    }
    public void setCategoryName(String categoryName) {
        this.categoryName = categoryName;
    }

    public long getParentId() {
        return parentId;
    }
    public void setParentId(long parentId) {
        this.parentId = parentId;
    }

    public int getUserId() {
        return userId;
    }
    public void setUserId(int userId) {
        this.userId = userId;
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

    public String getUpdatedAt() {
        return updatedAt;
    }
    public void setUpdatedAt(String updatedAt) {
        this.updatedAt = updatedAt;
    }
}
