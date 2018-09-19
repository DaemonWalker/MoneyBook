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
    public class MonthTypeRelation : IDataRelation<VInfoEntity>
    {
        public VInfoEntity DataReaderToEntity(DbDataReader dataReader)
        {
            return new VInfoEntity()
            {
                TypeID = dataReader.GetString(0),
                TypeName = dataReader.GetString(1),
                UseAmount = dataReader.GetDouble(2).FormatDouble()
            };
        }
        [NotImplemented]
        public VInfoEntity DataRowToEntity(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
