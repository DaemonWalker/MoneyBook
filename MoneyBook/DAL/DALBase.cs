using MoneyBook.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DAL
{
    public class DALBase
    {
        protected DataAccess DataAccess { get; set; }
        protected DataConverter DataConverter { get; set; }
        public DALBase()
        {
            DataAccess = DataAccessFactory.GetDataAccess();
        }
    }
}
