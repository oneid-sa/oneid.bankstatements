package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;

/**
 * Created by hubinotech on 26/03/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class Preferences
{
    private String currency;

    private String timeZone;

    private String dateFormat;

    private String locale;

    public void setCurrency(String currency){
        this.currency = currency;
    }
    public String getCurrency(){
        return this.currency;
    }
    public void setLocale(String locale){
        this.locale = locale;
    }
    public String getLocale(){
        return this.locale;
    }
    public void setTimeZone(String timeZone){
        this.timeZone = timeZone;
    }
    public String getTimeZone(){
        return this.timeZone;
    }
    public void setDateFormat(String dateFormat){
        this.dateFormat = dateFormat;
    }
    public String getDateFormat(){
        return this.dateFormat;
    }

}