using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class BankStatementResult : BaseClass
    {
        public string AdditionalMessage { get; set; }
        public string Result { get; set; }
        public IList<BankStatement> bankStatements { get; set; }
    }
}
