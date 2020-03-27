package digital.oneid.Respository;

import digital.oneid.model.TableCobrandSession;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

/**
 * Created by hubinotech on 25/03/20.
 */
public interface CobrandSessionRepository extends JpaRepository<TableCobrandSession, Integer> {
    @Query(value = "SELECT cobrandtoken FROM cobrand_session_token WHERE jwttoken=?1", nativeQuery = true)
    String GetCobrandSessionToken(String jwt);
}
