package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;

public class NewSessionRequest {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String accountHolderIdentifier;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String emailAddress;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String locale = "en_ZA";

    public void setAccountHolderIdentifier(String AccountHolderIdentifier)
    {
        this.accountHolderIdentifier = AccountHolderIdentifier;
    }

    public String getAccountHolderIdentifier()
    {
        return accountHolderIdentifier;
    }


    public void setEmailAddress(String EmailAddress) {
        this.emailAddress = EmailAddress;
    }

    public String getEmailAddress()
    {
        return emailAddress;
    }

    public void setLocale(String Locale)
    {
        this.locale = Locale;
    }

    public String getLocale()
    {
        return locale;
    }
}
