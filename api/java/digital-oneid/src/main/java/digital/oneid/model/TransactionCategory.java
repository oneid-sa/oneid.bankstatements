package digital.oneid.model;

/**
 * Created by hubinotech on 03/05/20.
 */
public class TransactionCategory {
    private int id;

    private String source;

    private String classification;

    private String category;

    private String type;

    private int highLevelCategoryId;

    private String highLevelCategoryName;

    public void setId(int id){
        this.id = id;
    }
    public int getId(){
        return this.id;
    }
    public void setSource(String source){
        this.source = source;
    }
    public String getSource(){
        return this.source;
    }
    public void setClassification(String classification){
        this.classification = classification;
    }
    public String getClassification(){
        return this.classification;
    }
    public void setCategory(String category){
        this.category = category;
    }
    public String getCategory(){
        return this.category;
    }
    public void setType(String type){
        this.type = type;
    }
    public String getType(){
        return this.type;
    }
    public void setHighLevelCategoryId(int highLevelCategoryId){
        this.highLevelCategoryId = highLevelCategoryId;
    }
    public int getHighLevelCategoryId(){
        return this.highLevelCategoryId;
    }
    public void setHighLevelCategoryName(String highLevelCategoryName){
        this.highLevelCategoryName = highLevelCategoryName;
    }
    public String getHighLevelCategoryName(){
        return this.highLevelCategoryName;
    }
}
