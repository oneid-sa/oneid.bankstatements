package digital.oneid.Respository;

import digital.oneid.model.TableCobrandInfo;
import digital.oneid.model.TableUserRegistration;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

/**
 * Created by hubinotech on 25/03/20.
 */
public interface CobrandRepository  extends JpaRepository<TableCobrandInfo, Integer> {
    @Query(value = "SELECT cobrandname FROM cobrandinfo WHERE cobid=?1", nativeQuery = true)
    String GetCobrandName(int cobid);
}
