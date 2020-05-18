/**
 * ******************************************************
 * Copyright (c) 2020, PowerRecruit.
 * All rights reserved.
 ********************************************************/

package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 * Created by hubinotech on 07/04/20.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class AuditSearch {
    private int page_no;
    private int limit;
    private String sortby; // Ascending / Descending
    private int companyId;
    private String start_date;
    private String end_date;

    public int getPage_no() {
        return page_no;
    }
    public void setPage_no(int page_no) {
        this.page_no = page_no;
    }

    public int getLimit() {
        return limit;
    }
    public void setLimit(int limit) {
        this.limit = limit;
    }

    public String getSortby() {
        return sortby;
    }
    public void setSortby(String sortby) {
        this.sortby = sortby;
    }

    public int getCompanyId() {
        return companyId;
    }
    public void setCompanyId(int companyId) {
        this.companyId = companyId;
    }

    public String getStart_date() {
        return start_date;
    }
    public void setStart_date(String start_date) {
        this.start_date = start_date;
    }

    public String getEnd_date() {
        return end_date;
    }
    public void setEnd_date(String end_date) {
        this.end_date = end_date;
    }
}
