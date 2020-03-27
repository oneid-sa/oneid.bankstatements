package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 * Created by hubinotech on 26/03/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class Address
{
    private String address1;

    private String state;

    private String city;

    private String zip;

    private String country;

    public void setAddress1(String address1){
        this.address1 = address1;
    }
    public String getAddress1(){
        return this.address1;
    }
    public void setState(String state){
        this.state = state;
    }
    public String getState(){
        return this.state;
    }
    public void setCity(String city){
        this.city = city;
    }
    public String getCity(){
        return this.city;
    }
    public void setZip(String zip){
        this.zip = zip;
    }
    public String getZip(){
        return this.zip;
    }
    public void setCountry(String country){
        this.country = country;
    }
    public String getCountry(){
        return this.country;
    }
}
