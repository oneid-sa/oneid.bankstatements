using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class TransactionResponse
    {
        public List<Transaction> transaction { get; set; }
    }
}
