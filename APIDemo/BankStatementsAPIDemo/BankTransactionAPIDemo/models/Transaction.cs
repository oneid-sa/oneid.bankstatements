using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class Transaction : BaseClass
    {
        public string CONTAINER { get; set; }
        public int id { get; set; }
        public Amount amount { get; set; }
        public string baseType { get; set; }
        public string type { get; set; }
        public Amount commission { get; set; }
        public string categoryType { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
        public string categorySource { get; set; }
        public int highLevelCategoryId { get; set; }
        public string createdDate { get; set; }
        public string lastUpdated { get; set; }
        public Description description { get; set; }
        public string date { get; set; }
        public string transactionDate { get; set; }
        public string settleDate { get; set; }
        public bool isManual { get; set; }
        public string sourceType { get; set; }
        public string status { get; set; }
        public string cusipNumber { get; set; }
        public Amount price { get; set; }
        public int quantity { get; set; }
        public string symbol { get; set; }
        public int accountId { get; set; }
    }

}
