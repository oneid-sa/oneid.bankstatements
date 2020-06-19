using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionAPIDemo.models
{
    public class WebAPIResponse : BaseClass
    {
        public WebAPIResponse(int ResponseCodeValue, string ResponseDescriptionValue, string ResponseResultValue)
        {
            ResponseCode = ResponseCodeValue;
            ResponseDescription = ResponseDescriptionValue;
            ResponseResult = ResponseResultValue;
        }

        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }

        public string ResponseResult { get; set; }

    }
}
