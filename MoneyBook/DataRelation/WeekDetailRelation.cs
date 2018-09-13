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
    public class WeekDetailRelation : IDataRelation<WeekEntity>
    {
        public WeekEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var week = new WeekEntity();
            week.Date = dataReader.GetString(0).ConvertToDateTime();
            week.IOFlag = dataReader.GetString(1).ConvertToIOEnum();
            week.UseWay = dataReader.GetString(2);
            week.UseType = dataReader.GetString(3);
            week.Week = dataReader.GetString(4);
            week.UseAmount = dataReader.GetDouble(5).FormatDouble();
            return week;
        }

        [NotImplemented]
        public WeekEntity DataRowToEntity(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
