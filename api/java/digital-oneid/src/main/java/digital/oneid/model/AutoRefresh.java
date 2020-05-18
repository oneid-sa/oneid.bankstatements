package digital.oneid.model;

/**
 * Created by hubinotech on 13/05/20.
 */
public class AutoRefresh
{
    private String status;

    private String additionalStatus;

    private String asOfDate;

    public void setStatus(String status){
        this.status = status;
    }
    public String getStatus(){
        return this.status;
    }
    public void setAdditionalStatus(String additionalStatus){
        this.additionalStatus = additionalStatus;
    }
    public String getAdditionalStatus(){
        return this.additionalStatus;
    }
    public void setAsOfDate(String asOfDate){
        this.asOfDate = asOfDate;
    }
    public String getAsOfDate(){
        return this.asOfDate;
    }
}
