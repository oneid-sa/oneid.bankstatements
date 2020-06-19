using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class TwoFAMessage : BaseClass
    {
        public string type { get; set; }
        public string code { get; set; }
        public string text { get; set; }
    }
}
