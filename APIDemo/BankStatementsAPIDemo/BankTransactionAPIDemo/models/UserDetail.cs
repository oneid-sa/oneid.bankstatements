using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{

            
//"user": {
//"loginName": "hubtester1",
//"email": "testerHub02@mailinator.com",
//"password": "Hubino@123",
//"name": {
//"first": "FNAME",
//"last": "LNAME"
//},
//"address": {
//"address1": "200 Lincoln Ave",
//"state": "CA",
//"city": "Salinas",
//"zip": "93901",
//"country": "US"
//},
//"preferences": {
//"currency": "USD",
//"locale": "en_US"
//}
//}
//}


    public class UserDetail : BaseClass
    {
        public UserDetail()
        {
            user = new User();
        }

        public User user { get; set; }

    }
}
