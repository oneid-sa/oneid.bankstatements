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
                if(companyInfo.getStatus().equalsIgnoreCase(ACTIVE_STATUS)) {
                    if (companyInfo.getUsername().equalsIgnoreCase(authenticationRequest.getUsername())) {
                        if (companyInfo.getPassword().equalsIgnoreCase(authenticationRequest.getPassword())) {
                            String jwtToken = jwtTokenUtil.generateToken(jwtBusinessService.getUserDetails(authenticationRequest.getUsername(), authenticationRequest.getPassword()));
                            jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/" +authenticationRequest.getUsername()+"/" + SUCCESS);
                            return ResponseEntity.ok(new JwtResponse(jwtToken, ERROR_CODE_200, SUCCESS));
                        } else {
                            jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/" +authenticationRequest.getUsername()+"/" + INVALID_LOGINPASSWORD);
                            return getErrorResponseEntity(INVALID_LOGINPASSWORD, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                        }
                    } else {
                        jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/" +authenticationRequest.getUsername()+"/" + USER_NAME_INVALID);
                        return getErrorResponseEntity(USER_NAME_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/"+authenticationRequest.getUsername()+ "/" + COMPANY_INACTIVE_STATE);
                    return getErrorResponseEntity(COMPANY_INACTIVE_STATE, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                jwtBusinessService.AuditLogging(companyInfo.getId(), companyInfo.getRoleId(), request.getRemoteAddr(), AUDIT_AUTH + "/" +authenticationRequest.getUsername()+"/" + USER_NAME_INVALID);
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
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/auth/company/edit", method = RequestMethod.POST)
    public ResponseEntity<?> companyEdit(@RequestBody EditCompanyRequest editCompanyRequest,HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_CLIENT) {
            if(editCompanyRequest.getId() != 0 && isNullOrEmpty(editCompanyRequest.getCompanyName()) && isNullOrEmpty(editCompanyRequest.getEmail()) && isNullOrEmpty(editCompanyRequest.getPassword()) && isNullOrEmpty(editCompanyRequest.getAddress())) {
                if(jwtBusinessService.companyNameExistId(editCompanyRequest.getCompanyName(),editCompanyRequest.getId()) != 0) {
                    if(jwtBusinessService.emailExistId(editCompanyRequest.getEmail(),editCompanyRequest.getId()) != 0) {
                        jwtBusinessService.updateCompanyInfo(editCompanyRequest);
                        jwtBusinessService.AuditLogging(editCompanyRequest.getId(), ROLE_CLIENT, request.getRemoteAddr(), AUDIT_COMPANY_EDIT + "/"+editCompanyRequest.getCompanyName() + "/" + SUCCESS);
                        return getSuccessResponseEntity(COMPANY_EDIT_SUCCCESS);
                    } else {
                        return getErrorResponseEntity(EMAIL_EXIST, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(COMPANY_NAME_EXIST, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(ROLE_ACCESS_FAILED, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    @RequestMapping(value = "/api/auth/company/change/status", method = RequestMethod.GET)
    public ResponseEntity<?> companyDelete(@RequestParam (value = "id", defaultValue = "") String companyID,
                                           @RequestParam (value = "action", defaultValue = "") String action,
                                           HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_CLIENT) {
            if(isNullOrEmpty(companyID)) {
                if(jwtBusinessService.companyIdExist(companyID)) {
                    if(action.equalsIgnoreCase(ACTIVE_STATUS) || action.equalsIgnoreCase(INACTIVE_STATUS)) {
                        jwtBusinessService.changeCompanyStatus(Integer.parseInt(companyID), action);
                        if(action.equalsIgnoreCase(ACTIVE_STATUS)) {
                            jwtBusinessService.AuditLogging(Integer.parseInt(companyID), ROLE_CLIENT, request.getRemoteAddr(), AUDIT_COMPANY_STATUS + "/"+companyID+ "/" + COMPANY_ACTIVATED);
                            return getSuccessResponseEntity(COMPANY_ACTIVATED);
                        }
                        else {
                            jwtBusinessService.AuditLogging(Integer.parseInt(companyID), ROLE_CLIENT, request.getRemoteAddr(), AUDIT_COMPANY_STATUS + "/"+companyID+ "/" + COMPANY_INACTIVATED);
                            return getSuccessResponseEntity(COMPANY_INACTIVATED);
                        }
                    } else {
                        return getErrorResponseEntity(INVALID_ACTION_STATUS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(COMPANY_ID_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
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
    public ResponseEntity<?> userRegister(@RequestBody NewSessionRequest NewSessionRequestValue, HttpServletRequest request) throws Exception {
        UserRegisterRequest userRegisterRequest = new UserRegisterRequest();
        userRegisterRequest.setUser(new UserRegister());
        userRegisterRequest.getUser().setLoginName(NewSessionRequestValue.getAccountHolderIdentifier());
        userRegisterRequest.getUser().setEmail(NewSessionRequestValue.getEmailAddress());
        if (isNullOrEmpty(userRegisterRequest.getUser().getLoginName()) && isNullOrEmpty(userRegisterRequest.getUser().getEmail()) /*&& isNullOrEmpty(userRegisterRequest.getUser().getPassword())*/) {
            if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
                String apiVersion = env.getProperty(APP_VERSION);
                String baseUrl = env.getProperty(BASE_URL);
                String cobrandName = jwtBusinessService.getCobrandName();

                String uniqueReference = userRegisterRequest.getUser().getUniqueReference();

                userRegisterRequest.getUser().setPassword(jwtBusinessService.generatePassword(10));
                //userRegisterRequest.getUser().setPassword("Hubino@123");
                CobrandLoginResponse cobrandSessionTokenInfo = getCobrandSessionToken();
                String username = userRegisterRequest.getUser().getLoginName();
                if (cobrandSessionTokenInfo.getErrorResponse().getErroCode().equalsIgnoreCase(ERROR_CODE_200)) {
                    userRegisterRequest.getUser().setLoginName(jwtBusinessService.getCompanySpecificAccountholderId(username));
                    UserRegisterResponse userRegisterResp = yodleeServiceConsumer.userRegister(baseUrl, apiVersion, cobrandName, cobrandSessionTokenInfo.getSession().getCobSession(), userRegisterRequest);
                    userRegisterRequest.getUser().setLoginName(username);
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
                        userRegisterRequest.getUser().setLoginName(username);
                        long createdIdInYodlee = userRegisterResp.getUser().getId();
                        jwtBusinessService.registerUserInDB(companyId, createdIdInYodlee, userRegisterRequest);
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CREATE + "/" + SUCCESS);
                        userRegisterResp.getUser().setUniqueReference(uniqueReference);
                        userRegisterResp.getUser().setLoginName(username);
                        NewSessionResponse newSessionResponse = new NewSessionResponse();
                        newSessionResponse.setAccountHolderIdentifier(username);
                        newSessionResponse.setUniqueReference(uniqueReference);
                        newSessionResponse.setStatus("SUCCESS");
                        return ResponseEntity.ok(newSessionResponse);
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
     * This method is for register a user.
     *
     * @return Cobrand session token
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/unregister", method = RequestMethod.POST)
    public ResponseEntity<?> userUnRegister(@RequestBody UserUnregisterRequest userUnregisterRequest, HttpServletRequest request) throws Exception {
        if (isNullOrEmpty(userUnregisterRequest.getAccountHolderIdentifier()) && isNullOrEmpty(userUnregisterRequest.getUniqueReference())) {
            if (!jwtBusinessService.userExists(userUnregisterRequest.getAccountHolderIdentifier(), userUnregisterRequest.getUniqueReference()))
            {
                return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
            if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
                String apiVersion = env.getProperty(APP_VERSION);
                String baseUrl = env.getProperty(BASE_URL);
                String cobrandName = jwtBusinessService.getCobrandName();
                CobrandLoginResponse cobrandSessionTokenInfo = getCobrandSessionToken();
                if (cobrandSessionTokenInfo.getErrorResponse().getErroCode().equalsIgnoreCase(ERROR_CODE_200)) {
                    String args[] = getArgs("");
                    YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                    String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, jwtBusinessService.getCompanySpecificAccountholderId(userUnregisterRequest.getAccountHolderIdentifier()));
                    int statusCode = yodleeServiceConsumer.userUnregister(baseUrl, apiVersion, cobrandName, cobrandSessionTokenInfo.getSession().getCobSession(), jwtBusinessService.getCompanySpecificAccountholderId(userUnregisterRequest.getAccountHolderIdentifier()), yodleeUserToken);
                    int companyId = jwtBusinessService.getCompanyId();



                    if (statusCode != 204) {
                        return getErrorResponseEntity(ERROR_END_ACCOUNTHOLDER_SESSION, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                        //jwtBusinessService.updateUserInDB(userEditRequest);
                    } else {
                        jwtBusinessService.changeUserStatus(jwtBusinessService.getUserIdByName(userUnregisterRequest.getAccountHolderIdentifier(), userUnregisterRequest.getUniqueReference()), "C");
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CREATE + "/" + SUCCESS);
                        UserUnregisterResponse userUnregisterResponse = new UserUnregisterResponse();
                        userUnregisterResponse.setAccountHolderIdentifier(userUnregisterRequest.getAccountHolderIdentifier());
                        userUnregisterResponse.setUniqueReference(userUnregisterRequest.getUniqueReference());
                        return ResponseEntity.ok(userUnregisterResponse);
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
        //return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
    }

    @RequestMapping(value = "/api/company/user/edit", method = RequestMethod.POST)
    public ResponseEntity<?> userEdit(@RequestBody UserEditRequest userEditRequest, HttpServletRequest request) throws Exception {
        if (isNullOrEmpty(String.valueOf(userEditRequest.getUserId()))) {
            if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
                if(jwtBusinessService.userIdExist(userEditRequest.getUserId())) {
                    String apiVersion = env.getProperty(APP_VERSION);
                    String baseUrl = env.getProperty(BASE_URL);
                    String cobrandName = jwtBusinessService.getCobrandName();
                    CobrandLoginResponse cobrandSessionTokenInfo = getCobrandSessionToken();
                    if (cobrandSessionTokenInfo.getErrorResponse().getErroCode().equalsIgnoreCase(ERROR_CODE_200)) {
                        String loginName = jwtBusinessService.getUsername(userEditRequest.getUserId());
                        String args[] = getArgs("");
                        YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                        String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, loginName);
                        net.minidev.json.JSONObject obj = yodleeServiceConsumer.userEdit(baseUrl, apiVersion, cobrandName, yodleeUserToken, userEditRequest);
                        int companyId = jwtBusinessService.getCompanyId();
                        if (obj != null && (obj.getAsString("status_code") == ERROR_CODE_400 || obj.getAsString("status_code") == ERROR_CODE_401)) {
                            if (obj.getAsString("status_code") == ERROR_CODE_400) {
                                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_EDIT + "/" +userEditRequest.getUserId()+ "/" + obj.getAsString("message"));
                                return new ResponseEntity<Object>(
                                        obj, new HttpHeaders(), HttpStatus.BAD_REQUEST);
                            } else {
                                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_EDIT + "/" +userEditRequest.getUserId()+ "/" + obj.getAsString("message"));
                                return new ResponseEntity<Object>(
                                        obj, new HttpHeaders(), HttpStatus.UNAUTHORIZED);
                            }
                        } else {
                            jwtBusinessService.updateUserInDB(userEditRequest);
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_EDIT + "/" +userEditRequest.getUserId()+ "/" + SUCCESS);
                            return getSuccessResponseEntity(USER_UPDATED_SUCCESS);
                        }
                    } else {
                        int companyId = jwtBusinessService.getCompanyId();
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CREATE + "/" + cobrandSessionTokenInfo.getErrorResponse().getErroMessage());
                        return new ResponseEntity<Object>(
                                cobrandSessionTokenInfo.getErrorResponse(), new HttpHeaders(), HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(INVALID_USER_ID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    @RequestMapping(value = "/api/auth/company/user/change/status", method = RequestMethod.GET)
    public ResponseEntity<?> userDelete(@RequestParam (value = "id", defaultValue = "") String userId,
                                           @RequestParam (value = "action", defaultValue = "") String action,
                                           HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            if(isNullOrEmpty(userId)) {
                if(jwtBusinessService.userIdExist(Integer.parseInt(userId))) {
                    if(action.equalsIgnoreCase(ACTIVE_STATUS) || action.equalsIgnoreCase(INACTIVE_STATUS)) {
                        int companyId = jwtBusinessService.getCompanyId();
                        jwtBusinessService.changeUserStatus(Integer.parseInt(userId), action);
                        if(action.equalsIgnoreCase(ACTIVE_STATUS)) {
                            jwtBusinessService.AuditLogging(companyId, ROLE_CLIENT, request.getRemoteAddr(), AUDIT_USER_STATUS + "/"+userId+ "/" + COMPANY_ACTIVATED);
                            return getSuccessResponseEntity(USER_ACTIVATED);
                        }
                        else {
                            jwtBusinessService.AuditLogging(companyId, ROLE_CLIENT, request.getRemoteAddr(), AUDIT_USER_STATUS + "/"+userId+ "/" + COMPANY_INACTIVATED);
                            return getSuccessResponseEntity(USER_INACTIVATED);
                        }
                    } else {
                        return getErrorResponseEntity(INVALID_ACTION_STATUS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(INVALID_USER_ID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                }
            } else {
                return getErrorResponseEntity(PARAM_INVALID, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }
        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
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
    public ResponseEntity<?> userRegisterList( HttpServletRequest request) throws Exception {
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
    @RequestMapping(value = "/api/company/user/account", method = RequestMethod.POST)
    public ResponseEntity<?> userAccount(@RequestBody AccountHolderRequestDetails accountHolderRequestDetails, HttpServletRequest request) throws Exception {
        if (isNullOrEmpty(accountHolderRequestDetails.getAccountHolderIdentifier()) && isNullOrEmpty(accountHolderRequestDetails.getUniqueReference()) && jwtBusinessService.userExists(accountHolderRequestDetails.getAccountHolderIdentifier(), accountHolderRequestDetails.getUniqueReference())) {
            if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
                if(jwtBusinessService.userIsActive(accountHolderRequestDetails.getAccountHolderIdentifier(), accountHolderRequestDetails.getUniqueReference())) {
                    int companyId = jwtBusinessService.getCompanyId();
                    if (jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, accountHolderRequestDetails.getAccountHolderIdentifier(), accountHolderRequestDetails.getUniqueReference()) != 0) {
                        String apiVersion = env.getProperty(APP_VERSION);
                        String baseUrl = env.getProperty(BASE_URL);
                        String cobrandName = jwtBusinessService.getCobrandName();
                        String args[] = getArgs("");
                        YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                        String yodleeUserJwtToken = tokenYodleeGenerator.generateJwtYodlee(false, jwtBusinessService.getCompanySpecificAccountholderId(accountHolderRequestDetails.getAccountHolderIdentifier()));
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_ACCOUNT_GET + "/" + accountHolderRequestDetails.getAccountHolderIdentifier() + "/" + SUCCESS);
                        return ResponseEntity.ok(yodleeServiceConsumer.getAccountInformation(baseUrl, apiVersion, cobrandName, yodleeUserJwtToken));
                    } else {
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_ACCOUNT_GET + "/" + accountHolderRequestDetails.getAccountHolderIdentifier() + "/" + INVALID_NAME_COMPANY);
                        return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
                }
            } else {
                return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
            }
        } else {
            return getErrorResponseEntity(INVALID_USERNAME + accountHolderRequestDetails.getAccountHolderIdentifier(), ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is to get the user specific account statement
     *
     * @return Statement
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/statement", method = RequestMethod.POST)
    public ResponseEntity<?> userStatement(@RequestBody AccountDetailRequest AccountDetailRequestValue, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            if (isNullOrEmpty(AccountDetailRequestValue.getAccountHolderIdentifier()) && AccountDetailRequestValue.getAccountId() != 0 && isNullOrEmpty(AccountDetailRequestValue.getContainer())) {
                if(jwtBusinessService.userIsActive(AccountDetailRequestValue.getAccountHolderIdentifier(), AccountDetailRequestValue.getUniqueReference())) {
                    if (AccountDetailRequestValue.getContainer().equalsIgnoreCase(CONTAINER_ARR[0]) || AccountDetailRequestValue.getContainer().equalsIgnoreCase(CONTAINER_ARR[2]) || AccountDetailRequestValue.getContainer().equalsIgnoreCase(CONTAINER_ARR[3]) || AccountDetailRequestValue.getContainer().equalsIgnoreCase(CONTAINER_ARR[4])) {
                        if (jwtBusinessService.UserRecordExist(AccountDetailRequestValue.getAccountHolderIdentifier(), AccountDetailRequestValue.getUniqueReference())) {
                            int companyId = jwtBusinessService.getCompanyId();
                            if (jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, AccountDetailRequestValue.getAccountHolderIdentifier(), AccountDetailRequestValue.getUniqueReference()) != 0) {
                                String args[] = getArgs("");
                                String apiVersion = env.getProperty(APP_VERSION);
                                String baseUrl = env.getProperty(BASE_URL);
                                String cobrandName = jwtBusinessService.getCobrandName();
                                YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                                String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, AccountDetailRequestValue.getAccountHolderIdentifier());
                                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_STATEMENT + "/" + AccountDetailRequestValue.getAccountHolderIdentifier() + "/" + AccountDetailRequestValue.getUniqueReference()  + "/" + SUCCESS);
                                return ResponseEntity.ok(yodleeServiceConsumer.getStatements(baseUrl, apiVersion, cobrandName, yodleeUserToken, AccountDetailRequestValue.getAccountId(), AccountDetailRequestValue.getContainer(), AccountDetailRequestValue.getIsLatest(), AccountDetailRequestValue.getStatus()));
                            } else {
                                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_STATEMENT + "/" +  AccountDetailRequestValue.getAccountHolderIdentifier() + "/" + AccountDetailRequestValue.getUniqueReference()  + "/" + INVALID_NAME_COMPANY);
                                return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                            }
                        } else {
                            return getErrorResponseEntity(INVALID_USERNAME +  AccountDetailRequestValue.getAccountHolderIdentifier() + "/" + AccountDetailRequestValue.getUniqueReference() , ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                        }
                    } else {
                        return getErrorResponseEntity(INVALID_CONTAINER_FOUND_STATEMENT, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
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
     * @param AccountHolderRequestDetailsValue
     * @return fastlink launch parameters
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/accountlink", method = RequestMethod.POST)
    public ResponseEntity<?> generateApplicationTokenYodlee(@RequestBody AccountHolderRequestDetails AccountHolderRequestDetailsValue, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            if (isNullOrEmpty(AccountHolderRequestDetailsValue.getAccountHolderIdentifier()) && isNullOrEmpty(AccountHolderRequestDetailsValue.getUniqueReference())) {
                if(jwtBusinessService.userIsActive(AccountHolderRequestDetailsValue.getAccountHolderIdentifier(), AccountHolderRequestDetailsValue.getUniqueReference())) {
                    if (jwtBusinessService.UserRecordExist(AccountHolderRequestDetailsValue.getAccountHolderIdentifier(), AccountHolderRequestDetailsValue.getUniqueReference())) {
                        int companyId = jwtBusinessService.getCompanyId();
                        if (jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, AccountHolderRequestDetailsValue.getAccountHolderIdentifier(), AccountHolderRequestDetailsValue.getUniqueReference()) != 0) {
                            String args[] = getArgs("");
                            YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                            String yodleeToken = tokenYodleeGenerator.generateJwtYodlee(false, jwtBusinessService.getCompanySpecificAccountholderId(AccountHolderRequestDetailsValue.getAccountHolderIdentifier()));
                            ClientBankLoginCredentialsResponse clientBankLoginCredentialsResponse = new ClientBankLoginCredentialsResponse();
                            //clientBankLoginCredentialsResponse.setFastLink(env.getProperty(FASTLINK));
                            //clientBankLoginCredentialsResponse.setFinAppid(Long.parseLong(env.getProperty(FINAPPID)));
                            clientBankLoginCredentialsResponse.setJwtToken(yodleeToken);
                            //clientBankLoginCredentialsResponse.setRedirectReq(Boolean.parseBoolean(env.getProperty(REDIRECTREQ)));
                            //clientBankLoginCredentialsResponse.setCallbackUrl(env.getProperty(CALBACKURL));
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_FASTLINK + "/" + AccountHolderRequestDetailsValue.getAccountHolderIdentifier() + "/" + AccountHolderRequestDetailsValue.getUniqueReference() + "/" + SUCCESS);
                            return ResponseEntity.ok(clientBankLoginCredentialsResponse);
                        } else {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_FASTLINK + "/" + AccountHolderRequestDetailsValue.getAccountHolderIdentifier() + "/" + AccountHolderRequestDetailsValue.getUniqueReference() + "/" + INVALID_NAME_COMPANY);
                            return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                        }
                    } else {
                        return getErrorResponseEntity(INVALID_USERNAME + AccountHolderRequestDetailsValue.getAccountHolderIdentifier() + "/" + AccountHolderRequestDetailsValue.getUniqueReference(), ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
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
     * @param AccountTransactionsRequestValue
     * @return Transaction info
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/transactions", method = RequestMethod.POST)
    public ResponseEntity<?> userTransaction(@RequestBody AccountTransactionsRequest AccountTransactionsRequestValue, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            if (isNullOrEmpty(AccountTransactionsRequestValue.getAccountHolderIdentifier()) && isNullOrEmpty(AccountTransactionsRequestValue.getContainer()) && isNullOrEmpty(AccountTransactionsRequestValue.getAccountid())) {
                if (jwtBusinessService.UserRecordExist(AccountTransactionsRequestValue.getAccountHolderIdentifier(), AccountTransactionsRequestValue.getUniqueReference())) {
                    if(jwtBusinessService.userIsActive(AccountTransactionsRequestValue.getAccountHolderIdentifier(),AccountTransactionsRequestValue.getUniqueReference() )) {
                        int companyId = jwtBusinessService.getCompanyId();
                        if (jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, AccountTransactionsRequestValue.getAccountHolderIdentifier(), AccountTransactionsRequestValue.getUniqueReference()) != 0) {
                            if (AccountTransactionsRequestValue.getCategoryId() == null)
                            {
                                AccountTransactionsRequestValue.setCategoryId("");
                            }
                            if (AccountTransactionsRequestValue.getCategoryType() == null)
                            {
                                AccountTransactionsRequestValue.setCategoryType("");
                            }
                            if (AccountTransactionsRequestValue.getHighLevelCategoryId() == null)
                            {
                                AccountTransactionsRequestValue.setHighLevelCategoryId("");
                            }
                            String args[] = getArgs("");
                            String apiVersion = env.getProperty(APP_VERSION);
                            String baseUrl = env.getProperty(BASE_URL);
                            String cobrandName = jwtBusinessService.getCobrandName();
                            YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                            String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, jwtBusinessService.getCompanySpecificAccountholderId(AccountTransactionsRequestValue.getAccountHolderIdentifier()));
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_TRANSACTION + "/" + AccountTransactionsRequestValue.getAccountHolderIdentifier() + "/"+ AccountTransactionsRequestValue.getAccountHolderIdentifier() + "/" + AccountTransactionsRequestValue.getAccountid() + "/" + SUCCESS);
                            CobrandLoginResponse cobrandSessionTokenInfo = getCobrandSessionToken();
                            UserUnregisterRequest userUnregisterRequest = new UserUnregisterRequest();
                            userUnregisterRequest.setAccountHolderIdentifier(AccountTransactionsRequestValue.getAccountHolderIdentifier());

                            ResponseEntity<net.minidev.json.JSONObject> transactionsResponseObject = yodleeServiceConsumer.getTransactionInfo(baseUrl, apiVersion, cobrandName, yodleeUserToken, Long.parseLong(AccountTransactionsRequestValue.getAccountid()), AccountTransactionsRequestValue.getContainer(), AccountTransactionsRequestValue.getFromDate(), AccountTransactionsRequestValue.getToDate(), AccountTransactionsRequestValue.getCategoryId(), AccountTransactionsRequestValue.getCategoryType(), AccountTransactionsRequestValue.getHighLevelCategoryId());


                            if (transactionsResponseObject.getStatusCodeValue() == 200) {

                                Object transactionsObject = transactionsResponseObject.getBody();

                                if (transactionsObject instanceof ErrorResponse) {
                                    ErrorResponse errorResponse = (ErrorResponse) transactionsObject;
                                    return getErrorResponseEntity(errorResponse.getErroMessage(), errorResponse.getErroCode(), HttpStatus.BAD_REQUEST);
                                }

                                if (transactionsObject == null) {
                                    return getErrorResponseEntity(INVALID_TRANSACTION_RESULT, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                                }
                                JSONObject jsonObject = new JSONObject(transactionsObject);

                                if (jsonObject.isEmpty()) {
                                    return getErrorResponseEntity(INVALID_TRANSACTION_RESULT, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                                }

                                int statusCode = yodleeServiceConsumer.userUnregister(baseUrl, apiVersion, cobrandName, cobrandSessionTokenInfo.getSession().getCobSession(), AccountTransactionsRequestValue.getAccountHolderIdentifier(), yodleeUserToken);

                                if (statusCode == 204) {
                                    jwtBusinessService.changeUserStatus(jwtBusinessService.getUserIdByName(AccountTransactionsRequestValue.getAccountHolderIdentifier(), AccountTransactionsRequestValue.getUniqueReference()), "C");
                                    //jwtBusinessService.updateUserInDB(userEditRequest);
                                }
                                return ResponseEntity.ok(transactionsObject);
                            } else
                            {
                                return getErrorResponseEntity(transactionsResponseObject.getStatusCode().getReasonPhrase(), Integer.toString(transactionsResponseObject.getStatusCodeValue()), transactionsResponseObject.getStatusCode());
                            }

                        } else {
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_TRANSACTION + "/" + AccountTransactionsRequestValue.getAccountHolderIdentifier() + "/" + AccountTransactionsRequestValue.getAccountHolderIdentifier()  +"/" + AccountTransactionsRequestValue.getAccountid() + "/" + INVALID_NAME_COMPANY);
                            return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                        }
                    } else {
                        return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
                    }
                } else {
                    return getErrorResponseEntity(INVALID_USERNAME + AccountTransactionsRequestValue.getAccountHolderIdentifier() + "/" + AccountTransactionsRequestValue.getUniqueReference(), ERROR_CODE_400, HttpStatus.BAD_REQUEST);
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
                if (jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, categoriesCreateRequest.getUsername(), categoriesCreateRequest.getUniqueidentifier()) != 0) {
                    if(jwtBusinessService.userIsActive(categoriesCreateRequest.getUsername(), categoriesCreateRequest.getUniqueidentifier())) {
                        String args[] = getArgs("");
                        String apiVersion = env.getProperty(APP_VERSION);
                        String baseUrl = env.getProperty(BASE_URL);
                        String cobrandName = jwtBusinessService.getCobrandName();
                        YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                        String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, categoriesCreateRequest.getUsername());
                        ErrorResponse response = yodleeServiceConsumer.createCategoryForUser(apiVersion, baseUrl, cobrandName, yodleeUserToken, categoriesCreateRequest.getCategoryName(), categoriesCreateRequest.getParentCategoryId());
                        if (response != null && response.getErroCode().equalsIgnoreCase(ERROR_CODE_200)) {
                            jwtBusinessService.insertTransactionCategoryDB(companyId, categoriesCreateRequest.getUsername(), categoriesCreateRequest.getCategoryName(), categoriesCreateRequest.getParentCategoryId(), categoriesCreateRequest.getUniqueidentifier());
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
                        return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
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
     * @param CategoryListRequestValue
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/categories/list", method = RequestMethod.POST)
    public ResponseEntity<?> categoryList(@RequestBody CategoryListRequest CategoryListRequestValue, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            String apiVersion = env.getProperty(APP_VERSION);
            String baseUrl = env.getProperty(BASE_URL);
            String cobrandName = jwtBusinessService.getCobrandName();
            int companyId = jwtBusinessService.getCompanyId();

                if (CategoryListRequestValue.getCobrandLevel()) {
                    CobrandLoginResponse resp = getCobrandSessionToken();
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_LIST + "/cobrandLevel" + "/" + jwtBusinessService.getCompanySpecificAccountholderId(CategoryListRequestValue.getAccountHolderIdentifier()) + "/" + SUCCESS);
                    Object obj = yodleeServiceConsumer.transactionCategoriesList(apiVersion, baseUrl, cobrandName, CategoryListRequestValue.getCobrandLevel(), CategoryListRequestValue.getUserLevel(), resp.getSession().getCobSession());
                    return ResponseEntity.ok(obj);
                } else if (CategoryListRequestValue.getUserLevel()) {
                    if (CategoryListRequestValue.getAccountHolderIdentifier() != EMPTY && jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, CategoryListRequestValue.getAccountHolderIdentifier(), "todo") != 0) {
                        if(jwtBusinessService.userIsActive(CategoryListRequestValue.getAccountHolderIdentifier(), CategoryListRequestValue.getUniqueReference())) {
                            String args[] = getArgs("");
                            YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                            String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, jwtBusinessService.getCompanySpecificAccountholderId(CategoryListRequestValue.getAccountHolderIdentifier()));
                            jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_LIST + "/userLevel" + "/" + jwtBusinessService.getCompanySpecificAccountholderId(CategoryListRequestValue.getAccountHolderIdentifier()) + "/" + SUCCESS);
                            Object obj = yodleeServiceConsumer.transactionCategoriesList(apiVersion, baseUrl, cobrandName, CategoryListRequestValue.getCobrandLevel(),CategoryListRequestValue.getUserLevel(), yodleeUserToken);
                            return ResponseEntity.ok(obj);
                        } else {
                            return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
                        }
                    } else {
                        jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_LIST + "/userLevel" + "/" + CategoryListRequestValue.getAccountHolderIdentifier() + "/" + CategoryListRequestValue.getUniqueReference() + "/"  + INVALID_NAME_COMPANY);
                        return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
                    }
                } else {
                    CobrandLoginResponse resp = getCobrandSessionToken();
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_CATEGORY_LIST + "/cobrandLevel" + "/" + CategoryListRequestValue.getAccountHolderIdentifier() + "/" + CategoryListRequestValue +   "/" + SUCCESS);
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
                if (categoriesRuleCreateRequest.getUsername() != EMPTY && jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, categoriesRuleCreateRequest.getUsername(), categoriesRuleCreateRequest.getUniqueidentifier()) != 0) {
                    if(jwtBusinessService.userIsActive(categoriesRuleCreateRequest.getUsername(),categoriesRuleCreateRequest.getUniqueidentifier())) {
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
                                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_CREATE + "/" + categoriesRuleCreateRequest.getUsername() + "/" + categoriesRuleCreateRequest.getUniqueidentifier() + "/" + response.getErroMessage());
                                return new ResponseEntity<Object>(
                                        response, new HttpHeaders(), HttpStatus.BAD_REQUEST);
                            } else {
                                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_CREATE + "/" + categoriesRuleCreateRequest.getUsername() + "/" +  categoriesRuleCreateRequest.getUniqueidentifier() + "/" + response.getErroMessage());
                                return new ResponseEntity<Object>(
                                        response, new HttpHeaders(), HttpStatus.UNAUTHORIZED);
                            }
                        }
                    } else {
                        return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
                    }
                } else {
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_CREATE + "/" + categoriesRuleCreateRequest.getUsername() + "/" + categoriesRuleCreateRequest.getUniqueidentifier()  + "/" + INVALID_NAME_COMPANY);
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
     * @param AccountHolderRequestDetailsValue
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/rules/list", method = RequestMethod.POST)
    public ResponseEntity<?> userRulesList(@RequestBody AccountHolderRequestDetails AccountHolderRequestDetailsValue, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            int companyId = jwtBusinessService.getCompanyId();
            if (AccountHolderRequestDetailsValue.getAccountHolderIdentifier() != EMPTY && jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, AccountHolderRequestDetailsValue.getAccountHolderIdentifier(), AccountHolderRequestDetailsValue.getUniqueReference()) != 0) {
                if(jwtBusinessService.userIsActive(AccountHolderRequestDetailsValue.getAccountHolderIdentifier(), AccountHolderRequestDetailsValue.getUniqueReference())) {
                    String apiVersion = env.getProperty(APP_VERSION);
                    String baseUrl = env.getProperty(BASE_URL);
                    String args[] = getArgs("");
                    YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                    String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, jwtBusinessService.getCompanySpecificAccountholderId(AccountHolderRequestDetailsValue.getAccountHolderIdentifier()));
                    String cobrandName = jwtBusinessService.getCobrandName();
                    Object obj = yodleeServiceConsumer.getUserRuleList(apiVersion, baseUrl, cobrandName, yodleeUserToken);
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_LIST + "/" + AccountHolderRequestDetailsValue.getAccountHolderIdentifier() + "/" + AccountHolderRequestDetailsValue.getUniqueReference() + "/" + SUCCESS);
                    return ResponseEntity.ok(obj);
                } else {
                    return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
                }
            } else {
                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_LIST + "/" + AccountHolderRequestDetailsValue + "/" + AccountHolderRequestDetailsValue.getUniqueReference() + "/" + INVALID_NAME_COMPANY);
                return getErrorResponseEntity(INVALID_NAME_COMPANY, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
            }

        } else {
            return getErrorResponseEntity(COMPANY_ACCESS, ERROR_CODE_400, HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * @param RunRuleRequestValue
     * @return
     * @throws Exception
     */
    @RequestMapping(value = "/api/company/user/rules/run", method = RequestMethod.POST)
    public ResponseEntity<?> categorizationRulesRun(@RequestBody RunRuleRequest RunRuleRequestValue, HttpServletRequest request) throws Exception {
        if (jwtBusinessService.getRoleAccess() == ROLE_COMPANY) {
            int companyId = jwtBusinessService.getCompanyId();
            if (RunRuleRequestValue.getAccountHolderIdentifier() != EMPTY && jwtBusinessService.checkCompanyIdAndLoginNameAndUniquereferenceIsValid(companyId, RunRuleRequestValue.getAccountHolderIdentifier(), RunRuleRequestValue.getUniqueReference()) != 0) {
                if(jwtBusinessService.userIsActive(RunRuleRequestValue.getAccountHolderIdentifier(), RunRuleRequestValue.getUniqueReference())) {
                    String apiVersion = env.getProperty(APP_VERSION);
                    String baseUrl = env.getProperty(BASE_URL);
                    String args[] = getArgs("");
                    YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
                    String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, jwtBusinessService.getCompanySpecificAccountholderId(RunRuleRequestValue.getAccountHolderIdentifier()));
                    String cobrandName = jwtBusinessService.getCobrandName();
                    Object obj = yodleeServiceConsumer.runCategorizationRule(apiVersion, baseUrl, cobrandName, yodleeUserToken, RunRuleRequestValue.getRuleId());
                    jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_RUN + "/" + RunRuleRequestValue.getAccountHolderIdentifier() + "/" + RunRuleRequestValue.getUniqueReference() + "/" + SUCCESS);
                    return ResponseEntity.ok(obj);
                } else {
                    return getErrorResponseEntity(USER_INACTIVE_STATE, ERROR_CODE_401, HttpStatus.UNAUTHORIZED);
                }
            } else {
                jwtBusinessService.AuditLogging(companyId, ROLE_COMPANY, request.getRemoteAddr(), AUDIT_USER_RULE_RUN + "/" + RunRuleRequestValue.getAccountHolderIdentifier() + "/" + RunRuleRequestValue.getUniqueReference() + "/" + INVALID_NAME_COMPANY);
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