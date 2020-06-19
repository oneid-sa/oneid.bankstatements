using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class CapitecLogin : BaseClass
    {
        public string bank = "Capitec";
        public string accountNumber { get; set; }
        public string password { get; set; }
    }
}
