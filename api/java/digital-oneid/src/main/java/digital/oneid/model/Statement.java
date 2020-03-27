/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

public class Statement
{
    private int id;

    private int accountId;

    private String statementDate;

    private String dueDate;

    private String lastPaymentDate;

    private String lastUpdated;

    private AmountCurrency amountDue;

    private AmountCurrency lastPaymentAmount;

    private boolean isLatest;

    public void setId(int id){
        this.id = id;
    }
    public int getId(){
        return this.id;
    }
    public void setAccountId(int accountId){
        this.accountId = accountId;
    }
    public int getAccountId(){
        return this.accountId;
    }
    public void setStatementDate(String statementDate){
        this.statementDate = statementDate;
    }
    public String getStatementDate(){
        return this.statementDate;
    }
    public void setDueDate(String dueDate){
        this.dueDate = dueDate;
    }
    public String getDueDate(){
        return this.dueDate;
    }
    public void setLastPaymentDate(String lastPaymentDate){
        this.lastPaymentDate = lastPaymentDate;
    }
    public String getLastPaymentDate(){
        return this.lastPaymentDate;
    }
    public void setLastUpdated(String lastUpdated){
        this.lastUpdated = lastUpdated;
    }
    public String getLastUpdated(){
        return this.lastUpdated;
    }
    public void setAmountDue(AmountCurrency amountDue){
        this.amountDue = amountDue;
    }
    public AmountCurrency getAmountDue(){
        return this.amountDue;
    }
    public void setLastPaymentAmount(AmountCurrency lastPaymentAmount){
        this.lastPaymentAmount = lastPaymentAmount;
    }
    public AmountCurrency getLastPaymentAmount(){
        return this.lastPaymentAmount;
    }
    public void setIsLatest(boolean isLatest){
        this.isLatest = isLatest;
    }
    public boolean getIsLatest(){
        return this.isLatest;
    }
}
