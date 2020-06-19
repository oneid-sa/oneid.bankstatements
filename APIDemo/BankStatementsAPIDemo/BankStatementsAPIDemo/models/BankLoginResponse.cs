using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class BankLoginResponse
    {
        public string Result { get; set; }
        public string AdditionalMessage { get; set; }

        public string sessionId
        {
            get;
            set;
        }

        public List<Account> accounts { get; set; }
    }
}
