package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;

/**
 * Created by hubinotech on 23/05/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class UserEdit {

    private String email;

    private Name name;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private Address address;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private Preferences preferences;

    public void setEmail(String email){
        this.email = email;
    }
    public String getEmail(){
        return this.email;
    }
    public void setName(Name name){
        this.name = name;
    }
    public Name getName(){
        return this.name;
    }
    public void setAddress(Address address){
        this.address = address;
    }
    public Address getAddress(){
        return this.address;
    }
    public void setPreferences(Preferences preferences){
        this.preferences = preferences;
    }
    public Preferences getPreferences(){
        return this.preferences;
    }
}
