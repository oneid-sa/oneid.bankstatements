/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.Respository;

import digital.oneid.model.TableUserRegistration;
import digital.oneid.model.UsersList;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * A UserRepository is for encapsulating storage, retrieval,
 * and search behavior which emulates a collection of objects
 * @author Hubino
 * @version 1.0
 * @since 10/03/2020
 */
@Repository
public interface UserRepository extends JpaRepository<TableUserRegistration, Integer> {

    TableUserRegistration findByUsername(String username);

    @Query(value = "SELECT uid FROM user_registration WHERE username=?1", nativeQuery = true)
    int GetUserId(String username);


    @Query(value = "SELECT username FROM user_registration WHERE role_id=?1", nativeQuery = true)
    List<String> GetUserList(int role);

    @Query(value = "SELECT password FROM user_registration WHERE username=?1", nativeQuery = true)
    String GetPassword(String username);

    @Query(value = "SELECT uid FROM user_registration WHERE username=?1", nativeQuery = true)
    String GetUidFromUserName(String username);
}

