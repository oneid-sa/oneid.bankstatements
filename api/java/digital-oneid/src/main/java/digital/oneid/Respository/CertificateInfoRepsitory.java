/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.Respository;

import digital.oneid.model.TableCertificate;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * A CertificateInfoRepsitory is for encapsulating storage, retrieval,
 * and search behavior which emulates a collection of objects
 * @author Hubino
 * @version 1.0
 * @since 10/03/2020
 */

public interface CertificateInfoRepsitory extends JpaRepository<TableCertificate,Integer> {
    TableCertificate findByUid(int uid);
}
