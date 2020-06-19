using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class NedbankNewProfile
    {
        public readonly string profileType = "New";
        public string username { get; set; }
        public string password { get; set; }
    }
}
