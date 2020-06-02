package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;
import org.springframework.web.bind.annotation.RequestParam;

public class AccountTransactionsRequest {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String accountHolderIdentifier;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String uniqueReference;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String container;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String accountid;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String fromDate;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String toDate;

    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String categoryId;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String categoryType;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String highLevelCategoryId;


    public void setFromDate(String FromDate)
    {
        fromDate = FromDate;
    }

    public String getFromDate()
    {
        return fromDate;
    }

    public void setToDate(String ToDate)
    {
        toDate = ToDate;
    }

    public String getToDate()
    {
        return toDate;
    }

    public void setCategoryId(String CategoryId)
    {
        categoryId = CategoryId;
    }

    public String getCategoryId()
    {
        return categoryId;
    }

    public void setCategoryType(String CategoryType)
    {
        categoryType = CategoryType;
    }

    public String getCategoryType()
    {
        return categoryType;
    }

    public void setHighLevelCategoryId(String HighLevelCategoryId)
    {
        highLevelCategoryId = HighLevelCategoryId;
    }

    public String getHighLevelCategoryId()
    {
        return highLevelCategoryId;
    }


    public void setAccountid(String AccountID)
    {
        this.accountid = AccountID;
    }

    public String getAccountid()
    {
        return accountid;
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

    public void setContainer(String Container)
    {
        container = Container;
    }

    public String getContainer()
    {
        return container;
    }
}
