/**
 * ******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 ********************************************************/

package digital.oneid.controller;

import com.google.gson.Gson;
import digital.oneid.model.*;
import digital.oneid.security.JwtTokenUtil;
import digital.oneid.service.JwtBusinessService;
import digital.oneid.utils.Constants;
import digital.oneid.utils.YodleeJwtTokenGenerate;
import digital.oneid.utils.YodleeServiceConsumer;
import org.json.JSONObject;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.env.Environment;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpServletRequest;

/**
 * JwtAuthenticationController annotation indicates that the annotated class is a controller.
 * It is a specialization of @Component and is autodetected through classpath scanning.
 * It is typically used in combination with annotated handler methods based on the @RequestMapping annotation.
 *
 * @author Hubino
 * @version 1.0
 * @since 10/03/2020
 */

@RestController
@CrossOrigin("*")
public class JwtAuthenticationController extends Constants {

    private static final Logger logger = LoggerFactory.getLogger(JwtAuthenticationController.class);

    YodleeServiceConsumer yodleeServiceConsumer = new YodleeServiceConsumer();

    private ErrorResponse errorResponse = null;

    @Autowired
    private AuthenticationManager authenticationManager;

    @Autowired
    private JwtTokenUtil jwtTokenUtil;

    @Autowired
    private JwtBusinessService jwtBusinessService;

    @Autowired
    private Environment env;

    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is for cobrand login and will get the api session token to access other apis.
     *
     * @return Jwt token
     * @throws Exception
     */
    @RequestMapping(value = "/api/auth", method = RequestMethod.POST)
    public ResponseEntity<?> createAuthenticationToken(@RequestBody JwtRequest authenticationRequest, HttpServletRequest request) throws Exception {
        System.out.println("IP:" + request.getRemoteAddr());
        if (isNullOrEmpty(authenticationRequest.getUsername()) && isNullOrEmpty(authenticationRequest.getPassword())) {
            TableCompanyInfo companyInfo = jwtBusinessService.getCompanyInfo(authenticationRequest.getUsername());
            if (companyInfo != null) {
                if (companyInfo.getUsername().equalsIgnoreCase(authenticationRequest.getUsername())) {
                    if (companyInfo.getPassword().equalsIgnoreCase(authenticationRequest.getPassword())) {
                        String jwtToken = jwtTokenUtil.generateToken(jwtBusinessService.getUserDetails(authenticationRequest.getUsername(), authenticationRequest.getPassword()));
                        jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/" + SUCCESS);
                        return ResponseEntity.ok(new JwtResponse(jwtToken, ERROR_CODE_200, SUCCESS));
                    } else {
                        jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/" + INVALID_LOGINPASSWORD);
                        return getErrorResponseEntity(INVALID_LOGINPASSWORD, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/" + USER_NAME_INVALID);
                    return getErrorResponseEntity(USER_NAME_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/" + USER_NAME_INVALID);
                return getErrorResponseEntity(USER_NAME_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }

    }

    /**
     * @param companyCreateRequest
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/auth/company/create", method = RequestMethod.POST)
    public ResponseEntity<?> companyCreate(@RequestBody CompanyCreateRequest companyCreateRequest, HttpServletRequest request) throws Exception {
        if (isNullOrEmpty(companyCreateRequest.getLoginname()) && isNullOrEmpty(companyCreateRequest.getPassword()) && isNullOrEmpty(companyCreateRequest.getEmail()) && isNullOrEmpty(companyCreateRequest.getAddress())) {
            if (jwtBusinessService.getRoleAccess() == ROLE_CLIENT) {
                if (!jwtBusinessService.companyLoginNameExist(companyCreateRequest.getLoginname())) {
                    if (!jwtBusinessService.emailExist(companyCreateRequest.getEmail())) {
                        if (!jwtBusinessService.companyNameExist(companyCreateRequest.getCompanyName())) {
                            jwtBusinessService.createCompany(companyCreateRequest);
                            jwtBusinessService.AuditLogging(1, ROLE_CLIENT, request.getRemoteAddr(), AUDIT_COMPANY_CREATE + "/" + USER_NAME_INVALID);
                            return getSuccessResponseEntity(COMPANY_CREATE_SUCCCESS);
                        } else {
                            jwtBusinessService.AuditLogging(1, ROLE_CLIENT, request.getRemoteAddr(), AUDIT_COMPANY_CREATE + "/" + COMPANY_NAME_EXIST);
                            return getErrorResponseEntity(COMPANY_NAME_EXIST, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                        }
                    } else {
                        jwtBusinessService.AuditLogging(1, ROLE_CLIENT, request.getRemoteAddr(), AUDIT_COMPANY_CREATE + "/" + EMAIL_EXIST);
                        return getErrorResponseEntity(EMAIL_EXIST, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    jwtBusinessService.AuditLogging(1, ROLE_CLIENT, request.getRemoteAddr(), AUDIT_COMPANY_CREATE + "/" + LOGIN_NAME_EXIST);
                    return getErrorResponseEntity(LOGIN_NAME_EXIST, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(ROLE_ACCESS_FAILED, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/auth/company/list", method = RequestMethod.GET)
    public ResponseEntity<?> companyList(HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_CLIENT) {
            JSONObject jsonObject = jwtBusinessService.getCompanyList();
            jwtBusinessService.AuditLogging(1, ROLE_CLIENT, request.getRemoteAddr(), AUDIT_COMPANY_LIST + "/" + SUCCESS);
            return new ResponseEntity<>(jsonObject.toMap(), HttpStatus.OK);
        } else {
            return getErrorResponseEntity(ROLE_ACCESS_FAILED, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }


    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is for register a user.
     *
     * @return Cobrand session token
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/register", method = RequestMethod.POST)
    public ResponseEntity<?> userRegister(@RequestBody UserRegisterRequest userRegisterRequest, HttpServletRequest request) throws Exception {
        if (isNullOrEmpty(userRegisterRequest.getUser().getLoginName()) && isNullOrEmpty(userRegisterRequest.getUser().getEmail()) && isNullOrEmpty(userRegisterRequest.getUser().getPassword())) {
            if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
                String apiVersion = env.getProperty(APP_VERSION);
                String baseUrl = env.getProperty(BASE_URL);
                String cobrandName = jwtBusinessService.getCobrandName();
                CobrandLoginResponse cobrandSessionTokenInfo = getCobrandSessionToken();
                if (cobrandSessionTokenInfo.getErrorResponse().getErroCode().equalsIgnoreCase(ERROR_CODE_200)) {
                    UserRegisterResponse userRegisterResp = yodleeServiceConsumer.userRegister(baseUrl, apiVersion, cobrandName, cobrandSessionTokenInfo.getSession().getCobSession(), userRegisterRequest);
                    int companyId = jwtBusinessService.getCompanyId();
                    if (userRegisterResp.getErrorResponse() != null && userRegisterResp.getErrorResponse().getErroCode().toString().contains("40")) {
                        if (userRegisterResp.getErrorResponse().getErroCode().toString() == ERROR_CODE_400) {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CREATE + "/" + userRegisterResp.getErrorResponse().getErroMessage());
                            return new ResponseEntity<Object>(
                                    userRegisterResp.getErrorResponse(), new HttpHeaders(), HttpStatus.BAD_REQUEST);
                        } else {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CREATE + "/" + userRegisterResp.getErrorResponse().getErroMessage());
                            return new ResponseEntity<Object>(
                                    userRegisterResp.getErrorResponse(), new HttpHeaders(), HttpStatus.UNAUTHORIZED);
                        }
                    } else {
                        long createdIdInYodlee = userRegisterResp.getUser().getId();
                        jwtBusinessService.registerUserInDB(companyId, createdIdInYodlee, userRegisterRequest);
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CREATE + "/" + SUCCESS);
                        return ResponseEntity.ok(userRegisterResp);
                    }
                } else {
                    int companyId = jwtBusinessService.getCompanyId();
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CREATE + "/" + cobrandSessionTokenInfo.getErrorResponse().getErroMessage());
                    return new ResponseEntity<Object>(
                            cobrandSessionTokenInfo.getErrorResponse(), new HttpHeaders(), HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }


    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is for get the registered users list.
     *
     * @return Users list
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/list", method = RequestMethod.GET)
    public ResponseEntity<?> userRegisterList(HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            int companyId = jwtBusinessService.getCompanyId();
            JSONObject jsonObject = jwtBusinessService.getCompanyUserList(companyId);
            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_LIST + "/" + SUCCESS);
            return new ResponseEntity<>(jsonObject.toMap(), HttpStatus.OK);
        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
        }
    }

    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is for return specific user account list.
     *
     * @return user account list.
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/account", method = RequestMethod.GET)
    public ResponseEntity<?> userAccount(@RequestParam(value = "username", defaultValue = "") String loginName, HttpServletRequest request) throws Exception {
        if (isNullOrEmpty(loginName) && jwtBusinessService.UsernameExist(loginName)) {
            if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
                int companyId = jwtBusinessService.getCompanyId();
                if (jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, loginName) != 0) {
                    String apiVersion = env.getProperty(APP_VERSION);
                    String baseUrl = env.getProperty(BASE_URL);
                    String cobrandName = jwtBusinessService.getCobrandName();
                    String args[] = getArgs("");
                    YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                    String yodleeUserJwtToken = tokenYodleeGenerator.generateJwtYodlee(false, loginName);
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_ACCOUNT_GET + "/" + loginName + "/" + SUCCESS);
                    return ResponseEntity.ok(yodleeServiceConsumer.getAccountInformation(baseUrl, apiVersion, cobrandName, yodleeUserJwtToken));
                } else {
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_ACCOUNT_GET + "/" + loginName + "/" + INVALID_NAME_COMPANY);
                    return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
            }
        } else {
            return getErrorResponseEntity(INVALID_USERNAME + loginName, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is to get the user specific account statement
     *
     * @return Statement
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/statement", method = RequestMethod.GET)
    public ResponseEntity<?> userStatement(@RequestParam(value = "username", defaultValue = "") String loginName,
                                           @RequestParam(value = "accountId", defaultValue = "0") long accountID,
                                           @RequestParam(value = "isLatest", defaultValue = "true") boolean isLatest,
                                           @RequestParam(value = "status", defaultValue = "ACTIVE") String status,
                                           @RequestParam(value = "container", defaultValue = "") String container, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            if (isNullOrEmpty(loginName) && accountID != 0 && isNullOrEmpty(container)) {
                if (container.equalsIgnoreCase(CONTAINER_ARR[0]) || container.equalsIgnoreCase(CONTAINER_ARR[2]) || container.equalsIgnoreCase(CONTAINER_ARR[3]) || container.equalsIgnoreCase(CONTAINER_ARR[4])) {
                    if (jwtBusinessService.UsernameExist(loginName)) {
                        int companyId = jwtBusinessService.getCompanyId();
                        if (jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, loginName) != 0) {
                            String args[] = getArgs("");
                            String apiVersion = env.getProperty(APP_VERSION);
                            String baseUrl = env.getProperty(BASE_URL);
                            String cobrandName = jwtBusinessService.getCobrandName();
                            YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                            String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, loginName);
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_STATEMENT + "/" + loginName + "/" + SUCCESS);
                            return ResponseEntity.ok(yodleeServiceConsumer.getStatements(baseUrl, apiVersion, cobrandName, yodleeUserToken, accountID, container, isLatest, status));
                        } else {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_STATEMENT + "/" + loginName + "/" + INVALID_NAME_COMPANY);
                            return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                        }
                    } else {
                        return getErrorResponseEntity(INVALID_USERNAME + loginName, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(INVALID_CONTAINER_FOUND_STATEMENT, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity( PARAM_INVALID , ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
        }
    }


    /**
     * This method to generate the fastlink and retrun the fastlink launch parameters.
     *
     * @param loginName
     * @return fastlink launch parameters
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/fastlink")
    public ResponseEntity<?> generateApplicationTokenYodlee(@RequestParam(value = "username", defaultValue = "") String loginName, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            if (isNullOrEmpty(loginName)) {
                if (jwtBusinessService.UsernameExist(loginName)) {
                    int companyId = jwtBusinessService.getCompanyId();
                    if (jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, loginName) != 0) {
                        String args[] = getArgs("");
                        YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                        String yodleeToken = tokenYodleeGenerator.generateJwtYodlee(false, loginName);
                        FastlinkResponse fastlinkResponse = new FastlinkResponse();
                        fastlinkResponse.setFastLink(env.getProperty(FASTLINK));
                        fastlinkResponse.setFinAppid(Long.parseLong(env.getProperty(FINAPPID)));
                        fastlinkResponse.setFastLinkJwtToken(yodleeToken);
                        fastlinkResponse.setRedirectReq(Boolean.parseBoolean(env.getProperty(REDIRECTREQ)));
                        fastlinkResponse.setCallbackUrl(env.getProperty(CALBACKURL));
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_FASTLINK + "/" + loginName + "/" + SUCCESS);
                        return ResponseEntity.ok(fastlinkResponse);
                    } else {
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_FASTLINK + "/" + loginName + "/" + INVALID_NAME_COMPANY);
                        return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(INVALID_USERNAME + loginName, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
        }
    }

    /**
     * This method to return user transaction information.
     *
     * @param loginName
     * @param container
     * @param accountId
     * @param fromDate
     * @param toDate
     * @return Transaction info
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/transactions")
    public ResponseEntity<?> userTransaction(@RequestParam(value = "username", defaultValue = "") String loginName,
                                             @RequestParam(value = "container", defaultValue = "") String container,
                                             @RequestParam(value = "categoryId", defaultValue = "") String categoryId,
                                             @RequestParam(value = "categoryType", defaultValue = "") String categoryType,
                                             @RequestParam(value = "highLevelCategoryId", defaultValue = "") String highLevelCategoryId,
                                             @RequestParam(value = "accountId", defaultValue = "") String accountId,
                                             @RequestParam(value = "fromDate", defaultValue = "") String fromDate,
                                             @RequestParam(value = "toDate", defaultValue = "") String toDate, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            if (isNullOrEmpty(loginName) && isNullOrEmpty(container) && isNullOrEmpty(accountId)) {
                if (jwtBusinessService.UsernameExist(loginName)) {
                    int companyId = jwtBusinessService.getCompanyId();
                    if (jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, loginName) != 0) {
                        String args[] = getArgs("");
                        String apiVersion = env.getProperty(APP_VERSION);
                        String baseUrl = env.getProperty(BASE_URL);
                        String cobrandName = jwtBusinessService.getCobrandName();
                        YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                        String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, loginName);
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_TRANSACTION + "/" + loginName + "/" + SUCCESS);
                        return ResponseEntity.ok(yodleeServiceConsumer.getTransactionInfo(baseUrl, apiVersion, cobrandName, yodleeUserToken, Long.parseLong(accountId), container, fromDate, toDate, categoryId,categoryType,highLevelCategoryId));
                    } else {
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_TRANSACTION + "/" + loginName + "/" + INVALID_NAME_COMPANY);
                        return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(INVALID_USERNAME + loginName, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
        }
    }

    /**
     * @param categoriesCreateRequest
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/categories/create", method = RequestMethod.POST)
    public ResponseEntity<?> userCategoryCreate(@RequestBody CategoriesCreateRequest categoriesCreateRequest, HttpServletRequest request) throws Exception {
        if (isNullOrEmpty(categoriesCreateRequest.getUsername()) && isNullOrEmpty(categoriesCreateRequest.getCategoryName()) && categoriesCreateRequest.getParentCategoryId() != 0) {
            if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
                int companyId = jwtBusinessService.getCompanyId();
                if (jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, categoriesCreateRequest.getUsername()) != 0) {
                    String args[] = getArgs("");
                    String apiVersion = env.getProperty(APP_VERSION);
                    String baseUrl = env.getProperty(BASE_URL);
                    String cobrandName = jwtBusinessService.getCobrandName();
                    YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                    String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, categoriesCreateRequest.getUsername());
                    ErrorResponse response = yodleeServiceConsumer.createCategoryForUser(apiVersion, baseUrl, cobrandName, yodleeUserToken, categoriesCreateRequest.getCategoryName(), categoriesCreateRequest.getParentCategoryId());
                    if (response != null && response.getErroCode().equalsIgnoreCase(ERROR_CODE_200)) {
                        jwtBusinessService.insertTransactionCategoryDB(companyId, categoriesCreateRequest.getUsername(), categoriesCreateRequest.getCategoryName(), categoriesCreateRequest.getParentCategoryId());
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_CREATE + "/" + categoriesCreateRequest.getUsername() + "/" + SUCCESS);
                        return getSuccessResponseEntity(TRANSACTION_CATEGORY_CREATED);
                    } else {
                        if (response.getErroCode().equalsIgnoreCase(ERROR_CODE_400)) {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_CREATE + "/" + categoriesCreateRequest.getUsername() + "/" + response.getErroMessage());
                            return new ResponseEntity<Object>(
                                    response, new HttpHeaders(), HttpStatus.BAD_REQUEST);
                        } else {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_CREATE + "/" + categoriesCreateRequest.getUsername() + "/" + response.getErroMessage());
                            return new ResponseEntity<Object>(
                                    response, new HttpHeaders(), HttpStatus.UNAUTHORIZED);
                        }
                    }
                } else {
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_CREATE + "/" + categoriesCreateRequest.getUsername() + "/" + INVALID_NAME_COMPANY);
                    return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * @param cobrandLevel
     * @param userLevel
     * @param username
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/categories/list", method = RequestMethod.GET)
    public ResponseEntity<?> categoryList(@RequestParam(value = "cobrandLevel", defaultValue = "false") boolean cobrandLevel,
                                          @RequestParam(value = "userLevel", defaultValue = "false") boolean userLevel,
                                          @RequestParam(value = "username", defaultValue = "") String username, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            String apiVersion = env.getProperty(APP_VERSION);
            String baseUrl = env.getProperty(BASE_URL);
            String cobrandName = jwtBusinessService.getCobrandName();
            int companyId = jwtBusinessService.getCompanyId();
            if (cobrandLevel) {
                CobrandLoginResponse resp = getCobrandSessionToken();
                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_LIST + "/cobrandLevel" + "/" + username + "/" + SUCCESS);
                Object obj = yodleeServiceConsumer.transactionCategoriesList(apiVersion, baseUrl, cobrandName, cobrandLevel, userLevel, resp.getSession().getCobSession());
                return ResponseEntity.ok(obj);
            } else if (userLevel) {
                if (username != EMPTY && jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, username) != 0) {
                    String args[] = getArgs("");
                    YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                    String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, username);
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_LIST + "/userLevel" + "/" + username + "/" + SUCCESS);
                    Object obj = yodleeServiceConsumer.transactionCategoriesList(apiVersion, baseUrl, cobrandName, cobrandLevel, userLevel, yodleeUserToken);
                    return ResponseEntity.ok(obj);
                } else {
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_LIST + "/userLevel" + "/" + username + "/" + INVALID_NAME_COMPANY);
                    return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                CobrandLoginResponse resp = getCobrandSessionToken();
                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_LIST + "/cobrandLevel" + "/" + username + "/" + SUCCESS);
                Object obj = yodleeServiceConsumer.transactionCategoriesList(apiVersion, baseUrl, cobrandName, true, false, resp.getSession().getCobSession());
                return ResponseEntity.ok(obj);
            }

        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * @param categoriesRuleCreateRequest
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/rules/create", method = RequestMethod.POST)
    public ResponseEntity<?> categoryRuleCreate(@RequestBody CategoriesRuleCreateRequest categoriesRuleCreateRequest, HttpServletRequest request) throws Exception {
        if (categoriesRuleCreateRequest.getCategoryId() != 0 && isNullOrEmpty(categoriesRuleCreateRequest.getSource()) && categoriesRuleCreateRequest.getRuleClause().size() > 0) {
            if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
                int companyId = jwtBusinessService.getCompanyId();
                if (categoriesRuleCreateRequest.getUsername() != EMPTY && jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, categoriesRuleCreateRequest.getUsername()) != 0) {
                    String apiVersion = env.getProperty(APP_VERSION);
                    String baseUrl = env.getProperty(BASE_URL);
                    String args[] = getArgs("");
                    YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                    String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, categoriesRuleCreateRequest.getUsername());
                    String cobrandName = jwtBusinessService.getCobrandName();
                    ErrorResponse response = yodleeServiceConsumer.categoriesRuleCreate(apiVersion, baseUrl, cobrandName, yodleeUserToken, categoriesRuleCreateRequest);
                    if (response != null && response.getErroCode().equalsIgnoreCase(ERROR_CODE_200)) {
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_CREATE + "/" + categoriesRuleCreateRequest.getUsername() + "/" + TRANSACTION_CATEGORY_RULE_CREATED);
                        return getSuccessResponseEntity(TRANSACTION_CATEGORY_RULE_CREATED);
                    } else {
                        if (response.getErroCode().equalsIgnoreCase(ERROR_CODE_400)) {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_CREATE + "/" + categoriesRuleCreateRequest.getUsername() + "/" + response.getErroMessage());
                            return new ResponseEntity<Object>(
                                    response, new HttpHeaders(), HttpStatus.BAD_REQUEST);
                        } else {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_CREATE + "/" + categoriesRuleCreateRequest.getUsername() + "/" + response.getErroMessage());
                            return new ResponseEntity<Object>(
                                    response, new HttpHeaders(), HttpStatus.UNAUTHORIZED);
                        }
                    }
                } else {
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_CREATE + "/" + categoriesRuleCreateRequest.getUsername() + "/" + INVALID_NAME_COMPANY);
                    return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * @param username
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/rules/list", method = RequestMethod.GET)
    public ResponseEntity<?> userRulesList(@RequestParam(value = "username", defaultValue = "") String username, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            int companyId = jwtBusinessService.getCompanyId();
            if (username != EMPTY && jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, username) != 0) {
                String apiVersion = env.getProperty(APP_VERSION);
                String baseUrl = env.getProperty(BASE_URL);
                String args[] = getArgs("");
                YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, username);
                String cobrandName = jwtBusinessService.getCobrandName();
                Object obj = yodleeServiceConsumer.getUserRuleList(apiVersion, baseUrl, cobrandName, yodleeUserToken);
                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_LIST + "/" + username + "/" + SUCCESS);
                return ResponseEntity.ok(obj);
            } else {
                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_LIST + "/" + username + "/" + INVALID_NAME_COMPANY);
                return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }

        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * @param username
     * @param ruleId
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/rules/run", method = RequestMethod.GET)
    public ResponseEntity<?> categorizationRulesRun(@RequestParam(value = "username", defaultValue = "") String username,
                                                    @RequestParam(value = "ruleId", defaultValue = "") String ruleId, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            int companyId = jwtBusinessService.getCompanyId();
            if (username != EMPTY && jwtBusinessService.checkCompanyIdAndLoginNameIsValid(companyId, username) != 0) {
                String apiVersion = env.getProperty(APP_VERSION);
                String baseUrl = env.getProperty(BASE_URL);
                String args[] = getArgs("");
                YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, username);
                String cobrandName = jwtBusinessService.getCobrandName();
                Object obj = yodleeServiceConsumer.runCategorizationRule(apiVersion, baseUrl, cobrandName, yodleeUserToken, ruleId);
                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_RUN + "/" + username + "/" + SUCCESS);
                return ResponseEntity.ok(obj);
            } else {
                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_RUN + "/" + username + "/" + INVALID_NAME_COMPANY);
                return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }

        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/auth/auditlog/history", method = RequestMethod.POST)
    public ResponseEntity<?> auditLogHistory(@RequestBody AuditSearch auditSearch) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_CLIENT) {
            return ResponseEntity.ok(jwtBusinessService.getAuditHistory(auditSearch));
        } else {
            return getErrorResponseEntity(ROLE_ACCESS_FAILED, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     *
     * @param username
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/cobrandtoken", method = RequestMethod.GET)
    public ResponseEntity<?> cobrandtoken(@RequestParam(value = "username", defaultValue = "") String username,HttpServletRequest request) throws Exception {
        CobrandLoginResponse loginresp = getCobrandSessionToken();
//        String apiVersion = env.getProperty(APP_VERSION);
//        String baseUrl = env.getProperty(BASE_URL);
//        String cobrandName = jwtBusinessService.getCobrandName();
//        String usrsession = yodleeServiceConsumer.createUserSessionToken(baseUrl,apiVersion,cobrandName,loginresp.getSession().getCobSession(),"hubMockTesterTwoID","Hubino@123");
        String args[] = getArgs("");
        YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
        String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, username);
        return getSuccessResponseEntity(loginresp.getSession().getCobSession() + "-----" + yodleeUserToken);
    }

    /**
     * @return
     */
    public CobrandLoginResponse getCobrandSessionToken() {
        String apiVersion = env.getProperty(APP_VERSION);
        String baseUrl = env.getProperty(BASE_URL);
        String cobrandName = jwtBusinessService.getCobrandName();
        Cobrand cobrand = new Cobrand();
        cobrand.setCobrandLogin(env.getProperty("client.cobrand.username"));
        cobrand.setCobrandPassword(env.getProperty("client.cobrand.password"));
        cobrand.setLocale("en_US");
        CobrandRequest cobrandRequest = new CobrandRequest();
        cobrandRequest.setCobrand(cobrand);
        CobrandLoginResponse resp = yodleeServiceConsumer.cobrandLoginValidation(baseUrl, apiVersion, cobrandName, cobrandRequest);
        return resp;
    }

    /**
     * This method is for get the certification info from DB and passed to array.
     *
     * @param username
     * @return Array of certificate information
     */
    public String[] getArgs(String username) {
        TableCertificate cInfo = jwtBusinessService.getCertificateInfo();
        String args[] = new String[6];
        args[0] = "-k";
        args[1] = cInfo.getPrivateKey();
        args[2] = "-i";
        args[3] = cInfo.getIssuerID();
        args[4] = "-u";
        args[5] = username;
        return args;
    }

    /**
     * @param jsonInString
     * @return
     */
    public boolean isJSONValid(String jsonInString) {
        Gson gson = new Gson();
        try {
            gson.fromJson(jsonInString, Object.class);
            return true;
        } catch (com.google.gson.JsonSyntaxException ex) {
            return false;
        }
    }

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
     * @param message
     * @return
     */
    public ResponseEntity<?> getSuccessResponseEntity(String message) {
        SuccessResponse successResponse = new SuccessResponse();
        successResponse.setStatus("Success");
        successResponse.setMessage(message);
        successResponse.setStatusCode(200);
        return ResponseEntity.ok(successResponse);
    }

    /**
     * @param errorMessage
     * @param errorCode
     * @param httpStatus
     * @return
     */
    public ResponseEntity<?> getErrorResponseEntity(String errorMessage, String errorCode, HttpStatus httpStatus) {
        errorResponse = new ErrorResponse();
        errorResponse.setErroMessage(errorMessage);
        errorResponse.setErroCode(errorCode);
        return new ResponseEntity<Object>(
                errorResponse, new HttpHeaders(), httpStatus);
    }


}