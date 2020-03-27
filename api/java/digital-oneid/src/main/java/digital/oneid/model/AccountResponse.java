/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import java.util.List;
public class AccountResponse
{
    private List<GetAccountInfo> account;

    public void setAccount(List<GetAccountInfo> account){
        this.account = account;
    }
    public List<GetAccountInfo> getAccount(){
        return this.account;
    }
}