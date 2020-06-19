using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class LoginResponse
    {
        public string status_code { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
}
