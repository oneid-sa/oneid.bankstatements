using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class AbsaLogin : BaseClass
    {
        public readonly string bank = "ABSA";
        public string accountNumber { get; set; }
        public string pin { get; set; }
        public string userNumber { get; set; }
        public string absolutePassword { get; set; }
    }
}
