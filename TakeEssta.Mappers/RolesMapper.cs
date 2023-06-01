using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class RolesMapper: BaseSQLMapper<Roles>
    {
        public static IList<Roles> GetByUser(int userId, SqlConnection connection = null)
        {
            string SqlStatement = @"select R.* from UsersRoles UR inner join Roles R
                                ON UR.RolesId = R.Id WHERE UR.UsersId = @userId";

            IList<Roles> rtrnObj;
            try
            {
                rtrnObj = GetSQL(SqlStatement, new { userId }, connection);
            }
            catch (Exception)
            {
                throw;
            }
            return rtrnObj;
        }
    }
}