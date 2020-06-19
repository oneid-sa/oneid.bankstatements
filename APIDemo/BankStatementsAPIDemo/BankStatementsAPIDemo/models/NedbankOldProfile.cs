using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class NedbankOldProfile
    {
        public readonly string profileType = "Old";
        public string accountNumber { get; set; }
        public string accountPin { get; set; }
        public string password { get; set; }
    }
}
