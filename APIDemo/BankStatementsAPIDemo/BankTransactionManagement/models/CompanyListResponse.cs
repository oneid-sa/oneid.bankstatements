using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionManagement.models
{
    public class CompanyListResponse
    {
        public List<Company> companys { get; set; }
        public string status { get; set; }
        public int status_code { get; set; }
    }
}
