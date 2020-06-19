﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class UserListResponse : BaseClass
    {
        public List<User> users { get; set; }
        public string status { get; set; }
        public int status_code { get; set; }
    }
}
