using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataBase
{
    public class DataAccessFactory
    {
        public static DataAccess GetDataAccess()
        {
            return Activator.CreateInstance(Type.GetType(AppSettings.DataBase)) as DataAccess;
        }
    }
}
