using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiBank.Models.Entities;
using WebApiBank.Models.Init;

namespace WebApiBank.Models.ContextClasses
{
    public class MyContext : DbContext 
    {
        public MyContext() : base("MyConnection")
        {
            Database.SetInitializer(new MyInit());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
        public DbSet<CardInfo> Cards { get; set; }
    }
}