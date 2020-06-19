using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class Account : BaseClass
    {
        public bool includeInNetWorth { get; set; }
        public string accountName { get; set; }
        public bool isManual { get; set; }
        public string accountType { get; set; }
        public string memo { get; set; }
        public string accountNumber { get; set; }
        public string accountStatus { get; set; }
        public string lastUpdated { get; set; }
        public bool isAsset { get; set; }
        public string createdDate { get; set; }
        public string aggregationSource { set; get; }
        public Amount balance { get; set; }
        public string providerId { get; set; }
        public string providerAccountId { get; set; }
        public string nickname { get; set; }
        public string id { get; set; }
        public string providerName { get; set; }
        public string CONTAINER { get; set; }

        public List<AccountDatasetInformation> dataset { get; set; }
    }
}
