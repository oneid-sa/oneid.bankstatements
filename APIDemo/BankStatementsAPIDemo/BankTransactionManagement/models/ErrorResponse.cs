using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionManagement.models
{
    public class ErrorResponse
    {
        public String errorCode { get; set; }
        public String errorMessage { get; set; }
        public  String referenceCode { get; set; }
    }
}
