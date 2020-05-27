package digital.oneid.Respository;

import digital.oneid.model.TableTransactionCategory;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Created by hubinotech on 03/05/20.
 */
public interface TransactionCategoryRepository extends JpaRepository<TableTransactionCategory,Integer> {
}
