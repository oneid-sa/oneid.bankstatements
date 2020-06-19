using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class BankStatementSimpleRequestPostResult : PostResult
    {
        public BankStatementSimpleRequestPostResult(String UniqueReference)
        {
            this.ID = "2";
            this.Result = "Received";
            UniqueReferenceID = UniqueReference;
        }

        public String UniqueReferenceID { get; }

        public String Message
        {
            get;
            set;
        }
    }
}
