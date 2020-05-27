/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import java.util.List;
public class ProviderDataset
{
    private String name;

    private List<Attribute> attribute;

    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return this.name;
    }
    public void setAttribute(List<Attribute> attribute){
        this.attribute = attribute;
    }
    public List<Attribute> getAttribute(){
        return this.attribute;
    }
}