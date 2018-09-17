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
    public class VInfoRelation : IDataRelation<VInfoEntity>
    {
        public VInfoEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var entity = new VInfoEntity();
            entity.DayID = dataReader.GetString(0);
            entity.MoneyID = dataReader.GetString(1);
            entity.TypeID = dataReader.GetString(2);
            entity.UseAmount = dataReader.GetDouble(3).FormatDouble();
            entity.UseWay = dataReader.GetString(4);
            entity.Date = dataReader.GetString(5).ConvertToDateTime();
            entity.TypeName = dataReader.GetString(6);
            entity.IOFlag = dataReader.GetString(7).ConvertToIOEnum();

            return entity;
        }

        [NotImplemented]
        public VInfoEntity DataRowToEntity(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
