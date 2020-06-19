using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class User
    {
        public string loginName { get; set; }
	    public string locale { get; set; }
		public string email { get; set; }
        
        public string uniqueReference { get; set; }
    }
}
