/**
 * ******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 ********************************************************/

package digital.oneid.service;

import digital.oneid.Respository.*;
import digital.oneid.model.*;
import digital.oneid.security.BCryptPasswordEncoder;
import digital.oneid.utils.Constants;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

/**
 * Service Components are the class file which contains @Service annotation.
 * These class files are used to write business logic in a different layer,
 * separated from @RestController class file
 *
 * @author Hubino
 * @version 1.0
 * @since 10/03/2020
 */

@Service
public class JwtBusinessService extends Constants implements UserDetailsService {

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
    private CompanyInfoRepository companyInfoRepository;

    @Autowired
    private TransactionCategoryRepository transactionCategoryRepository;

    @Autowired
    private AuditLogRepository auditLogRepository;

    @Autowired
    private PasswordEncoder bcryptEncoder;

    BCryptPasswordEncoder bCryptPasswordEncoder = new BCryptPasswordEncoder();

    /**
     * This method is to set authorization token of every service call.
     */

    public String currentDateTime() {
        DateFormat df = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        Date dateobj = new Date();
        return df.format(dateobj);
    }

    /**
     *
     * @param authorization_username
     * @param authorize_jwttoken
     */
    public void setAuthorizationUsername(String authorization_username, String authorize_jwttoken) {
        this.authorization_username = authorization_username;
        this.authorize_jwttoken = authorize_jwttoken;
    }

    /**
     * This method is to get the user information from User registration table.
     *
     * @param username
     * @return UserDetails
     * @throws UsernameNotFoundException
     */
    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        TableCompanyInfo cInfo = companyInfoRepository.findByUsername(username);
        if (cInfo == null) {
            throw new UsernameNotFoundException("User not found with username: " + username);
        } else {
            return new User(cInfo.getUsername(), cInfo.getPassword(),
                    new ArrayList<>());
        }
    }

    /**
     * Validate the username and password in User registration table.
     *
     * @param username
     * @param password
     * @return UserDetails
     * @throws UsernameNotFoundException
     */
    public UserDetails getUserDetails(String username, String password) throws UsernameNotFoundException {
        TableCompanyInfo cInfo = companyInfoRepository.findByUsername(username);
        if (cInfo == null) {
            throw new UsernameNotFoundException("User not found with username: " + username);
        } else {
            if (cInfo.getPassword().equalsIgnoreCase(password)) {
                return new User(cInfo.getUsername(), cInfo.getPassword(),
                        new ArrayList<>());
            } else {
                throw new UsernameNotFoundException("Invalid password found: " + username);
            }

        }

    }


    /**
     * Insert the generated yodlee token and validate the expiration of the token.
     *
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
     *
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
     *
     * @param username
     * @return boolean
     */
    public Boolean UsernameExist(String username) {
        TableUserRegistration info = userDao.findByLoginName(username);
        if (info != null)
            return true;
        else
            return false;
    }

    /**
     * Get the certificate information to access the yodlee api.
     *
     * @return TableCertificate
     */
    public TableCertificate getCertificateInfo() {
        TableCertificate certInfo = certificateRepository.findByUid(1);
        return certInfo;
    }

    /**
     * Get the cobrand name of the customer.
     *
     * @return cobrand name
     */
    public String getCobrandName() {
        return cobrandRepository.GetCobrandName(1);
    }

    /**
     * Map the cobrand session token and jwt token.
     *
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
     *
     * @return cobrand session token
     */
    public String getCobrandSessionToken() {
        return cobrandSessionRepository.GetCobrandSessionToken(authorize_jwttoken);
    }

    /**
     * Get the user password by username.
     *
     * @param username
     * @return password
     */
    public String getPasswordOfUser(String username) {
        return userDao.GetPassword(username);
    }


    /**
     * Get the users list from DB.
     *
     * @return
     */
    public JSONObject getCompanyUserList(int companyId) {
        List<TableUserRegistration> registrationList = userDao.findByCompanyId(companyId);
        JSONObject jsonObject = new JSONObject();
        jsonObject.put("users", registrationList);
        jsonObject.put("status", "success");
        jsonObject.put("status_code", 200);
        return jsonObject;
    }

    /**
     * Insert user session token for future api access. No need to generate the new one.
     *
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
     *
     * @return
     */

    public String getUserSessionToken() {
        return userSessionRepository.GetUserSessionToken(authorize_jwttoken);
    }

    /**
     * Generate the token expiry time.
     *
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

    /**
     *
     * @param username
     * @return
     */
    public TableCompanyInfo getCompanyInfo(String username) {
        return companyInfoRepository.findByUsername(username);

    }

    /**
     * @param loginname
     * @return
     */
    public boolean companyLoginNameExist(String loginname) {
        if (companyInfoRepository.findByUsername(loginname) != null)
            return true;
        else
            return false;
    }

    /**
     * @param email
     * @return
     */
    public boolean emailExist(String email) {
        if (companyInfoRepository.findByEmail(email) != null)
            return true;
        else
            return false;
    }

    /**
     * @param companyName
     * @return
     */
    public boolean companyNameExist(String companyName) {
        if (companyInfoRepository.findByCompanyName(companyName) != null)
            return true;
        else
            return false;
    }

    public int getUserIdByName(String username) {
        return userDao.GetUserId(username);
    }

    /**
     * @return
     */
    public int getRoleAccess() {
        return companyInfoRepository.findByUsername(authorization_username).getRoleId();
    }

    /**
     * @param companyCreateRequest
     */
    public void createCompany(CompanyCreateRequest companyCreateRequest) {
        TableCompanyInfo tableCompanyInfo = new TableCompanyInfo();
        tableCompanyInfo.setCompanyName(companyCreateRequest.getCompanyName());
        tableCompanyInfo.setUsername(companyCreateRequest.getLoginname());
        tableCompanyInfo.setEmail(companyCreateRequest.getEmail());
        tableCompanyInfo.setAddress(companyCreateRequest.getAddress());
        tableCompanyInfo.setPassword(companyCreateRequest.getPassword());
        tableCompanyInfo.setRoleId(2);
        tableCompanyInfo.setCreatedAt(currentDateTime());
        tableCompanyInfo.setUpdatedAt(currentDateTime());
        companyInfoRepository.save(tableCompanyInfo);

    }

    /**
     * @return
     */
    public JSONObject getCompanyList() {
        List<TableCompanyInfo> companyInfoList = companyInfoRepository.findByRoleIdGreaterThan(1);

        JSONObject jsonObject = new JSONObject();
        jsonObject.put("companys", companyInfoList);
        jsonObject.put("status", "success");
        jsonObject.put("status_code", 200);
        return jsonObject;
    }

    /**
     * @return
     */
    public int getCompanyId() {
        return companyInfoRepository.findByUsername(authorization_username).getId();
    }

    /**
     * @param companyID
     * @param username
     * @return
     */
    public int checkCompanyIdAndLoginNameIsValid(int companyID, String username) {
        TableUserRegistration tableUserRegistration = userDao.findByCompanyIdAndLoginName(companyID, username);
        if (tableUserRegistration != null)
            return tableUserRegistration.getId();
        else
            return 0;
    }

    /**
     * @param companyId
     * @param userRegisterRequest
     */
    public void registerUserInDB(int companyId, long createdYodleeId, UserRegisterRequest userRegisterRequest) {
        TableUserRegistration userRegistration = new TableUserRegistration();
        userRegistration.setCompanyId(companyId);
        userRegistration.setLoginName(userRegisterRequest.getUser().getLoginName());
        userRegistration.setPassword(userRegisterRequest.getUser().getPassword());
        userRegistration.setEmail(userRegisterRequest.getUser().getEmail());
        userRegistration.setCreatedAt(currentDateTime());
        userRegistration.setUpdatedAt(currentDateTime());
        userRegistration.setCreatedYodleeId(createdYodleeId);
        userDao.save(userRegistration);
    }

    /**
     *
     * @param companyId
     * @param username
     * @param categoryName
     * @param parentCategoryId
     */
    public void insertTransactionCategoryDB(int companyId, String username, String categoryName, long parentCategoryId) {
        TableTransactionCategory tableTransactionCategory = new TableTransactionCategory();
        tableTransactionCategory.setCompanyId(companyId);
        tableTransactionCategory.setUserId(getUserIdByName(username));
        tableTransactionCategory.setCategoryName(categoryName);
        tableTransactionCategory.setParentId(parentCategoryId);
        tableTransactionCategory.setCreatedAt(currentDateTime());
        tableTransactionCategory.setUpdatedAt(currentDateTime());
        transactionCategoryRepository.save(tableTransactionCategory);
    }

    public void AuditLogging(int companyId, int roleId, String ipaddress, String message) {
        String eMessage = currentDateTime() +"/"+ipaddress+"/"+message;
        TableAuditLog tableAuditLog = new TableAuditLog();
        tableAuditLog.setCompanyId(companyId);
        tableAuditLog.setRoleId(roleId);
        tableAuditLog.setMessage(eMessage);
        tableAuditLog.setCreatedAt(currentDateTime());
        auditLogRepository.save(tableAuditLog);
    }

    public AuditLogSearchResponse getAuditHistory(AuditSearch auditSearch) {
        int limit = auditSearch.getLimit();
        int page = auditSearch.getPage_no();
        Pageable pageable = null;
        Page<TableAuditLog> tableAuditLogs = null;

        if (auditSearch.getSortby() != null && auditSearch.getSortby() != EMPTY) {
            if (auditSearch.getSortby().equalsIgnoreCase(ASC))
                pageable = PageRequest.of(page, limit, Sort.by(COL_CREATEDAT).ascending());
            else
                pageable = PageRequest.of(page, limit, Sort.by(COL_CREATEDAT).descending());
        } else {
            pageable = PageRequest.of(page, limit, Sort.by(COL_CREATEDAT).descending());
        }

        if(String.valueOf(auditSearch.getCompanyId()) != null && auditSearch.getCompanyId() != 0 && auditSearch.getStart_date() != null && auditSearch.getStart_date() !=EMPTY && auditSearch.getEnd_date() !=EMPTY && auditSearch.getEnd_date() != null) {
            tableAuditLogs = auditLogRepository.findByCompanyIdAndCreatedAtBetween(auditSearch.getCompanyId(),auditSearch.getStart_date(),auditSearch.getEnd_date(),pageable);
        } else if(String.valueOf(auditSearch.getCompanyId()) != null && auditSearch.getCompanyId() != 0) {
            tableAuditLogs = auditLogRepository.findByCompanyId(auditSearch.getCompanyId(),pageable);
        } else if(auditSearch.getStart_date() != null && auditSearch.getStart_date() !=EMPTY && auditSearch.getEnd_date() != null && auditSearch.getEnd_date() !=EMPTY){
            tableAuditLogs = auditLogRepository.findByCreatedAtBetween(auditSearch.getStart_date(),auditSearch.getEnd_date(),pageable);
        } else {
            tableAuditLogs = auditLogRepository.findAll(pageable);
        }

        AuditLogSearchResponse auditLogSearchResponse = new AuditLogSearchResponse();
        auditLogSearchResponse.setTableAuditLogs(tableAuditLogs);
        auditLogSearchResponse.setMessage("Success");
        auditLogSearchResponse.setCode(200);
        return auditLogSearchResponse;
    }
}