package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;

public class NewSessionResponse {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String accountHolderIdentifier;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String uniqueReference;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String status;

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

    public void setStatus(String Status)
    {
        this.status = Status;
    }

    public String getStatus()
    {
        return status;

    }

}
