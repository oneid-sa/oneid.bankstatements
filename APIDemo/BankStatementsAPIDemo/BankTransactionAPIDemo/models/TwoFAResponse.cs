using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class TwoFAResponse : BaseClass
    {
        public string sessionId { get; set; }
        public TwoFAMessage message { get; set; }
    }
}
