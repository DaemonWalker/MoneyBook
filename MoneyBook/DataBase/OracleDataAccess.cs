using MoneyBook.Utils;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataBase
{
    public class OracleDataAccess : DataAccess
    {
        public OracleDataAccess() : base(AppSettings.Oracle) { }
        protected override void CreateConnection()
        {
            this.Connection = new OracleConnection();
            this.Connection.Open();
        }

        protected override void CreateDataAdapter(string sql)
        {
            this.DataAdapter = new OracleDataAdapter(sql, this.ConnectionString);
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
