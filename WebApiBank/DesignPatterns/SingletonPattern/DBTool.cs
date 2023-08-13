using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using WebApiBank.Models.ContextClasses;

namespace WebApiBank.DesignPatterns.SingletonPattern
{
   
    public class DBTool
    {
        public DBTool()
        {

        }
        static MyContext _dbInstance;
        public static MyContext DBInstance
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new MyContext();
                return _dbInstance;
            }
        }

        
    }
}