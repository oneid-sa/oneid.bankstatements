package digital.oneid.Respository;

import digital.oneid.model.TableUserSessionToken;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

/**
 * Created by hubinotech on 26/03/20.
 */
public interface UserSessionRepository extends JpaRepository<TableUserSessionToken, Integer> {

    @Query(value = "SELECT usersessiontoken FROM user_session_token WHERE jwttoken=?1", nativeQuery = true)
    String GetUserSessionToken(String jwttoken);
}
