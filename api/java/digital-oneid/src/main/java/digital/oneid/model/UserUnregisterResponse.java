package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;

@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class UserUnregisterResponse {

    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private ErrorResponse errorResponse;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String accountHolderIdentifier;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String uniqueReference;

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


    public void setErrorResponse(ErrorResponse errorResponse){
        this.errorResponse = errorResponse;
    }
    public ErrorResponse getErrorResponse(){
        return this.errorResponse;
    }
}
