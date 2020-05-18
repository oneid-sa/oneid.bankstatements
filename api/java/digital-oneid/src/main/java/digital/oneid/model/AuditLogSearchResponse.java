package digital.oneid.model;

import org.springframework.data.domain.Page;

/**
 * Created by hubinotech on 05/05/20.
 */
public class AuditLogSearchResponse {
    private Page<TableAuditLog> tableAuditLogs;
    private String message;
    private int code;

    public Page<TableAuditLog> getTableAuditLogs() {
        return tableAuditLogs;
    }
    public void setTableAuditLogs(Page<TableAuditLog> tableAuditLogs) {
        this.tableAuditLogs = tableAuditLogs;
    }
    public String getMessage() {
        return message;
    }
    public void setMessage(String message) {
        this.message = message;
    }
    public int getCode() {
        return code;
    }
    public void setCode(int code) {
        this.code = code;
    }
}
