/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;
public class Provider
{
    @JsonProperty("PRIORITY")
    private String PRIORITY;

    private int id;

    private String name;

    private String loginUrl;

    private String baseUrl;

    private String favicon;

    private String logo;

    private String status;

    private boolean isConsentRequired;

    private String authType;

    private String languageISOCode;

    private String primaryLanguageISOCode;

    private String countryISOCode;

    private String lastModified;

    private String forgetPasswordUrl;

    private boolean isAutoRefreshEnabled;

    private List<ProviderDataset> dataset;

    private String isAddedByUser;

    @JsonProperty ("PRIORITY")
    public void setPRIORITY(String priority){
        this.PRIORITY = priority;
    }
    @JsonProperty("PRIORITY")
    public String getPRIORITY(){
        return this.PRIORITY;
    }
    public void setId(int id){
        this.id = id;
    }
    public int getId(){
        return this.id;
    }
    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return this.name;
    }
    public void setLoginUrl(String loginUrl){
        this.loginUrl = loginUrl;
    }
    public String getLoginUrl(){
        return this.loginUrl;
    }
    public void setBaseUrl(String baseUrl){
        this.baseUrl = baseUrl;
    }
    public String getBaseUrl(){
        return this.baseUrl;
    }
    public void setFavicon(String favicon){
        this.favicon = favicon;
    }
    public String getFavicon(){
        return this.favicon;
    }
    public void setLogo(String logo){
        this.logo = logo;
    }
    public String getLogo(){
        return this.logo;
    }
    public void setStatus(String status){
        this.status = status;
    }
    public String getStatus(){
        return this.status;
    }
    public void setIsConsentRequired(boolean isConsentRequired){
        this.isConsentRequired = isConsentRequired;
    }
    public boolean getIsConsentRequired(){
        return this.isConsentRequired;
    }
    public void setAuthType(String authType){
        this.authType = authType;
    }
    public String getAuthType(){
        return this.authType;
    }
    public void setLanguageISOCode(String languageISOCode){
        this.languageISOCode = languageISOCode;
    }
    public String getLanguageISOCode(){
        return this.languageISOCode;
    }
    public void setPrimaryLanguageISOCode(String primaryLanguageISOCode){
        this.primaryLanguageISOCode = primaryLanguageISOCode;
    }
    public String getPrimaryLanguageISOCode(){
        return this.primaryLanguageISOCode;
    }
    public void setCountryISOCode(String countryISOCode){
        this.countryISOCode = countryISOCode;
    }
    public String getCountryISOCode(){
        return this.countryISOCode;
    }
    public void setLastModified(String lastModified){
        this.lastModified = lastModified;
    }
    public String getLastModified(){
        return this.lastModified;
    }
    public void setForgetPasswordUrl(String forgetPasswordUrl){
        this.forgetPasswordUrl = forgetPasswordUrl;
    }
    public String getForgetPasswordUrl(){
        return this.forgetPasswordUrl;
    }
    public void setIsAutoRefreshEnabled(boolean isAutoRefreshEnabled){
        this.isAutoRefreshEnabled = isAutoRefreshEnabled;
    }
    public boolean getIsAutoRefreshEnabled(){
        return this.isAutoRefreshEnabled;
    }
    public void setDataset(List<ProviderDataset> dataset){
        this.dataset = dataset;
    }
    public List<ProviderDataset> getDataset(){
        return this.dataset;
    }
    public void setIsAddedByUser(String isAddedByUser){
        this.isAddedByUser = isAddedByUser;
    }
    public String getIsAddedByUser(){
        return this.isAddedByUser;
    }
}