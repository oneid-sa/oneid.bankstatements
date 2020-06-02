package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;

import java.util.UUID;

/**
 * Created by hubinotech on 25/03/20.
 */

@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class UserRegister {

    public UserRegister()
    {
        uniqueReference = UUID.randomUUID().toString();
    }

    private String loginName;

    private String roleType;

    private long id;

    private String email;

    private String password;

    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private String uniqueReference;

    private Name name;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private Address address;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private Preferences preferences;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    private Session session;

    public void setLoginName(String loginName){
        this.loginName = loginName;
    }
    public String getLoginName(){
        return this.loginName;
    }
    public void setEmail(String email){
        this.email = email;
    }
    public String getEmail(){
        return this.email;
    }
    public void setPassword(String password){
        this.password = password;
    }
    public String getPassword(){
        return this.password;
    }
    public void setName(Name name){
        this.name = name;
    }
    public Name getName(){
        return this.name;
    }
    public String getUniqueReference(){
        return this.uniqueReference;
    }
    public void setUniqueReference(String UniqueReference){
        this.uniqueReference = UniqueReference;
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
    public void setRoleType(String roleType){
        this.roleType = roleType;
    }
    public String getRoleType(){
        return this.roleType;
    }
    public void setId(long id){
        this.id = id;
    }
    public long getId(){
        return this.id;
    }
    public void setSession(Session session){
        this.session = session;
    }
    public Session getSession(){
        return this.session;
    }
}






