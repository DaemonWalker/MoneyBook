using Microsoft.Data.Sqlite;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataBase
{
    public class MSSqliteDataAccess : DataAccess
    {
        protected override void CreateConnection()
        {
            this.Connection = new SqliteConnection(this.ConnectionString);
            SQLitePCL.Batteries.Init();
            this.Connection.Open();
        }

        [NotImplemented]
        protected override void CreateDataAdapter(string sql)
        {
            throw new NotImplementedException();
        }

        protected override void CreateDataReader(string sql)
        {
            this.CreateConnection();
            var comm = this.Connection.CreateCommand();
            comm.CommandText = sql;
            this.DataReader = comm.ExecuteReader();
        }
    }
}
