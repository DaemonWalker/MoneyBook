using MoneyBook.DataRelation;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataBase
{
    public abstract class DataAccess : IDisposable
    {
        protected DbConnection Connection { get; set; }
        //public DbTransaction DbTransaction { get; set; }
        //public DbCommand DbCommand { get; set; }
        protected DbDataAdapter DataAdapter { get; set; }
        protected DbDataReader DataReader { get; set; }
        protected readonly string ConnectionString;
        protected DataAccess(string connStr)
        {
            this.ConnectionString = connStr;
        }

        public void Dispose()
        {
            this.Connection?.Close();
        }
        protected abstract void CreateConnection();
        protected abstract void CreateDataAdapter(string sql);
        protected abstract void CreateDataReader(string sql);

        public int ExecuteNonQuery(string sql)
        {
            this.CreateConnection();
            var command = this.Connection.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteNonQuery();
        }
        public void ExecuteNonQueryWithTransaction(Action<DbCommand> action)
        {
            this.CreateConnection();
            var dbCommand = this.Connection.CreateCommand();
            var dbTransaction = this.Connection.BeginTransaction();
            dbCommand.Transaction = dbTransaction;
            try
            {
                action.Invoke(dbCommand);
                dbTransaction.Commit();
            }
            catch (Exception e)
            {
                dbTransaction.Rollback();
                throw e;
            }
        }
        public List<T> QueryData<T>(string sql, IDataRelation<T> relation)
        {
            var list = new List<T>();
            if (NotImplementedAttribute.IsMethodNotImplemented(this.GetType().Name, "CreateDataAdapter") == false &&
                NotImplementedAttribute.IsMethodNotImplemented(relation.GetType().Name, "DataRowToEntity") == false)
            {
                this.CreateDataAdapter(sql);
                var dt = new DataTable();
                this.DataAdapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(relation.DataRowToEntity(dr));
                }
                return list;
            }

            if (NotImplementedAttribute.IsMethodNotImplemented(this.GetType().Name, "CreateDataReader") == false &&
                NotImplementedAttribute.IsMethodNotImplemented(relation.GetType().Name, "DataReaderToEntity") == false)
            {
                this.CreateDataReader(sql);
                while (this.DataReader.Read())
                {
                    list.Add(relation.DataReaderToEntity(this.DataReader));
                }
                return list;
            }

            throw new NotImplementedException(this.GetType().ToString());
        }
        public DbDataReader GetDataReader(string sql)
        {
            this.CreateDataReader(sql);
            return this.DataReader;
        }
    }
}
