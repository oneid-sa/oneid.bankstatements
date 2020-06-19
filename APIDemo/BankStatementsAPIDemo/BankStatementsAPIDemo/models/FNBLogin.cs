using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class FNBLogin : BaseClass
    {
        public readonly string bank = "FNB";
        public string username { get; set; }

        public string password { get; set; }
    }
}
