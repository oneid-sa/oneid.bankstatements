using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class BankStatementRequest : BaseClass
    {
        public string sessionId { get; set; }
        public string accountId { get; set; }
    }
}
