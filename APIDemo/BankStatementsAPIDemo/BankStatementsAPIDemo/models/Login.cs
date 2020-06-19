using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class Login : BaseClass
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
