using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionManagement.models
{
    public class SuccessResponse
    {
        public String status { get; set; }
        public int statusCode { get; set; }
        public String message { get; set; }
    }
}
