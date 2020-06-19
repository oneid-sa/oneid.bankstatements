using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class NedbankLoginNew : BaseClass
    {
        public NedbankLoginNew()
        {
            profile = new NedbankNewProfile();
        }

        public readonly string bank = "Nedbank";
        public NedbankNewProfile profile { get; set; }
    }
}
