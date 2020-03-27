/**
 * ******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 ********************************************************/

package digital.oneid.utils;

import digital.oneid.model.*;
import net.minidev.json.JSONObject;
import org.springframework.context.annotation.Bean;
import org.springframework.http.*;
import org.springframework.web.client.HttpStatusCodeException;
import org.springframework.web.client.RestTemplate;

/**
 * YodleeServiceConsumer class is for call Rest service interface of the Yodlee API.
 *
 * @author Hubino
 * @version 1.0
 * @since 10/03/2020
 */
public class YodleeServiceConsumer extends Constants {
    @Bean
    public RestTemplate rest() {
        return new RestTemplate();
    }

    /**
     * @param baseUrl
     * @param apiVersion
     * @param cobrandName
     * @param cobrandRequest
     * @return
     */
    public CobrandLoginResponse cobrandLoginValidation(String baseUrl, String apiVersion, String cobrandName, CobrandRequest cobrandRequest) {
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        headers.add(API_VERSION, apiVersion);
        headers.add(COBRAND_NAME, cobrandName);
        RestTemplate restTemplate = new RestTemplate();
        HttpEntity entity = new HttpEntity(cobrandRequest, headers);
        try {
            ResponseEntity<CobrandLoginResponse> response = restTemplate.exchange(
                    baseUrl + "/ysl/cobrand/login", HttpMethod.POST, entity, CobrandLoginResponse.class);
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroMessage(SUCCESS);
            errorResponse.setErroCode(ERROR_CODE_200);
            CobrandLoginResponse cobrandLoginResponse = response.getBody();
            cobrandLoginResponse.setErrorResponse(errorResponse);
            return cobrandLoginResponse;
        } catch (HttpStatusCodeException exception) {
            int statusCode = exception.getStatusCode().value();
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroMessage(INVALID_LOGINPASSWORD);
            errorResponse.setErroCode(String.valueOf(statusCode));
            CobrandLoginResponse cobrandLoginResponse = new CobrandLoginResponse();
            cobrandLoginResponse.setErrorResponse(errorResponse);
            return cobrandLoginResponse;
        }

    }

    /**
     * @param baseUrl
     * @param apiVersion
     * @param cobrandName
     * @param cobrandSessionToken
     * @param userRegisterRequest
     * @return
     */
    public UserRegisterResponse userRegister(String baseUrl, String apiVersion, String cobrandName, String cobrandSessionToken, UserRegisterRequest userRegisterRequest) {
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        headers.add(API_VERSION, apiVersion);
        headers.add(AUTHORIZATION, COBSESSION + cobrandSessionToken);
        headers.add(COBRAND_NAME, cobrandName);
        RestTemplate restTemplate = new RestTemplate();
        HttpEntity entity = new HttpEntity(userRegisterRequest, headers);
        try {
            ResponseEntity<UserRegisterResponse> response = restTemplate.exchange(
                    baseUrl + "/ysl/user/register", HttpMethod.POST, entity, UserRegisterResponse.class);
            return response.getBody();
        } catch (HttpStatusCodeException exception) {
            int statusCode = exception.getStatusCode().value();
            ErrorResponse errorResponse = new ErrorResponse();
            if (statusCode == 401) {
                errorResponse.setErroMessage(INVALID_LOGINPASSWORD);
                errorResponse.setErroCode(String.valueOf(statusCode));
            } else if (statusCode == 400) {
                errorResponse.setErroMessage(USERNAME_EXIST + userRegisterRequest.getUser().getLoginName());
                errorResponse.setErroCode(String.valueOf(statusCode));
            }
            UserRegisterResponse userRegisterResponse = new UserRegisterResponse();
            userRegisterResponse.setErrorResponse(errorResponse);
            return userRegisterResponse;
        }

    }

    /**
     * @param baseUrl
     * @param apiVersion
     * @param cobrandName
     * @param cobrandSessionToken
     * @param username
     * @param password
     * @return
     */
    public String createUserSessionToken(String baseUrl, String apiVersion, String cobrandName, String cobrandSessionToken, String username, String password) {
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        headers.add(API_VERSION, apiVersion);
        headers.add(AUTHORIZATION, COBSESSION + cobrandSessionToken);
        headers.add(COBRAND_NAME, cobrandName);
        RestTemplate restTemplate = new RestTemplate();
        JSONObject jsonObjectUser = new JSONObject();
        jsonObjectUser.put(LOGINNAME, username);
        jsonObjectUser.put(PASSWORD, password);
        JSONObject jsonObject = new JSONObject();
        jsonObject.put(USER, jsonObjectUser);
        HttpEntity entity = new HttpEntity(jsonObject, headers);
        ResponseEntity<UserRegisterResponse> response = restTemplate.exchange(
                baseUrl + "/ysl/user/login", HttpMethod.POST, entity, UserRegisterResponse.class);
        return response.getBody().getUser().getSession().getUserSession();
    }


    /**
     * This method to get user's list of accounts.
     *
     * @param baseUrl
     * @param apiVersion
     * @param cobrandName
     * @return AccountResponse
     */
    public AccountResponse getAccountInformation(String baseUrl, String apiVersion, String cobrandName, String yodleeUserJwtToken) {
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        headers.add(API_VERSION, apiVersion);
        headers.add(AUTHORIZATION, BEARER + yodleeUserJwtToken);
        headers.add(COBRAND_NAME, cobrandName);
        HttpEntity entity = new HttpEntity(headers);
        RestTemplate restTemplate = new RestTemplate();
        ResponseEntity<AccountResponse> response = restTemplate.exchange(
                baseUrl + "/ysl/accounts?HTTP/1.1", HttpMethod.GET, entity, AccountResponse.class);
        return response.getBody();
    }

    /**
     * @param baseUrl
     * @param apiVersion
     * @param cobrandName
     * @param yodleeUserJwtToken
     * @param accountId
     * @param container
     * @param fromDate
     * @param toDate
     * @return
     */
    public JSONObject getTransactionInfo(String baseUrl, String apiVersion, String cobrandName, String yodleeUserJwtToken,
                                         long accountId, String container, String fromDate, String toDate) {

        String params = "accountId=" + accountId + "&container=" + container + "&fromDate=" + fromDate + "&toDate=" + toDate;
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        headers.add(API_VERSION, apiVersion);
        headers.add(AUTHORIZATION, BEARER + yodleeUserJwtToken);
        headers.add(COBRAND_NAME, cobrandName);
        HttpEntity entity = new HttpEntity(headers);
        RestTemplate restTemplate = new RestTemplate();
        ResponseEntity<JSONObject> response = restTemplate.exchange(
                baseUrl + "/ysl/transactions?" + params, HttpMethod.GET, entity, JSONObject.class);

        System.out.println(response.getStatusCode());
        System.out.println(response.getBody());
        return response.getBody();
    }


    /**
     * This method to get the statement of the account.
     *
     * @param baseUrl
     * @param apiVersion
     * @param accountId
     * @param container
     * @param isLatest
     * @param status
     * @return StatementsResponse
     */
    public StatementsResponse getStatements(String baseUrl, String apiVersion, String cobrandName, String yodleeUserToken, long accountId, String container, boolean isLatest, String status) {
        String params = "accountId=" + accountId + "&container=" + container + "&isLatest=" + isLatest + "&status=" + status;
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        headers.add(API_VERSION, apiVersion);
        headers.add(AUTHORIZATION, BEARER + yodleeUserToken);
        headers.add(COBRAND_NAME, cobrandName);
        HttpEntity entity = new HttpEntity(headers);
        RestTemplate restTemplate = new RestTemplate();
        ResponseEntity<StatementsResponse> response = restTemplate.exchange(
                baseUrl + "/ysl/statements?" + params, HttpMethod.GET, entity, StatementsResponse.class);

        System.out.println(response.getStatusCode());
        System.out.println(response.getBody());
        return response.getBody();
    }
}
