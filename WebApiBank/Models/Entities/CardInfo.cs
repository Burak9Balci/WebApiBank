using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBank.Models.Entities
{
    public class CardInfo:BaseEntity
    {
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public string SecurtiyNumber { get; set; }
        public int CardExpriyMonth { get; set; }
        public int CardExpriyYear { get; set; }
        public decimal Balance { get; set; }
        public decimal Limit { get; set; }
    }
}