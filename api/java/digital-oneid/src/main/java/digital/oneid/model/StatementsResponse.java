/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import java.util.List;

/**
 * Created by hubinotech on 12/03/20.
 */
public class StatementsResponse {
    private List<Statement> statement;

    public void setStatement(List<Statement> statement){
        this.statement = statement;
    }
    public List<Statement> getStatement(){
        return this.statement;
    }
}
