using MoneyBook.DataBase;
using MoneyBook.DataRelation;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataBase
{
    public class DataConverter
    {
        public List<T> ConvertToList<T>(DataTable dataTable, IDataRelation<T> relation)
        {
            var list = new List<T>();
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(relation.DataRowToEntity(dr));
            }
            return list;
        }
        public List<T> ConvertToList<T>(DbDataReader dataReader, IDataRelation<T> relation)
        {
            var list = new List<T>();
            while (dataReader.Read())
            {
                list.Add(relation.DataReaderToEntity(dataReader));
            }
            return list;
        }

        public List<T> GetPage<T>(DbDataReader dataReader, IDataRelation<T> relation, int pageSize, int nowIndex)
        {
            for (int i = 0; i < pageSize * nowIndex && dataReader.Read(); i++) ;
            var list = new List<T>();
            for (int i = 0; i < pageSize && dataReader.Read(); i++)
            {
                list.Add(relation.DataReaderToEntity(dataReader));
            }
            return list;
        }
    }
}
