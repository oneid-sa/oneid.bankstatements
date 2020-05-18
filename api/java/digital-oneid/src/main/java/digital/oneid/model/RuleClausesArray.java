package digital.oneid.model;

/**
 * Created by hubinotech on 04/05/20.
 */
public class RuleClausesArray {
    private int ruleClauseId;

    private int userDefinedRuleId;

    private String field;

    private String operation;

    private String fieldValue;

    public void setRuleClauseId(int ruleClauseId){
        this.ruleClauseId = ruleClauseId;
    }
    public int getRuleClauseId(){
        return this.ruleClauseId;
    }
    public void setUserDefinedRuleId(int userDefinedRuleId){
        this.userDefinedRuleId = userDefinedRuleId;
    }
    public int getUserDefinedRuleId(){
        return this.userDefinedRuleId;
    }
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
    public void setFieldValue(String fieldValue){
        this.fieldValue = fieldValue;
    }
    public String getFieldValue(){
        return this.fieldValue;
    }
}
