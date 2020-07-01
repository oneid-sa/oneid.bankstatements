using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionManagement.models
{
    public class Company
    {
        public int id { get; set; }
        public string companyName { get; set; }
        public string username { get; set; }
        public string password { get; set; } 
        public string address { get; set; }
        public int roleId { get; set; }
        
        public string email { get; set; }
        public string status { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}
