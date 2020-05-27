/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.model;

import java.util.List;


public class ProviderResponse {

        private List<Provider> provider;

        public void setProvider(List<Provider> provider){
            this.provider = provider;
        }
        public List<Provider> getProvider(){
            return this.provider;
        }

}
