/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.Respository;

import digital.oneid.model.TableYodleeJwtToken;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * A JwtTokenRepository is for encapsulating storage, retrieval,
 * and search behavior which emulates a collection of objects
 * @author Hubino
 * @version 1.0
 * @since 10/03/2020
 */

@Repository
public interface JwtTokenRepository extends JpaRepository<TableYodleeJwtToken,Integer> {

    TableYodleeJwtToken findByUid(int uid);

}
