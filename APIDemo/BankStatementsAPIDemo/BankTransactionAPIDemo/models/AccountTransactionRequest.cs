using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class AccountTransactionRequest : BaseClass

    {
        
        public String accountHolderIdentifier { get; set; }
        public String uniqueReference { get; set; }

        public String container { get; set; }

        public String accountid { get; set; }

        public String fromDate { get; set; }

        public String toDate { get; set; }


        public String categoryId { get; set; }

        public String categoryType { get; set; }

        public String highLevelCategoryId { get; set; }

    }
}
