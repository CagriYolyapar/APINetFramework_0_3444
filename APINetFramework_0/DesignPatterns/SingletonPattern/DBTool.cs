using APINetFramework_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINetFramework_0.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        public DBTool() {}

        static NorthwindEntities1 _dbInstance;

        public static NorthwindEntities1 DbInstance
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new NorthwindEntities1();
                return _dbInstance;
            }
        }
    }
}