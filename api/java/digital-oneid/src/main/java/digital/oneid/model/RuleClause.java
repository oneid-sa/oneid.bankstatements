package digital.oneid.model;

/**
 * Created by hubinotech on 03/05/20.
 */
public class RuleClause {
    private String field;

    private String operation;

    private String value;

    public void setField(String field){
        this.field = field;
    }
    public String getField(){
        return this.field;
    }
    public void setOperation(String operation){
        this.operation = operation;
    }
    public String getOperation(){
        return this.operation;
    }
    public void setValue(String value){
        this.value = value;
    }
    public String getValue(){
        return this.value;
    }
}
