using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class NewCategoryRequest : BaseClass
    {
        public string username { get; set; }
        public string categoryName {get;set;}
        public string parentCategoryId { get; set; }
    }
}
