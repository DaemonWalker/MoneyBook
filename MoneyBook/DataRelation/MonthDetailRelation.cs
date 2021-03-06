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
    public class MonthDetailRelation : IDataRelation<VInfoEntity>
    {
        public VInfoEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var money = new VInfoEntity();
            money.Date = dataReader.GetString(0).ConvertToDateTime();
            money.UseAmount = dataReader.GetDouble(1).FormatDouble();
            money.UseWay = dataReader.GetString(2);
            return money;
        }

        [NotImplemented]
        public VInfoEntity DataRowToEntity(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
