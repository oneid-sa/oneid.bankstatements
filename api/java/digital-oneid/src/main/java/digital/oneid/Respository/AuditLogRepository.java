package digital.oneid.Respository;

import digital.oneid.model.TableAuditLog;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Created by hubinotech on 04/05/20.
 */
public interface AuditLogRepository extends JpaRepository<TableAuditLog, Integer> {
    Page<TableAuditLog> findByCompanyIdAndCreatedAtBetween(int companyId, String start_date, String end_date, Pageable pageable);

    Page<TableAuditLog> findByCompanyId(int companyId, Pageable pageable);

    Page<TableAuditLog> findByCreatedAtBetween( String start_date, String end_date, Pageable pageable);
}
