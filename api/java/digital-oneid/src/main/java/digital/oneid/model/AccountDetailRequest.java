package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;
import org.springframework.web.bind.annotation.RequestParam;

public class AccountDetailRequest {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String accountHolderIdentifier;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String uniqueReference;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private long accountid;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private boolean isLatest;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String status;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String container;

    public void setContainer(String Container)
    {
        container = Container;
    }

    public String getContainer()
    {
        return container;
    }

    public void setStatus(String Status)
    {
        status = Status;
    }

    public String getStatus()
    {
        return status;
    }

    public void setIsLatest(boolean IsLatest)
    {
        isLatest = IsLatest;
    }

    public boolean getIsLatest()
    {
        return isLatest;
    }

    public void setAccountId(long AccountID)
    {
        this.accountid = AccountID;
    }

    public long getAccountId()
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


}
