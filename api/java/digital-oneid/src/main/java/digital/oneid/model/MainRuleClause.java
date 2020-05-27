package digital.oneid.model;

import java.util.List;

/**
 * Created by hubinotech on 03/05/20.
 */
public class MainRuleClause {
    private long categoryId;
    private String source;
    private int priority;
    private List<RuleClause> ruleClause;

    public long getCategoryId() {
        return categoryId;
    }
    public void setCategoryId(long categoryId) {
        this.categoryId = categoryId;
    }

    public String getSource() {
        return source;
    }
    public void setSource(String source) {
        this.source = source;
    }

    public int getPriority() {
        return priority;
    }
    public void setPriority(int priority) {
        this.priority = priority;
    }

    public List<RuleClause> getRuleClause() {
        return ruleClause;
    }
    public void setRuleClause(List<RuleClause> ruleClause) {
        this.ruleClause = ruleClause;
    }
}
