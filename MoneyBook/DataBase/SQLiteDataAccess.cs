using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataBase
{
    public class SQLiteDataAccess : DataAccess
    {
        public SQLiteDataAccess() { }
        protected override void CreateConnection()
        {
            var connStr = AppSettings.ConnectionString;
            this.Connection = new SQLiteConnection("connStr");
            this.Connection.Open();
        }
        
        protected override void CreateDataAdapter(string sql)
        {
            this.DataAdapter = new SQLiteDataAdapter(sql, this.ConnectionString);
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
