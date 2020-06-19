using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class NewSessionRequest : BaseClass
    {
        
        public String accountHolderIdentifier { get; set; }

        

        public String emailAddress { get; set; }
    }
}
