package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;

public class RunRuleRequest {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String accountHolderIdentifier;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String uniqueReference;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String ruleId;

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

    public void setRuleId(String RuleId)
    {
        ruleId = RuleId;
    }

    public String getRuleId()
    {
        return ruleId;
    }
}
