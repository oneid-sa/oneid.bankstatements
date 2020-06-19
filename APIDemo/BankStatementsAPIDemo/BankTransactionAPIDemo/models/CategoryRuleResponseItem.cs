using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class CategoryRuleResponseItem : BaseClass
    {
        public int userDefinedRuleId { get; set; }
        public int memId { get; set; }
        public int transactionCategorisationId { get; set; }
        public int rulePriority { get; set; }
        public int categoryLevelId { get; set; }
        public List<RuleClause> ruleClausea { get; set; }
    }
}
