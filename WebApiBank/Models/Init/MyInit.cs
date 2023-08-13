using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiBank.Models.ContextClasses;
using WebApiBank.Models.Entities;

namespace WebApiBank.Models.Init
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            CardInfo card = new CardInfo();

            card.CardUserName = "Dsa";
            card.CardNumber = "1111 1111 1111 1111 1111";
            card.SecurtiyNumber = "3169";
            card.CardExpriyMonth = 12;
            card.CardExpriyYear = 2085;
            card.Balance = 8000;
            card.Limit = 8000;
            context.Cards.Add(card);
            context.SaveChanges();

        }
    }
}