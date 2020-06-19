using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    class NewRuleRequest : BaseClass
    {
        public NewRuleRequest()
        {
            ruleClause = new List<RuleClause>();
        }

        public string username { get; set; }
        public string categoryId { get; set; }
        public int priority { get; set; }
        public string source { get; set; }
        public List<RuleClause> ruleClause { get; set; }
    }
}
