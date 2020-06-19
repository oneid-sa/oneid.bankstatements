using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
    public class LoginResponse
    {
        public string loginResponse { get; set; }
        public string token { get; set; }
        public int expiresInSeconds { get; set; }
        public string additionalMessage { get; set; }
    }
}
