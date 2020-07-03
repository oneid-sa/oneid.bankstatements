using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionManagement.models
{
    public class AuditResponse
    {
        //2020-06-04 22:05:09/0:0:0:0:0:0:0:1/USER-TRANSACTIONS/1234567899999/1234567899999/10112165/Success

        string messageValue = "";

        
        public int id { get; set; }
        public int companyId { get; set; }
        public int roleId { get; set; }
        public string message {
            get
            {
                return messageValue;
            }

            set {
                messageValue = value;
                if (messageValue.Contains("USER-TRANSACTIONS") && messageValue.Contains("Success"))
                {
                    string[] audititems = messageValue.Split('/');
                    usageDate = audititems[0].Substring(0, 10);
                    transactionDescription = audititems[2];
                    accountholderIdentifier = audititems[3];
                    uniqueReference = audititems[4];
                }
            } 
        
        }
        public string usageDate { get; set; }
        public string accountholderIdentifier { get; set; }
        public string uniqueReference { get; set; }
        public string transactionDescription { get; set; }
    }
}
