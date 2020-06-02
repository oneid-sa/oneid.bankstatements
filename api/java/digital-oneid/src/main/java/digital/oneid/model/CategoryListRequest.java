package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;

public class CategoryListRequest {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String accountHolderIdentifier;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String uniqueReference;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private boolean cobrandLevel;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private boolean userLevel;


    public void setCobrandLevel(boolean IsCobrandLevel)
    {
        cobrandLevel = IsCobrandLevel;
    }

    public boolean getCobrandLevel()
    {
        return cobrandLevel;
    }

    public void setUserLevel(boolean IsUserLevel)
    {
        userLevel = IsUserLevel;
    }

    public boolean getUserLevel()
    {
        return userLevel;
    }

    public void setAccountHolderIdentifier(String AccountHolderIdentifier)
    {
        this.accountHolderIdentifier = AccountHolderIdentifier;
    }

    public String getAccountHolderIdentifier()
    {
        return accountHolderIdentifier;
    }

    public void setUniqueReference(String UniqueReference)
    {
        this.uniqueReference = UniqueReference;
    }

    public String getUniqueReference()
    {
        return uniqueReference;
    }
}
