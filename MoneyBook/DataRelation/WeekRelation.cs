﻿using MoneyBook.Entities;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataRelation
{
    public class WeekRelation : IDataRelation<WeekEntity>
    {
        public WeekEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var week = new WeekEntity();
            week.Week = dataReader.GetString(0);
            week.UseAmount = dataReader.GetDouble(1).FormatDouble();

            return week;
        }

        [NotImplemented]
        public WeekEntity DataRowToEntity(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
