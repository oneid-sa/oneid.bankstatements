package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import java.util.List;

/**
 * Created by hubinotech on 04/05/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class CategoryRulesList {

    private int userDefinedRuleId;

    private int memId;

    private int transactionCategorisationId;

    private int rulePriority;

    private List<RuleClauseResp> ruleClauses;

    private List<RuleClausesArray> ruleClauseArray;

    private int categoryLevelId;

    public void setUserDefinedRuleId(int userDefinedRuleId){
        this.userDefinedRuleId = userDefinedRuleId;
    }
    public int getUserDefinedRuleId(){
        return this.userDefinedRuleId;
    }
    public void setMemId(int memId){
        this.memId = memId;
    }
    public int getMemId(){
        return this.memId;
    }
    public void setTransactionCategorisationId(int transactionCategorisationId){
        this.transactionCategorisationId = transactionCategorisationId;
    }
    public int getTransactionCategorisationId(){
        return this.transactionCategorisationId;
    }
    public void setRulePriority(int rulePriority){
        this.rulePriority = rulePriority;
    }
    public int getRulePriority(){
        return this.rulePriority;
    }
    public void setRuleClauses(List<RuleClauseResp> ruleClauses){
        this.ruleClauses = ruleClauses;
    }
    public List<RuleClauseResp> getRuleClauses(){
        return this.ruleClauses;
    }
    public void setRuleClauseArray(List<RuleClausesArray> ruleClauseArray){
        this.ruleClauseArray = ruleClauseArray;
    }
    public List<RuleClausesArray> getRuleClauseArray(){
        return this.ruleClauseArray;
    }
    public void setCategoryLevelId(int categoryLevelId){
        this.categoryLevelId = categoryLevelId;
    }
    public int getCategoryLevelId(){
        return this.categoryLevelId;
    }
}
