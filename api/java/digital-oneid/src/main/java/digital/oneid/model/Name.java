package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 * Created by hubinotech on 26/03/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class Name
{
    private String first;

    private String last;

    public void setFirst(String first){
        this.first = first;
    }
    public String getFirst(){
        return this.first;
    }
    public void setLast(String last){
        this.last = last;
    }
    public String getLast(){
        return this.last;
    }
}
