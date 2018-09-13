using MoneyBook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataRelation
{
    public class TypeQueryRelation : IDataRelation<TypeEntity>
    {
        public TypeEntity DataReaderToEntity(DbDataReader dataReader)
        {
            var entity = new TypeEntity();
            entity.ID = dataReader.GetInt32(0);
            entity.Name = dataReader.GetString(1);
            entity.IOFlag = dataReader.GetString(2).ConvertToIOEnum();
            return entity;
        }

        public TypeEntity DataRowToEntity(DataRow dr)
        {
            var entity = new TypeEntity();
            entity.ID = Convert.ToInt32(dr["TYPE_ID"].ToString());
            entity.IOFlag = dr["TYPE_NAME"].ToString().ConvertToIOEnum();
            entity.Name = dr["IO_FLAG"].ToString();
            return entity;
        }
    }
}
