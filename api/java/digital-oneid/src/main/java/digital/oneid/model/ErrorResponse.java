/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

/**
 * Created by hubinotech on 11/03/20.
 */
public class ErrorResponse {

    String error_code = "";
    String error_message = "";

    public String getErroCode() {
        return error_code;
    }

    public void setErroCode(String error_code) {
        this.error_code = error_code;
    }

    public String getErroMessage() {
        return error_message;
    }

    public void setErroMessage(String error_message) {
        this.error_message = error_message;
    }
}
