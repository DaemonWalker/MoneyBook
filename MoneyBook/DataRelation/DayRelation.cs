using MoneyBook.DataBase;
using MoneyBook.Entities;
using MoneyBook.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataRelation
{
    public class DayRelation : IDataRelation<DayEntity>
    {
        public DayEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var day = new DayEntity();
            day.Date = dataReader.GetString(0).ConvertToDateTime();
            day.MoneyID = dataReader.GetString(1);
            day.IsSpend = Enum.Parse<IOEnum>(dataReader.GetString(2));
            day.UseWay = dataReader.GetString(3);
            day.UseAmount = dataReader.GetDouble(4);

            return day;
        }

        public DayEntity DataRowToEntity(DataRow dr)
        {
            var day = new DayEntity();
            day.Date = dr["DATE"].ToString().ConvertToDateTime();
            day.IsSpend = Enum.Parse<IOEnum>(dr["IO_FLAG"].ToString());
            day.UseWay = dr["USE_WAY"].ToString();
            day.UseAmount = Convert.ToDouble(dr["USE_AMOUNT"].ToString());
            day.MoneyID = dr["MONEYINFO_ID"].ToString();

            return day;
        }
    }
}
