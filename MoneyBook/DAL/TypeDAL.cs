using MoneyBook.DataRelation;
using MoneyBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DAL
{
    public class TypeDAL : DALBase
    {
        public List<TypeEntity> QueryAll()
        {
            var sql = @"
SELECT
	T.TYPE_ID,
	T.TYPE_NAME,
	T.IO_FLAG 
FROM
	TYPE_INFO T";

            return this.DataAccess.QueryData(sql, new TypeQueryRelation());
        }

        public void Update(IEnumerable<TypeEntity> types)
        {
            this.DataAccess.ExecuteNonQueryWithTransaction((command) =>
            {
                var sql = @"
UPDATE TYPE_INFO 
SET TYPE_NAME = '{0}',
IO_FLAG = '{1}' 
WHERE
	TYPE_ID = '{2}'";
                foreach (var type in types)
                {
                    var temp = string.Format(sql, type.Name, type.IOFlag, type.ID);
                    command.CommandText = temp;
                    command.ExecuteNonQuery();
                }
            });
        }
        public void Delete(IEnumerable<string> ids)
        {
            this.DataAccess.ExecuteNonQueryWithTransaction((command) =>
            {
                var sql = @"
DELETE 
FROM
	TYPE_INFO 
WHERE
	TYPE_ID = '{0}'";
                foreach (var id in ids)
                {
                    var temp = string.Format(sql, id);
                    command.CommandText = temp;
                    command.ExecuteNonQuery();
                }
            });
        }
        public void Insert(IEnumerable<TypeEntity> entities)
        {
            this.DataAccess.ExecuteNonQueryWithTransaction((command) =>
            {
                var sql = @"
INSERT INTO TYPE_INFO ( TYPE_NAME, IO_FLAG )
VALUES
	(
	'{0}',
	'{1}')";
                foreach (var entity in entities)
                {
                    var temp = string.Format(sql, entity.Name, entity.IOFlag);
                    command.CommandText = temp;
                    command.ExecuteNonQuery();
                }
            });
        }
    }
}
