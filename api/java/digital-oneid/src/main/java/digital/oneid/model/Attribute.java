/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import java.util.List;
public class Attribute
{
    private String name;

    private List<String> container;

    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return this.name;
    }
    public void setContainer(List<String> container){
        this.container = container;
    }
    public List<String> getContainer(){
        return this.container;
    }
}