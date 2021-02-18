using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace eForm.Repository.Base
{
    public class BaseRepository
    {
        protected int? timeout;
        protected string _connectionString { get; set; }

        public IConfiguration Configuration { get; private set; }

        #region Constructor
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
            timeout = 60; //Default if config is empty
        }

        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = configuration.GetValue<string>("ConnectionString");
            timeout = configuration.GetValue<int>("DatabaseTimeOut");
        }
        #endregion

        protected IDbConnection Connection
        {
            get
            {
                IDbConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
        }


        protected DataTable ToDataTable(List<string> list, string columnName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(columnName);
            if (list != null && list.Count > 0)
            {
                foreach (string s in list)
                {
                    dt.Rows.Add(values: s);
                }
            }
            return dt;
        }

        protected DataTable ToDataTable<T>(List<T> list, string columnName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(columnName);
            if (list != null && list.Count > 0)
            {
                foreach (T s in list)
                {
                    dt.Rows.Add(values: s);
                }
            }
            return dt;
        }

        #region ExecuteTransaction
        /// <summary>
        /// ExecuteTransaction
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="executeQuery"></param>
        /// <returns></returns>
        public object ExecuteTransaction(IDbConnection connection, Func<IDbConnection, IDbTransaction, object> executeQuery)
        {
            object result = null;
            using (IDbConnection cn = connection)
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                IDbTransaction transaction = cn.BeginTransaction();

                try
                {
                    result = executeQuery(cn, transaction);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    cn.Close();
                }
            }

            return result;
        }
        #endregion

    }
}

