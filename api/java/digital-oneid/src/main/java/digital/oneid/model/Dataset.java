package digital.oneid.model;

/**
 * Created by hubinotech on 13/05/20.
 */
public class Dataset
{
    private String name;

    private String additionalStatus;

    private String updateEligibility;

    private String lastUpdated;

    private String lastUpdateAttempt;

    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return this.name;
    }
    public void setAdditionalStatus(String additionalStatus){
        this.additionalStatus = additionalStatus;
    }
    public String getAdditionalStatus(){
        return this.additionalStatus;
    }
    public void setUpdateEligibility(String updateEligibility){
        this.updateEligibility = updateEligibility;
    }
    public String getUpdateEligibility(){
        return this.updateEligibility;
    }
    public void setLastUpdated(String lastUpdated){
        this.lastUpdated = lastUpdated;
    }
    public String getLastUpdated(){
        return this.lastUpdated;
    }
    public void setLastUpdateAttempt(String lastUpdateAttempt){
        this.lastUpdateAttempt = lastUpdateAttempt;
    }
    public String getLastUpdateAttempt(){
        return this.lastUpdateAttempt;
    }
}
