using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class Category
    {
        public int id { get; set; }
        public string source { set; get; }
        public string classification { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string highLevelCategoryId { get; set; }
        public string highLevelCategoryName { get; set; }
    }
}
