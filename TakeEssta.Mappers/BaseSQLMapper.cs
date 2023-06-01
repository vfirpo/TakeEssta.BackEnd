using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TakeEssta.Mappers
{
    public class BaseSQLMapper<T>
    {
        //internal static string SqlConn = @"Data Source=DESKTOP-ANGRGHL\SQLEXPRESS;Initial Catalog=TakeEssta;Integrated Security=True;";
        internal static string SqlConn = @"Data Source=.\SQLEXPRESS;Initial Catalog=TakeEssta;Persist Security Info=True;User ID=sa; Password=Pa$$word001";
        public static IList<N> GetSQL<N>(string sqlstatement, object parameters = null)
        {
            IList<N> rtrnObj;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    rtrnObj = GetSQL<N>(sqlstatement, parameters, connection);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rtrnObj;
        }

        public static IList<N> GetSQL<N>(string sqlstatement, object parameters, SqlConnection connection)
        {
            IList<N> rtrnObj;
            try
            {
                rtrnObj = connection.Query<N>(sqlstatement, parameters).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return rtrnObj;
        }

        public static IList<T> GetSQL (string sqlstatement, object parameters = null)
        {
            IList<T> rtrnObj;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    rtrnObj = GetSQL(sqlstatement, parameters, connection);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rtrnObj;
        }

        public static IList<T> GetSQL(string sqlstatement, object parameters, SqlConnection connection )
        {
            IList<T> rtrnObj;
            try
            {
                rtrnObj = connection.Query<T>(sqlstatement, parameters).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return rtrnObj;
        }

        public static object GetValueSQL(string sqlstatement, object parameters)
        {
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    return GetValueSQL(sqlstatement, parameters, connection);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object GetValueSQL(string sqlstatement, object parameters, SqlConnection connection)
        {
            try
            {
                return connection.ExecuteScalar(sqlstatement, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object ExecuteSQL(string sqlstatement, object parameters)
        {
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    return ExecuteSQL(sqlstatement, parameters, connection);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object ExecuteSQL(string sqlstatement, object parameters, SqlConnection connection)
        {
            try
            {
                return connection.Execute(sqlstatement, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object ExecuteSQL(string sqlstatement, object parameters, SqlConnection connection, SqlTransaction sqlTransaction)
        {
            try
            {
                return connection.Execute(sqlstatement, parameters, sqlTransaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
