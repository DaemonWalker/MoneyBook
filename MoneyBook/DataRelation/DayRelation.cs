﻿using MoneyBook.DataBase;
using MoneyBook.Entities;
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
            var date = Convert.ToInt32(dataReader.GetString(0));
            day.Date = new DateTime(date / 10000, date % 1000 / 100, date % 100);
            day.MoneyID = dataReader.GetString(1);
            day.IsSpend = dataReader.GetString(2) == "0" ? false : true;
            day.UseWay = dataReader.GetString(3);
            day.UseAmount = dataReader.GetDouble(4);

            return day;
        }

        public DayEntity DataRowToEntity(DataRow dr)
        {
            var day = new DayEntity();
            day.Date = Convert.ToDateTime(dr["DATE"].ToString());
            day.IsSpend = dr["SPEND_FLAG"].ToString() == "0" ? false : true;
            day.UseWay = dr["USE_WAY"].ToString();
            day.UseAmount = Convert.ToDouble(dr["USE_AOUNT"].ToString());
            day.MoneyID = dr["MONEYINFO_ID"].ToString();

            return day;
        }
    }
}