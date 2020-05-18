package digital.oneid.model;

/**
 * Created by hubinotech on 13/05/20.
 */
public class CurrentBalance
{
    private int amount;

    private String currency;

    public void setAmount(int amount){
        this.amount = amount;
    }
    public int getAmount(){
        return this.amount;
    }
    public void setCurrency(String currency){
        this.currency = currency;
    }
    public String getCurrency(){
        return this.currency;
    }
}
