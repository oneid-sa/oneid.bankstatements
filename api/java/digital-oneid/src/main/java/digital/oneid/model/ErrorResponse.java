/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonInclude;

/**
 * Created by hubinotech on 11/03/20.
 */
@JsonInclude(JsonInclude.Include.NON_EMPTY)
public class ErrorResponse {

    String errorCode = "";
    String errorMessage = "";
    String referenceCode = "";

    public String getErroCode() {
        return errorCode;
    }

    public void setErroCode(String errorCode) {
        this.errorCode = errorCode;
    }

    public String getErroMessage() {
        return errorMessage;
    }

    public void setErroMessage(String errorMessage) {
        this.errorMessage = errorMessage;
    }

    public String getReferenceCode() {
        return referenceCode;
    }

    public void setReferenceCode(String referenceCode) {
        this.referenceCode = referenceCode;
    }
}
