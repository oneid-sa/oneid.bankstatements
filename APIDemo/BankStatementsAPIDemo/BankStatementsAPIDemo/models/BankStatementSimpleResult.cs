using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class BankStatementSimpleResult
    {
        public String RequesterUniqueReference
        {
            get;
            set;
        }
        public String TransactionReference
        {
            get;
            set;
        }

        public String Result
        {
            get;
            set;
        }
        public String Message
        {
            get;
            set;
        }
    }
}

