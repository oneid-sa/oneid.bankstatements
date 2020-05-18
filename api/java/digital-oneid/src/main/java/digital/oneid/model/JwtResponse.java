/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;
import java.io.Serializable;

public class JwtResponse implements Serializable {
    private static final long serialVersionUID = -8091879091924046844L;
    private final String jwttoken;
    private String status_code;
    private String message;
    public JwtResponse(String jwttoken,String status_code,String message) {
        this.jwttoken = jwttoken;
        this.status_code = status_code;
        this.message = message;
    }

    public String getToken() {
        return this.jwttoken;
    }

    public String getStatus_code() {
        return this.status_code;
    }

    public String getMessage() {
        return this.message;
    }

}