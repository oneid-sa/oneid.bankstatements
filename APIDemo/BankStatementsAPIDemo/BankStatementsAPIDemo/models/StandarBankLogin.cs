using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class StandarBankLogin : BaseClass
    {
        public readonly string bank = "StandardBank";
        public string email { get; set; }
        public string password { get; set; }
    }
}
