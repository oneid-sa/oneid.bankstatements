/**
 * ******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 ********************************************************/

package digital.oneid.service;

import digital.oneid.Respository.*;
import digital.oneid.model.*;
import digital.oneid.security.BCryptPasswordEncoder;
import net.minidev.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

/**
 * Service Components are the class file which contains @Service annotation.
 * These class files are used to write business logic in a different layer,
 * separated from @RestController class file
 * @author Hubino
 * @version 1.0
 * @since 10/03/2020
 */

@Service
public class JwtBusinessService implements UserDetailsService {

    String authorization_username = "";
    String authorize_jwttoken = "";

    @Autowired
    private UserRepository userDao;

    @Autowired
    private UserSessionRepository userSessionRepository;
    @Autowired
    private JwtTokenRepository jwtTokenRepository;

    @Autowired
    private CertificateInfoRepsitory certificateRepository;

    @Autowired
    private CobrandRepository cobrandRepository;

    @Autowired
    private CobrandSessionRepository cobrandSessionRepository;

    @Autowired
    private PasswordEncoder bcryptEncoder;

    BCryptPasswordEncoder bCryptPasswordEncoder = new BCryptPasswordEncoder();

    /**
     * This method is to set authorization token of every service call.
     * @param authorization_username
     */
    public void setAuthorizationUsername(String authorization_username, String authorize_jwttoken) {
        this.authorization_username = authorization_username;
        this.authorize_jwttoken = authorize_jwttoken;
    }

    /**
     * This method is to get the user information from User registration table.
     * @param username
     * @return UserDetails
     * @throws UsernameNotFoundException
     */
    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        TableUserRegistration daoUserRegistration = userDao.findByUsername(username);
        if (daoUserRegistration == null) {
            throw new UsernameNotFoundException("User not found with username: " + username);
        } else {
            return new User(daoUserRegistration.getUsername(), daoUserRegistration.getPassword(),
                    new ArrayList<>());
        }
    }

    /**
     * Validate the username and password in User registration table.
     * @param username
     * @param password
     * @return UserDetails
     * @throws UsernameNotFoundException
     */
    public UserDetails getUserDetails(String username, String password) throws UsernameNotFoundException {
        TableUserRegistration daoUserRegistration = userDao.findByUsername(username);
        if (daoUserRegistration == null) {
            throw new UsernameNotFoundException("User not found with username: " + username);
        } else {
            if (daoUserRegistration.getPassword().equalsIgnoreCase(password)) {
                return new User(daoUserRegistration.getUsername(), daoUserRegistration.getPassword(),
                        new ArrayList<>());
            } else {
                throw new UsernameNotFoundException("Invalid password found: " + username);
            }

        }

    }


    /**
     * Insert the generated yodlee token and validate the expiration of the token.
     * @param existTokenInfo
     * @param yodleeToken
     * @param expiryHour
     */
    public void insertYodleeToken(TableYodleeJwtToken existTokenInfo, String yodleeToken, int expiryHour) {
        int user_id = userDao.GetUserId(authorization_username);
        long expirytime = generate_tokens_expiry_time(expiryHour);
        TableYodleeJwtToken tokenInfo = new TableYodleeJwtToken();
        tokenInfo.setUserId(user_id);
        tokenInfo.setExpiry((expirytime - 2));
        tokenInfo.setYodleeJwtToken(yodleeToken);
        jwtTokenRepository.delete(existTokenInfo);
        jwtTokenRepository.save(tokenInfo);
    }

    /**
     * This method to get yodlee token from tokeninfo table.
     * @return YodleeJwtTokenInfo
     * @throws UsernameNotFoundException
     */
    public TableYodleeJwtToken getYodleeTokenInfo() throws UsernameNotFoundException {
        int user_id = userDao.GetUserId(authorization_username);
        TableYodleeJwtToken tokenInfo = jwtTokenRepository.findByUid(user_id);
        return tokenInfo;
    }

    /**
     * User name exist in DB.
     * @param username
     * @return boolean
     */
    public Boolean UsernameExist(String username) {
        String uid = userDao.GetUidFromUserName(username);
        if (uid != null)
            return true;
        else
            return false;
    }

    /**
     *  Get the certificate information to access the yodlee api.
     * @return TableCertificate
     */
    public TableCertificate getCertificateInfo() {
        int user_id = userDao.GetUserId(authorization_username);
        TableCertificate certInfo = certificateRepository.findByUid(1);
        return certInfo;
    }

    /**
     * Get the cobrand name of the customer.
     * @return cobrand name
     */
    public String getCobrandName() {
        return cobrandRepository.GetCobrandName(1);
    }

    /**
     * Map the cobrand session token and jwt token.
     * @param cobSessionToken
     * @param jwtToken
     * @param cobrandName
     */
    public void insertJwtAndCobSessionToken(String cobSessionToken, String jwtToken, String cobrandName) {
        TableCobrandSession tableCobrandSession = new TableCobrandSession();
        tableCobrandSession.setCobrandName(cobrandName);
        tableCobrandSession.setCobrandSessionToken(cobSessionToken);
        tableCobrandSession.setJwtToken(jwtToken);
        cobrandSessionRepository.save(tableCobrandSession);
    }

    /**
     * To get the cobrand session token
     * @return cobrand session token
     */
    public String getCobrandSessionToken() {
        return cobrandSessionRepository.GetCobrandSessionToken(authorize_jwttoken);
    }

    /**
     * Get the user password by username.
     * @param username
     * @return password
     */
    public String getPasswordOfUser(String username) {
        return userDao.GetPassword(username);
    }

    /**
     * Register user in DB.
     * @param username
     * @param password
     */
    public void registerUserInDB(String username, String password) {
        TableUserRegistration userRegistration = new TableUserRegistration();
        userRegistration.setUsername(username);
        userRegistration.setPassword(password);
        userRegistration.setRoleID(2);
        userDao.save(userRegistration);
    }

    /**
     * Get the users list from DB.
     * @return
     */
    public JSONObject getUserList() {
        List<String> list = userDao.GetUserList(2);
        String usernames = String.join(",", list);
        JSONObject object = new JSONObject();
        object.put("Users", usernames);
        return object;
    }

    /**
     * Insert user session token for future api access. No need to generate the new one.
     * @param userSessionToken
     */
    public void insertUserSessionToken(String userSessionToken) {
        TableUserSessionToken tableUserSessionToken = new TableUserSessionToken();
        tableUserSessionToken.setUserSessionToken(userSessionToken);
        tableUserSessionToken.setJwttoken(authorize_jwttoken);
        userSessionRepository.save(tableUserSessionToken);
    }

    /**
     * This method is for get the user session token by authorize jwt token.
     * @return
     */

    public String getUserSessionToken() {
        return userSessionRepository.GetUserSessionToken(authorize_jwttoken);
    }

    /**
     * Generate the token expiry time.
     * @param mins
     * @return
     */
    public Long generate_tokens_expiry_time(int mins) {
        Date dNow = new Date();
        Calendar cal = Calendar.getInstance();
        cal.setTime(dNow);
        cal.add(Calendar.MINUTE, mins);
        dNow = cal.getTime();
        return (dNow.getTime() / 1000);
    }
}