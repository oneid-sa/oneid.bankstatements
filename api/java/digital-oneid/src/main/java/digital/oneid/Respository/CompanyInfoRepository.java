package digital.oneid.Respository;

import digital.oneid.model.TableCompanyInfo;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

/**
 * Created by hubinotech on 01/05/20.
 */
public interface CompanyInfoRepository extends JpaRepository<TableCompanyInfo, Integer> {
    TableCompanyInfo findByUsername(String username);

    TableCompanyInfo findByEmail(String email);

    TableCompanyInfo findByCompanyName(String companyName);

    List<TableCompanyInfo> findByRoleIdGreaterThan(int i);


}
