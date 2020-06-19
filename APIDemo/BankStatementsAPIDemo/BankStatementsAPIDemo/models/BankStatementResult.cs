using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class BankStatementResult
    {
        public string AdditionalMessage { get; set; }
        public string Result { get; set; }
        public IList<BankStatement> bankStatements { get; set; }
    }
}
