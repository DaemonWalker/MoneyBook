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
    public class MonthDetailRelation : IDataRelation<MoneyEntity>
    {
        public MoneyEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var money = new MoneyEntity();
            money.Date = dataReader.GetString(0).ConvertToDateTime();
            money.UseAmount = dataReader.GetDouble(1);
            money.UseWay = dataReader.GetString(2);
            return money;
        }

        [NotImplemented]
        public MoneyEntity DataRowToEntity(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
