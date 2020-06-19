using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class PostResult
    {
        public PostResult()
        {
            this.ID = "1";
            this.Result = "POSTED";
        }

        [JsonIgnore]
        public String ID
        {
            get;
            set;
        }

        public String Result
        {
            get;
            set;
        }
    }
}
