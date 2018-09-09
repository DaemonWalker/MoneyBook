using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataBase
{
    public interface IDataRelation<T>
    {
        T DataRowToEntity(DataRow dr);
        T DataReaderToEntity(DbDataReader dataReader);
    }
}
