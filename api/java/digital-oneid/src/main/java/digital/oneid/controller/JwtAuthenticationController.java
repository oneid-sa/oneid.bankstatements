/**
 * ******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 ********************************************************/

package digital.oneid.controller;

import digital.oneid.model.*;
import digital.oneid.security.JwtTokenUtil;
import digital.oneid.service.JwtBusinessService;
import digital.oneid.utils.Constants;
import digital.oneid.utils.YodleeJwtTokenGenerate;
import digital.oneid.utils.YodleeServiceConsumer;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.env.Environment;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.web.bind.annotation.*;

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
@CrossOrigin
public class JwtAuthenticationController extends Constants {

    private static final Logger logger = LoggerFactory.getLogger(JwtAuthenticationController.class);

    YodleeServiceConsumer yodleeServiceConsumer = new YodleeServiceConsumer();

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

    @RequestMapping(value = "/api/authenticate", method = RequestMethod.POST)
    public ResponseEntity<Object> createAuthenticationToken(@RequestBody JwtRequest authenticationRequest) throws Exception {
        String apiVersion = env.getProperty(APP_VERSION);
        String baseUrl = env.getProperty(BASE_URL);
        String cobrandName = jwtBusinessService.getCobrandName();
        Cobrand cobrand = new Cobrand();
        cobrand.setCobrandLogin(authenticationRequest.getUsername());
        cobrand.setCobrandPassword(authenticationRequest.getPassword());
        cobrand.setLocale("en_US");
        CobrandRequest cobrandRequest = new CobrandRequest();
        cobrandRequest.setCobrand(cobrand);
        CobrandLoginResponse resp = yodleeServiceConsumer.cobrandLoginValidation(baseUrl, apiVersion, cobrandName, cobrandRequest);
        if (resp.getErrorResponse().getErroCode() != null && resp.getErrorResponse().getErroCode().toString().equalsIgnoreCase("401")) {

            return new ResponseEntity<Object>(
                    resp.getErrorResponse(), new HttpHeaders(), HttpStatus.UNAUTHORIZED);
        } else {
            String jwtToken = jwtTokenUtil.generateToken(jwtBusinessService.getUserDetails(authenticationRequest.getUsername(), authenticationRequest.getPassword()));
            jwtBusinessService.insertJwtAndCobSessionToken(resp.getSession().getCobSession(), jwtToken, cobrandName);
            logger.info("Authentication success:"+jwtToken);
            return ResponseEntity.ok(new JwtResponse(jwtToken));

        }

    }


    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is for register a user.
     *
     * @return Cobrand session token
     * @throws Exception
     */

    @RequestMapping(value = "/api/user/register", method = RequestMethod.POST)
    public ResponseEntity<Object> userRegister(@RequestBody UserRegisterRequest userRegisterRequest) throws Exception {
        String apiVersion = env.getProperty(APP_VERSION);
        String baseUrl = env.getProperty(BASE_URL);
        String cobrandName = jwtBusinessService.getCobrandName();
        String cobrandSessionToken = jwtBusinessService.getCobrandSessionToken();
        UserRegisterResponse userRegisterResp = yodleeServiceConsumer.userRegister(baseUrl, apiVersion, cobrandName, cobrandSessionToken, userRegisterRequest);
        if (userRegisterResp.getErrorResponse().getErroCode() != null && userRegisterResp.getErrorResponse().getErroCode().toString().contains("40")) {
            if (userRegisterResp.getErrorResponse().getErroCode().toString() == ERROR_CODE_400) {
                return new ResponseEntity<Object>(
                        userRegisterResp.getErrorResponse(), new HttpHeaders(), HttpStatus.BAD_REQUEST);
            } else {
                return new ResponseEntity<Object>(
                        userRegisterResp.getErrorResponse(), new HttpHeaders(), HttpStatus.UNAUTHORIZED);
            }
        } else {
            jwtBusinessService.registerUserInDB(userRegisterRequest.getUser().getLoginName(), userRegisterRequest.getUser().getPassword());
            return ResponseEntity.ok(userRegisterResp);
        }
    }


    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is for get the registered users list.
     *
     * @return Users list
     * @throws Exception
     */

    @RequestMapping(value = "/api/users", method = RequestMethod.GET)
    public ResponseEntity<Object> userRegisterList() throws Exception {
        return ResponseEntity.ok(jwtBusinessService.getUserList());
    }


    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is for return specific user account list.
     *
     * @return user account list.
     * @throws Exception
     */

    @RequestMapping(value = "/api/user/account", method = RequestMethod.GET)
    public ResponseEntity<Object> userAccount(@RequestParam(value = "username", defaultValue = "") String username) throws Exception {
        if (username != "" && jwtBusinessService.UsernameExist(username)) {
            String apiVersion = env.getProperty(APP_VERSION);
            String baseUrl = env.getProperty(BASE_URL);
            String cobrandName = jwtBusinessService.getCobrandName();
            String cobrandSessionToken = jwtBusinessService.getCobrandSessionToken();
            String password = jwtBusinessService.getPasswordOfUser(username);
            String args[] = getArgs("");
            YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
            String yodleeUserJwtToken = tokenYodleeGenerator.generateJwtYodlee(false, username);
            String userSessionToken = yodleeServiceConsumer.createUserSessionToken(baseUrl, apiVersion, cobrandName, cobrandSessionToken, username, password);
            jwtBusinessService.insertUserSessionToken(userSessionToken);
            return ResponseEntity.ok(yodleeServiceConsumer.getAccountInformation(baseUrl, apiVersion, cobrandName, yodleeUserJwtToken));
        } else {
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroCode(ERROR_CODE_400);
            errorResponse.setErroMessage(INVALID_USERNAME + username);
            return ResponseEntity.ok(errorResponse);
        }
    }


    /**
     * RequestMapping annotation maps HTTP requests to handler methods of REST controllers.
     * This method is to get the user specific account statement
     *
     * @return Statement
     * @throws Exception
     */

    @RequestMapping(value = "/api/user/statement", method = RequestMethod.GET)
    public ResponseEntity<Object> userStatement(@RequestParam(value = "username", defaultValue = "") String username,
                                                @RequestParam(value = "accountId", defaultValue = "0") long accountID,
                                                @RequestParam(value = "isLatest", defaultValue = "true") boolean isLatest,
                                                @RequestParam(value = "status", defaultValue = "ACTIVE") String status,
                                                @RequestParam(value = "container", defaultValue = "") String container) throws Exception {
        if (username == "" || accountID == 0 || container == "") {
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroCode(ERROR_CODE_400);
            errorResponse.setErroMessage(PARAM_INVALID);
            return ResponseEntity.ok(errorResponse);
        } else if (jwtBusinessService.UsernameExist(username)) {
            String args[] = getArgs("");
            String apiVersion = env.getProperty(APP_VERSION);
            String baseUrl = env.getProperty(BASE_URL);
            String cobrandName = jwtBusinessService.getCobrandName();
            YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
            String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, username);
            return ResponseEntity.ok(yodleeServiceConsumer.getStatements(baseUrl, apiVersion, cobrandName, yodleeUserToken, accountID, container, isLatest, status));
        } else {
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroCode(ERROR_CODE_400);
            errorResponse.setErroMessage(INVALID_USERNAME + username);
            return ResponseEntity.ok(errorResponse);
        }
    }


    /**
     * This method to generate the fastlink and retrun the fastlink launch parameters.
     *
     * @param username
     * @return fastlink launch parameters
     * @throws Exception
     */
    @RequestMapping(value = "/api/user/fastlink")
    public ResponseEntity<?> generateApplicationTokenYodlee(@RequestParam(value = "username", defaultValue = "") String username) throws Exception {
        if (username != "" && jwtBusinessService.UsernameExist(username)) {
            String args[] = getArgs("");
            YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
            String yodleeToken = tokenYodleeGenerator.generateJwtYodlee(false, username);
            FastlinkResponse fastlinkResponse = new FastlinkResponse();
            fastlinkResponse.setFastLink(env.getProperty(FASTLINK));
            fastlinkResponse.setFinAppid(Long.parseLong(env.getProperty(FINAPPID)));
            fastlinkResponse.setFastLinkJwtToken(yodleeToken);
            fastlinkResponse.setRedirectReq(Boolean.parseBoolean(env.getProperty(REDIRECTREQ)));
            fastlinkResponse.setCallbackUrl(env.getProperty(CALBACKURL));
            return ResponseEntity.ok(fastlinkResponse);
        } else {
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroCode(ERROR_CODE_400);
            errorResponse.setErroMessage(INVALID_USERNAME + username);
            return ResponseEntity.ok(errorResponse);
        }
    }

    /**
     * This method to return user transaction information.
     *
     * @param username
     * @param container
     * @param accountId
     * @param fromDate
     * @param toDate
     * @return Transaction info
     * @throws Exception
     */
    @RequestMapping(value = "/api/user/transactions")
    public ResponseEntity<?> userTransaction(@RequestParam(value = "username", defaultValue = "") String username,
                                             @RequestParam(value = "container", defaultValue = "") String container,
                                             @RequestParam(value = "accountId", defaultValue = "") String accountId,
                                             @RequestParam(value = "fromDate", defaultValue = "") String fromDate,
                                             @RequestParam(value = "toDate", defaultValue = "") String toDate) throws Exception {
        if (username != "" && jwtBusinessService.UsernameExist(username)) {
            String args[] = getArgs("");
            String apiVersion = env.getProperty(APP_VERSION);
            String baseUrl = env.getProperty(BASE_URL);
            String cobrandName = jwtBusinessService.getCobrandName();
            YodleeJwtTokenGenerate tokenYodleeGenerator = new YodleeJwtTokenGenerate(args);
            String yodleeUserToken = tokenYodleeGenerator.generateJwtYodlee(false, username);
            return ResponseEntity.ok(yodleeServiceConsumer.getTransactionInfo(baseUrl, apiVersion, cobrandName, yodleeUserToken, Long.parseLong(accountId), container, fromDate, toDate));
        } else {
            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.setErroCode(ERROR_CODE_400);
            errorResponse.setErroMessage(INVALID_USERNAME + username);
            return ResponseEntity.ok(errorResponse);
        }
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

}