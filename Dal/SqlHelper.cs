using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Collections;

namespace Dal
{
    public class SqlHelper //: ISqlHelper
    {
        public string ConnectionString { get; set; }
        public SqlHelper(string conn)
        {
            ConnectionString = conn;
        }
        //   string ConnectionString = ConfigurationManager.ConnectionStrings["OneHRMS"].ConnectionString;
        public bool Insert<T>(T parameter) where T : class
        {
            using (IDbConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.Insert(parameter);
                sqlConnection.Close();
                return true;
            }
        }
        public int InsertWithReturnId<T>(T parameter) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var recordId = sqlConnection.Insert(parameter);
                sqlConnection.Close();
                return Convert.ToInt32(recordId);
            }
        }
        public bool Update<T>(T parameter) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.Update(parameter);
                sqlConnection.Close();
                return true;
            }
        }

        public bool Delete<T>(T predicate) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.Delete<T>(predicate);
                sqlConnection.Close();
                return true;
            }
        }
        public IEnumerable<T> QuerySP<T>(string storedProcedure, dynamic param = null,
            dynamic outParam = null, SqlTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null) where T : class
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            var output = connection.Query<T>(storedProcedure, param: (object)param,
            transaction: transaction, buffered: buffered, commandTimeout: commandTimeout,
            commandType: CommandType.StoredProcedure);
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return output;
        }
        public void ExecuteSp(string storedProcedure, dynamic param = null,
           SqlTransaction transaction = null,
           bool buffered = true, int? commandTimeout = null)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.Query(storedProcedure, param: (object)param,
            transaction: transaction, buffered: buffered, commandTimeout: commandTimeout,
            commandType: CommandType.StoredProcedure);
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }

        public IEnumerable ExecuteSpReturnMessage(string storedProcedure, dynamic param = null,
          SqlTransaction transaction = null,
          bool buffered = true, int? commandTimeout = null)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            var returnMessage = connection.Query(storedProcedure, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: commandTimeout, commandType: CommandType.StoredProcedure);
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return returnMessage;
        }

        public IList<T> GetAll<T>(string tableName) where T : class
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                List<T> lstResult = sqlConnection.Query<T>("select * from " + tableName).ToList();
                return lstResult.ToList();
            }
        }

        public bool DeleteSoft<T>(string table, string primaryColumn, int id) where T : class
        {
            var entityName = typeof(T).Name;
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string sql = string.Format("Update {0} set Deleted = 1 where {1} = {2}", table, primaryColumn, id);
                var affectedrows = sqlConnection.Execute(sql);
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                return affectedrows > 0;
            }
        }

        public bool DeleteSoft(string table, string primaryColumn, int id, int modifiedBy)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string sql = string.Format("Update {0} set Deleted = 1, ModifiedBy= {1}, ModifiedOn='{2}' where {3} = {4}", table, modifiedBy, DateTime.Now, primaryColumn, id);
                var affectedrows = sqlConnection.Execute(sql);
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                return affectedrows > 0;
            }
        }

        public SqlMapper.GridReader QueryMultiple(string storedProcedure, dynamic param)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            var output = connection.QueryMultiple(storedProcedure, (object)param);
            if (connection.State == ConnectionState.Open)
            {
                //connection.Close();
            }
            return output;
        }

        public IEnumerable<TFirst> MapChild<TFirst, TSecond, TKey>
            (
            SqlMapper.GridReader reader,
            List<TFirst> parent,
            List<TSecond> child,
            Func<TFirst, TKey> firstKey,
            Func<TSecond, TKey> secondKey,
            Action<TFirst, IEnumerable<TSecond>> addChildren
            )
            where TFirst : class
            where TSecond : class
        {
            var childMap = child
                .GroupBy(secondKey)
                .ToDictionary(g => g.Key, g => g.AsEnumerable());
            foreach (var item in parent)
            {
                IEnumerable<TSecond> children;
                if (childMap.TryGetValue(firstKey(item), out children))
                {
                    addChildren(item, children);
                }
            }
            return parent;
        }
        private int ConnectionTimeout { get; set; }


    }
}
