/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

/**
 * Created by hubinotech on 12/03/20.
 */
public class GetAccountInfo
{
    private boolean includeInNetWorth;

    private String accountName;

    private boolean isManual;

    private String accountType;

    private String memo;

    private String accountNumber;

    private String accountStatus;

    private String lastUpdated;

    private boolean isAsset;

    private String createdDate;

    private String aggregationSource;

    private AmountCurrency balance;

    private String providerId;

    private int providerAccountId;

    @JsonProperty("CONTAINER")
    private String CONTAINER;

    private String nickname;

    private int id;

    private String providerName;
    @JsonIgnoreProperties(ignoreUnknown = true)
    private int interestRate;
    @JsonIgnoreProperties(ignoreUnknown = true)
    private String displayedName;
    @JsonIgnoreProperties(ignoreUnknown = true)
    private List<Dataset> dataset;
    @JsonIgnoreProperties(ignoreUnknown = true)
    private List<Holder> holder;
    @JsonIgnoreProperties(ignoreUnknown = true)
    private AutoRefresh autoRefresh;
    @JsonIgnoreProperties(ignoreUnknown = true)
    private AvailableBalance availableBalance;
    @JsonIgnoreProperties(ignoreUnknown = true)
    private CurrentBalance currentBalance;

    public void setIncludeInNetWorth(boolean includeInNetWorth){
        this.includeInNetWorth = includeInNetWorth;
    }
    public boolean getIncludeInNetWorth(){
        return this.includeInNetWorth;
    }
    public void setAccountName(String accountName){
        this.accountName = accountName;
    }
    public String getAccountName(){
        return this.accountName;
    }
    public void setIsManual(boolean isManual){
        this.isManual = isManual;
    }
    public boolean getIsManual(){
        return this.isManual;
    }
    public void setAccountType(String accountType){
        this.accountType = accountType;
    }
    public String getAccountType(){
        return this.accountType;
    }
    public void setMemo(String memo){
        this.memo = memo;
    }
    public String getMemo(){
        return this.memo;
    }
    public void setAccountNumber(String accountNumber){
        this.accountNumber = accountNumber;
    }
    public String getAccountNumber(){
        return this.accountNumber;
    }
    public void setAccountStatus(String accountStatus){
        this.accountStatus = accountStatus;
    }
    public String getAccountStatus(){
        return this.accountStatus;
    }
    public void setLastUpdated(String lastUpdated){
        this.lastUpdated = lastUpdated;
    }
    public String getLastUpdated(){
        return this.lastUpdated;
    }
    public void setIsAsset(boolean isAsset){
        this.isAsset = isAsset;
    }
    public boolean getIsAsset(){
        return this.isAsset;
    }
    public void setCreatedDate(String createdDate){
        this.createdDate = createdDate;
    }
    public String getCreatedDate(){
        return this.createdDate;
    }
    public void setAggregationSource(String aggregationSource){
        this.aggregationSource = aggregationSource;
    }
    public String getAggregationSource(){
        return this.aggregationSource;
    }
    public void setBalance(AmountCurrency balance){
        this.balance = balance;
    }
    public AmountCurrency getBalance(){
        return this.balance;
    }
    public void setProviderId(String providerId){
        this.providerId = providerId;
    }
    public String getProviderId(){
        return this.providerId;
    }
    public void setProviderAccountId(int providerAccountId){
        this.providerAccountId = providerAccountId;
    }
    public int getProviderAccountId(){
        return this.providerAccountId;
    }
    @JsonProperty("CONTAINER")
    public void setCONTAINER(String CONTAINER){
        this.CONTAINER = CONTAINER;
    }
    @JsonProperty("CONTAINER")
    public String getCONTAINER(){
        return this.CONTAINER;
    }
    public void setNickname(String nickname){
        this.nickname = nickname;
    }
    public String getNickname(){
        return this.nickname;
    }
    public void setId(int id){
        this.id = id;
    }
    public int getId(){
        return this.id;
    }
    public void setProviderName(String providerName){
        this.providerName = providerName;
    }
    public String getProviderName(){
        return this.providerName;
    }
    public void setAutoRefresh(AutoRefresh autoRefresh){
        this.autoRefresh = autoRefresh;
    }
    public AutoRefresh getAutoRefresh(){
        return this.autoRefresh;
    }
    public void setHolder(List<Holder> holder){
        this.holder = holder;
    }
    public List<Holder> getHolder(){
        return this.holder;
    }
    public void setAvailableBalance(AvailableBalance availableBalance){
        this.availableBalance = availableBalance;
    }
    public AvailableBalance getAvailableBalance(){
        return this.availableBalance;
    }
    public void setCurrentBalance(CurrentBalance currentBalance){
        this.currentBalance = currentBalance;
    }
    public CurrentBalance getCurrentBalance(){
        return this.currentBalance;
    }
    public void setInterestRate(int interestRate){
        this.interestRate = interestRate;
    }
    public int getInterestRate(){
        return this.interestRate;
    }
    public void setDisplayedName(String displayedName){
        this.displayedName = displayedName;
    }
    public String getDisplayedName(){
        return this.displayedName;
    }
    public void setDataset(List<Dataset> dataset){
        this.dataset = dataset;
    }
    public List<Dataset> getDataset(){
        return this.dataset;
    }
}