package digital.oneid.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;

@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_EMPTY)

public class UserUnregister {
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    public String userName;
    @JsonInclude(JsonInclude.Include.NON_EMPTY)
    public String uniqueReference;
}
