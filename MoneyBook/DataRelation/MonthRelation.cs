using MoneyBook.Entities;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataRelation
{
    public class MonthRelation : IDataRelation<MonthEntity>
    {
        public MonthEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var month = new MonthEntity();
            month.UseType = dataReader.GetString(0);
            month.TotalMoney = dataReader.GetDouble(1);
            month.UseTypeID = dataReader.GetString(2);
            return month;
        }

        [NotImplemented]
        public MonthEntity DataRowToEntity(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
