using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class NedbankLoginOld : BaseClass
    {
        public NedbankLoginOld()
        {
            profile = new NedbankOldProfile();
        }

        public readonly string bank = "Nedbank";
        public NedbankOldProfile profile { get; set; }
    }
}
