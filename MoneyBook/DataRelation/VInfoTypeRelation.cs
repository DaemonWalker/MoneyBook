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
    public class VInfoTypeRelation : IDataRelation<VInfoEntity>
    {
        public VInfoEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var entity = new VInfoEntity();
            entity.TypeName = dataReader.GetString(0);
            entity.UseAmount = dataReader.GetDouble(1).FormatDouble();
            entity.TypeID = dataReader.GetString(2);
            return entity;
        }

        [NotImplemented]
        public VInfoEntity DataRowToEntity(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
