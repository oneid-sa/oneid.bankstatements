using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionManagement.models
{
    public class CompanyCreateRequest : BaseClass
    {
        public String loginname { get; set; }
        public String password { get; set; }
        public String companyName { get; set; }
        public String email { get; set; }
        public String address { get; set; }
    }
}
