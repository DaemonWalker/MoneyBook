using MoneyBook.Utils;
using MySql.Data.MySqlClient;

namespace MoneyBook.DataBase
{
    public class MySqlDataAccess : DataAccess
    {
        public MySqlDataAccess() : base(AppSettings.MySql) { }
        protected override void CreateConnection()
        {
            this.Connection = new MySqlConnection(AppSettings.MySql);
            this.Connection.Open();
        }

        protected override void CreateDataAdapter(string sql)
        {
            this.DataAdapter = new MySqlDataAdapter(sql, this.ConnectionString);
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
