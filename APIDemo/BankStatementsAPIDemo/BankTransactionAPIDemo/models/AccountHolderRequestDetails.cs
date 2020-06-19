using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class AccountHolderRequestDetails : BaseClass
    {

        public String accountHolderIdentifier { get; set; }
        
        public String uniqueReference { get; set; }
    }
}
