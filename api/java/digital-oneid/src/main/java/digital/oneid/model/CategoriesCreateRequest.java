package digital.oneid.model;

/**
 * Created by hubinotech on 03/05/20.
 */
public class CategoriesCreateRequest {

    private String username;
    private String categoryName;
    private long parentCategoryId;
    private String uniqueidentifier;

    public void setUniqueidentifier(String UniqueIdentifier)
    {
        uniqueidentifier = UniqueIdentifier;
    }

    public String getUniqueidentifier()
    {
        return uniqueidentifier;
    }

    public String getUsername() {
        return username;
    }
    public void setUsername(String username) {
        this.username = username;
    }

    public String getCategoryName() {
        return categoryName;
    }
    public void setCategoryName(String categoryName) {
        this.categoryName = categoryName;
    }

    public long getParentCategoryId() {
        return parentCategoryId;
    }
    public void setParentCategoryId(long parentCategoryId) {
        this.parentCategoryId = parentCategoryId;
    }
}
