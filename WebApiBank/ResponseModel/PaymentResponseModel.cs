using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBank.ResponseModel
{
    public class PaymentResponseModel
    {
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public string SecurtiyNumber { get; set; }
        public int CardExpriyMonth { get; set; }
        public int CardExpriyYear { get; set; }
       
    }
}