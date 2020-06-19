using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class AccountDatasetInformation : BaseClass
    {
        public string name { get; set; }
        public string additionalStatus { get; set; }
        public string updateEligibility { get; set; }
        public string lastUpdated { get; set; }
        public string lastUpdateAttempt { get; set; }
    }
}
