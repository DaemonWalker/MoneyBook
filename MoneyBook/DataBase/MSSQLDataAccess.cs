using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataBase
{
    public class MSSQLDataAccess : DataAccess
    {
        public MSSQLDataAccess() : base(AppSettings.MSSQL) { }
        protected override void CreateConnection()
        {
            this.Connection = new SqlConnection(this.ConnectionString);
            this.Connection.Open();
        }

        protected override void CreateDataAdapter(string sql)
        {
            this.DataAdapter = new SqlDataAdapter(sql, this.ConnectionString);
        }

        protected override void CreateDataReader(string sql)
        {
            this.CreateConnection();
            var comm = this.Connection.CreateCommand();
            comm.CommandText = sql;
            comm.ExecuteReader();
        }
    }
}
