using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionManagement.models
{
    public class AuditRequest : BaseClass
    {
        public int page_no { get; set; }
        public int limit { get; set; }
        public string sortby { get; set; }
        public int companyId { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }    
    }
}
