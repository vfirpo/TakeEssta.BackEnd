using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class BaseSQLMapper<T>
    {
        internal static string SqlConn = @"Data Source=DESKTOP-BJ4OQ4G\SQLEXPRESS01;Initial Catalog=TakeEssta;Integrated Security=True";

        public static IList<T> GetSQL (string sqlstatement, object parameters)
        {
            IList<T> rtrnObj;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    rtrnObj = GetSQL(sqlstatement, parameters, connection);
                }
            }
            catch (Exception e)
            {
                throw e;
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
            catch (Exception e)
            {
                throw e;
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public static object GetValueSQL(string sqlstatement, object parameters, SqlConnection connection)
        {
            try
            {
                return connection.ExecuteScalar(sqlstatement, parameters);
            }
            catch (Exception e)
            {
                throw e;
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public static object ExecuteSQL(string sqlstatement, object parameters, SqlConnection connection)
        {
            try
            {
                return connection.Execute(sqlstatement, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
