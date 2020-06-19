using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class RuleClause
    {
    //        The create transaction categorization rule service is used to create a categorization rule for both system-defined category as well as user-defined category.
    //ruleParam is a JSON input that contains the following fields:
    //     categoryId - This field is mandatory and numeric
    //     priority - This field is optional and numeric.Priority decides the order in which the rule gets applied on transactions.
    //     ruleClause - This field is mandatory and should contain at least one rule
    //     field - The value can be description or amount
    //       If the field value is description then,
    //         1. operation - value can be stringEquals or stringContains
    //         2. value - value should be min of 3 and max of 50 characters
    //       If the field value is amount then,
    //         1. operation - value can be numberEquals, numberLessThan, numberLessThanEquals, numberGreaterThan or numberGreaterThanEquals
    //         2. value - min value 0 and a max value of 99999999999.99 is allowed
    //The HTTP response code is 201 (Created Successfully).

        public string field { get; set; }
        public string operation { get; set; }
        public string value { get; set; }
    }
}
