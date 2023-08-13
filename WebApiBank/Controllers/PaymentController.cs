using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using WebApiBank.DesignPatterns.SingletonPattern;
using WebApiBank.Models.ContextClasses;
using WebApiBank.Models.Entities;
using WebApiBank.RequestModel;
using WebApiBank.ResponseModel;

namespace WebApiBank.Controllers
{
    public class PaymentController : ApiController
    {
        MyContext _db;
        public PaymentController()
        {
            _db = DBTool.DBInstance;
        }
        //Asagıdaki Action sadece development testi icindir API canlıya cıkacagı zaman kesinlikle acık bırakılmamalıdır.
        //[HttpGet]
        //public List<PaymentResponseModel> GetAll()
        //{
        //    return _db.Cards.Select(x => new PaymentResponseModel 
        //    {
        //       CardExpriyMonth = x.CardExpriyMonth,
        //       CardExpriyYear = x.CardExpriyYear,
        //       CardNumber = x.CardNumber,
        //       CardUserName = x.CardUserName,
        //       SecurtiyNumber = x.SecurtiyNumber,


        //    }).ToList();
        //}
        [HttpPost]
        public IHttpActionResult RecivePayment(PaymentRequestModel item) 
        {
            CardInfo ci = _db.Cards.FirstOrDefault(x => x.CardUserName == item.CardUserName && x.CardNumber == item.CardNumber && x.SecurtiyNumber == item.SecurityNumber && x.CardExpriyYear == item.CardExpiryYear && x.CardExpriyMonth == item.CardExpiryMonth);
            if (ci != null)
            {
                if (ci.CardExpriyYear  < DateTime.Now.Year)
                {
                    return BadRequest("Card Expired(Year)");
                }
                else if (ci.CardExpriyYear == DateTime.Now.Year)
                {
                    if (ci.CardExpriyMonth < DateTime.Now.Month)
                    {
                        return BadRequest("Card Expired(Month)");
                    }
                    if (ci.Balance >= item.ShoppingPrice)
                    {
                        SetBalance(item,ci);
                        return Ok();
                    }
                    else
                    {
                       return BadRequest("Balance Error");
                    }
                }
                else if(ci.Balance >= item.ShoppingPrice)
                {
                    SetBalance(item, ci);
                    return Ok();
                }
                return BadRequest("Balance exceeded");
            }
            return BadRequest("Card bulunamadı");
            
            
        }

        private void SetBalance(PaymentRequestModel item,CardInfo ci)
        {
            ci.Balance -= item.ShoppingPrice;
            _db.SaveChanges();
            
        }
    }
}

