package digital.oneid.model;

import java.util.List;

/**
 * Created by hubinotech on 03/05/20.
 */
public class TransactionCategoryList {
    private List<TransactionCategory> transactionCategory;

    public void setTransactionCategory(List<TransactionCategory> transactionCategory){
        this.transactionCategory = transactionCategory;
    }
    public List<TransactionCategory> getTransactionCategory(){
        return this.transactionCategory;
    }
}
