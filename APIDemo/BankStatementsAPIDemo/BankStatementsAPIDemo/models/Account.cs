using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class Account
    {
        public string description { get; set; }
        public string accountNumber { get; set; }
        public bool bankStatementsDownloadable { get; set; }
        public string accountId { get; set; }
    }
}
