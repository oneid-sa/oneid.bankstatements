/**
 * ******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 ********************************************************/

package digital.oneid.utils;

import com.google.gson.Gson;
import digital.oneid.model.*;
import net.minidev.json.JSONObject;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.annotation.Bean;
import org.springframework.http.*;
import org.springframework.web.client.HttpStatusCodeException;
import org.springframework.web.client.RestTemplate;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

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

    private static final Logger logger = LoggerFactory.getLogger(YodleeServiceConsumer.class);

    /**
     * @param str
     * @return True returns not empty
     */
    public static boolean isNullOrEmpty(String str) {
        if (str != null && !str.isEmpty())
            return true;
        return false;
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
            logger.info("FAILED:/ysl/cobrand/login:" + exception.getMessage());
            int statusCode = exception.getStatusCode().value();
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroMessage(exception.getMessage());
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
        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            headers.add(API_VERSION, apiVersion);
            headers.add(AUTHORIZATION, COBSESSION + cobrandSessionToken);
            headers.add(COBRAND_NAME, cobrandName);
            RestTemplate restTemplate = new RestTemplate();
            HttpEntity entity = new HttpEntity(userRegisterRequest, headers);
            ResponseEntity<UserRegisterResponse> response = restTemplate.exchange(
                    baseUrl + "/ysl/user/register", HttpMethod.POST, entity, UserRegisterResponse.class);
            return response.getBody();
        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/user/register:" + exception.getMessage());
            Gson g = new Gson();
            ErrorResponse errorResponse = g.fromJson(exception.getResponseBodyAsString(), ErrorResponse.class);
            int statusCode = exception.getStatusCode().value();
            if (statusCode == 401) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            } else if (statusCode == 400) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            }
            UserRegisterResponse userRegisterResponse = new UserRegisterResponse();
            userRegisterResponse.setErrorResponse(errorResponse);
            return userRegisterResponse;
        }
    }

    public JSONObject userEdit(String baseUrl, String apiVersion, String cobrandName, String yodleeUserToken, UserEditRequest userEditRequest) {
        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            headers.add(API_VERSION, apiVersion);
            headers.add(AUTHORIZATION, BEARER + yodleeUserToken);
            headers.add(COBRAND_NAME, cobrandName);
            RestTemplate restTemplate = new RestTemplate();
            EditUserRequestYodlee editUserRequestYodlee = new EditUserRequestYodlee();
            editUserRequestYodlee.setUser(userEditRequest.getUser());

            HttpEntity entity = new HttpEntity(editUserRequestYodlee, headers);
            ResponseEntity<JSONObject> response = restTemplate.exchange(
                    baseUrl + "/ysl/user", HttpMethod.PUT, entity, JSONObject.class);
            return response.getBody();
        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/user/edit:" + exception.getMessage());
            int statusCode = exception.getStatusCode().value();
            if (statusCode == 401) {
                JSONObject respObj = new JSONObject();
                respObj.put("message", "User Edit Failed:"+exception.getMessage());
                respObj.put("status_code", "401");
                return respObj;
            } else if (statusCode == 400) {
                JSONObject respObj = new JSONObject();
                respObj.put("message", "User Edit Failed:"+exception.getMessage());
                respObj.put("status_code", "400");
                return respObj;
            } else if (statusCode == 204) {
                JSONObject respObj = new JSONObject();
                respObj.put("message", "User details updated");
                respObj.put("status_code", "200");
                return respObj;
            } else {
                return null;
            }
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
        try {
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
        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/user/login:" + exception.getResponseBodyAsString());
            return exception.getResponseBodyAsString();
        }
    }


    /**
     * This method to get user's list of accounts.
     *
     * @param baseUrl
     * @param apiVersion
     * @param cobrandName
     * @return AccountResponse
     */
    public Object getAccountInformation(String baseUrl, String apiVersion, String cobrandName, String yodleeUserJwtToken) {
        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            headers.add(API_VERSION, apiVersion);
            headers.add(AUTHORIZATION, BEARER + yodleeUserJwtToken);
            headers.add(COBRAND_NAME, cobrandName);
            HttpEntity entity = new HttpEntity(headers);
            RestTemplate restTemplate = new RestTemplate();
            ResponseEntity<AccountResponse> response = restTemplate.exchange(
                    baseUrl + "/ysl/accounts?include=holder,profile,autoRefresh", HttpMethod.GET, entity, AccountResponse.class);
            return response.getBody();
        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/accounts:" + exception.getResponseBodyAsString());
            Gson g = new Gson();
            ErrorResponse errorResponse = g.fromJson(exception.getResponseBodyAsString(), ErrorResponse.class);
            int statusCode = exception.getStatusCode().value();
            if (statusCode == 401) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            } else if (statusCode == 400) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            }
            return errorResponse;
        }
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
    public Object getTransactionInfo(String baseUrl, String apiVersion, String cobrandName, String yodleeUserJwtToken,
                                     long accountId, String container, String fromDate, String toDate, String categoryId, String categoryType,String highLevelCategoryId) {
        try {
            String params = "categoryId="+categoryId+"&accountId=" + accountId + "&container=" + container + "&fromDate=" + fromDate + "&toDate=" + toDate+"&categoryType="+categoryType+"&highLevelCategoryId="+highLevelCategoryId;
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
        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/transactions:" + exception.getResponseBodyAsString());
            Gson g = new Gson();
            ErrorResponse errorResponse = g.fromJson(exception.getResponseBodyAsString(), ErrorResponse.class);
            int statusCode = exception.getStatusCode().value();
            if (statusCode == 401) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            } else if (statusCode == 400) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            }
            return errorResponse;
        }
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
        System.out.println(response.getBody().getStatement());
        System.out.println(response.getBody());
        return response.getBody();
    }

    /**
     * @param apiVersion
     * @param baseUrl
     * @param cobrandName
     * @param yodleeUserToken
     * @param categoryName
     * @param parentCategoryId
     * @return
     */
    public ErrorResponse createCategoryForUser(String apiVersion, String baseUrl, String cobrandName, String yodleeUserToken, String categoryName, long parentCategoryId) {
        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            headers.add(API_VERSION, apiVersion);
            headers.add(AUTHORIZATION, BEARER + yodleeUserToken);
            headers.add(COBRAND_NAME, cobrandName);
            JSONObject jsonObjectUser = new JSONObject();
            jsonObjectUser.put("categoryName", categoryName);
            jsonObjectUser.put("parentCategoryId", parentCategoryId);
            HttpEntity entity = new HttpEntity(jsonObjectUser, headers);
            RestTemplate restTemplate = new RestTemplate();
            ResponseEntity<JSONObject> response = restTemplate.exchange(
                    baseUrl + "/ysl/transactions/categories", HttpMethod.POST, entity, JSONObject.class);

            System.out.println(response.getStatusCode());
            System.out.println(response.getBody());
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroMessage("success");
            errorResponse.setErroCode("200");
            errorResponse.setReferenceCode("");
            return errorResponse;
        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/transactions/categories:" + exception.getResponseBodyAsString());
            Gson g = new Gson();
            ErrorResponse errorResponse = g.fromJson(exception.getResponseBodyAsString(), ErrorResponse.class);
            int statusCode = exception.getStatusCode().value();
            if (statusCode == 401) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            } else if (statusCode == 400) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            }
            return errorResponse;
        }
    }

    /**
     * @param apiVersion
     * @param baseUrl
     * @param cobrandName
     * @param cobrandLevel
     * @param userLevel
     * @param token
     * @return
     */
    public Object transactionCategoriesList(String apiVersion, String baseUrl, String cobrandName, boolean cobrandLevel, boolean userLevel, String token) {
        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            headers.add(API_VERSION, apiVersion);

            if (cobrandLevel)
                headers.add(AUTHORIZATION, COBSESSION + token);
            else if (userLevel)
                headers.add(AUTHORIZATION, BEARER + token);
            else
                headers.add(AUTHORIZATION, COBSESSION + token);

            headers.add(COBRAND_NAME, cobrandName);
            HttpEntity entity = new HttpEntity(headers);
            RestTemplate restTemplate = new RestTemplate();
            ResponseEntity<String> response = restTemplate.exchange(
                    baseUrl + "/ysl/transactions/categories", HttpMethod.GET, entity, String.class);

            System.out.println(response.getStatusCode());
            System.out.println(response.getBody());
            if(response.getBody().length() > 10) {
                Gson g = new Gson();
                TransactionCategoryList arr = g.fromJson(response.getBody().toString(), TransactionCategoryList.class);
                return arr;
            } else {
                SuccessResponse successResponse = new SuccessResponse();
                successResponse.setStatus("Success");
                successResponse.setMessage("{}");
                successResponse.setStatusCode(200);
                return successResponse;
            }

        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/transactions/categories/list:" + exception.getResponseBodyAsString());
            Gson g = new Gson();
            ErrorResponse errorResponse = g.fromJson(exception.getResponseBodyAsString(), ErrorResponse.class);
            int statusCode = exception.getStatusCode().value();
            if (statusCode == 401) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            } else if (statusCode == 400) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            }
            return errorResponse;
        }
    }

    /**
     * @param apiVersion
     * @param baseUrl
     * @param cobrandName
     * @param yodleeUserToken
     * @param categoriesRuleCreateRequest
     * @return
     */
    public ErrorResponse categoriesRuleCreate(String apiVersion, String baseUrl, String cobrandName, String yodleeUserToken, CategoriesRuleCreateRequest categoriesRuleCreateRequest) {
        try {
            Rule rule = new Rule();
            MainRuleClause mainRuleClause = new MainRuleClause();
            mainRuleClause.setCategoryId(categoriesRuleCreateRequest.getCategoryId());
            mainRuleClause.setSource(categoriesRuleCreateRequest.getSource());
            mainRuleClause.setRuleClause(categoriesRuleCreateRequest.getRuleClause());
            if (categoriesRuleCreateRequest.getPriority() != 0)
                mainRuleClause.setPriority(categoriesRuleCreateRequest.getPriority());
            rule.setRule(mainRuleClause);
            org.json.JSONObject jsonObj = new org.json.JSONObject(rule);
            String ruleString = jsonObj.toString();
            HttpPost post = new HttpPost(baseUrl + "/ysl/transactions/categories/rules");
            post.addHeader(API_VERSION, apiVersion);
            post.addHeader(AUTHORIZATION, BEARER + yodleeUserToken);
            post.addHeader(COBRAND_NAME, cobrandName);
            List<NameValuePair> urlParameters = new ArrayList<>();
            urlParameters.add(new BasicNameValuePair("ruleParam", ruleString));
            post.setEntity(new UrlEncodedFormEntity(urlParameters));
            CloseableHttpClient httpClient = HttpClients.createDefault();
            CloseableHttpResponse response = httpClient.execute(post);
            String convertStr = EntityUtils.toString(response.getEntity());
            int status = response.getStatusLine().getStatusCode();
            System.out.println("/ysl/transactions/categories/rules:" + status + ":message:" + convertStr);
            if (response.getStatusLine().getStatusCode() == 201) {
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.setErroMessage("success");
                errorResponse.setErroCode("200");
                errorResponse.setReferenceCode("");
                return errorResponse;
            } else {
                Gson g = new Gson();
                ErrorResponse errorResponse = g.fromJson(convertStr, ErrorResponse.class);
                if (status == 401) {
                    errorResponse.setErroCode(String.valueOf(status));
                } else if (status == 400) {
                    errorResponse.setErroCode(String.valueOf(status));
                }
                return errorResponse;
            }

        } catch (UnsupportedEncodingException exception) {
            logger.info("FAILED:/ysl/transactions/categories/rules?ruleParam=:" + exception.getMessage().toString());
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroMessage(exception.getMessage().toString());
            errorResponse.setErroCode("400");
            return errorResponse;
        } catch (ClientProtocolException exception) {
            logger.info("FAILED:/ysl/transactions/categories/rules?ruleParam=:" + exception.getMessage().toString());
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroMessage(exception.getMessage().toString());
            errorResponse.setErroCode("400");
            return errorResponse;
        } catch (IOException exception) {
            logger.info("FAILED:/ysl/transactions/categories/rules?ruleParam=:" + exception.getMessage().toString());
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroMessage(exception.getMessage().toString());
            errorResponse.setErroCode("400");
            return errorResponse;
        }
    }

    /**
     * @param apiVersion
     * @param baseUrl
     * @param cobrandName
     * @param yodleeUserToken
     * @return
     */
    public Object getUserRuleList(String apiVersion, String baseUrl, String cobrandName, String yodleeUserToken) {

        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            headers.add(API_VERSION, apiVersion);
            headers.add(AUTHORIZATION, BEARER + yodleeUserToken);
            headers.add(COBRAND_NAME, cobrandName);
            HttpEntity entity = new HttpEntity(headers);
            RestTemplate restTemplate = new RestTemplate();
            ResponseEntity<String> response = restTemplate.exchange(
                    baseUrl + "/ysl/transactions/categories/rules", HttpMethod.GET, entity, String.class);

            System.out.println(response.getStatusCode());
            System.out.println(response.getBody());
            if(response.getBody().length() > 10) {
                Gson g = new Gson();
                CategoryRulesList[] arr = g.fromJson(response.getBody().toString(), CategoryRulesList[].class);
                return arr;
            } else {
                SuccessResponse successResponse = new SuccessResponse();
                successResponse.setStatus("Success");
                successResponse.setMessage("{}");
                successResponse.setStatusCode(200);
                return successResponse;
            }
        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/transactions/categories/list:" + exception.getResponseBodyAsString());
            Gson g = new Gson();
            ErrorResponse errorResponse = g.fromJson(exception.getResponseBodyAsString(), ErrorResponse.class);
            int statusCode = exception.getStatusCode().value();
            if (statusCode == 401) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            } else if (statusCode == 400) {
                errorResponse.setErroCode(String.valueOf(statusCode));
            }
            return errorResponse;
        }
    }

    /**
     * @param apiVersion
     * @param baseUrl
     * @param cobrandName
     * @param yodleeUserToken
     * @param ruleId
     * @return
     */
    public Object runCategorizationRule(String apiVersion, String baseUrl, String cobrandName, String yodleeUserToken, String ruleId) {
        try {
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.APPLICATION_JSON);
            headers.add(API_VERSION, apiVersion);
            headers.add(AUTHORIZATION, BEARER + yodleeUserToken);
            headers.add(COBRAND_NAME, cobrandName);
            HttpEntity entity = new HttpEntity(headers);
            RestTemplate restTemplate = new RestTemplate();
            String url = "";
            if (ruleId != EMPTY)
                url = baseUrl + "/ysl/transactions/categories/rules/" + ruleId + "?action=run";
            else
                url = baseUrl + "/ysl/transactions/categories/rules?action=run";
            ResponseEntity<JSONObject> response = restTemplate.exchange(
                    url, HttpMethod.POST, entity, JSONObject.class);

            System.out.println(response.getStatusCode());
            System.out.println(response.getBody());
            JSONObject respObj = new JSONObject();
            respObj.put("message", "Run categorization rule in progress");
            respObj.put("status_code", "200");
            return respObj;
        } catch (HttpStatusCodeException exception) {
            logger.info("FAILED:/ysl/transactions/categories/list:" + exception.getResponseBodyAsString());
            Gson g = new Gson();
            ErrorResponse errorResponse = g.fromJson(exception.getResponseBodyAsString(), ErrorResponse.class);
            int statusCode = exception.getStatusCode().value();
            if (statusCode == 401) {
                errorResponse.setErroCode(String.valueOf(statusCode));
                return errorResponse;
            } else if (statusCode == 400) {
                errorResponse.setErroCode(String.valueOf(statusCode));
                return errorResponse;
            } else if (statusCode == 204) {
                JSONObject respObj = new JSONObject();
                respObj.put("message", "Run categorization rule in progress");
                respObj.put("status_code", "200");
                return respObj;
            } else {
                return null;
            }

        }
    }


}
