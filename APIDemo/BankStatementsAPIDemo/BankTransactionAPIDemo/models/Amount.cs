﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class Amount : BaseClass
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }
}
