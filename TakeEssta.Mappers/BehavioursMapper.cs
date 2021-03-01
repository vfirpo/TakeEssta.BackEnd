using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class BehavioursMapper: BaseSQLMapper<BehavioursUsers>
    {
        public static IList<BehavioursUsers> GetByUser(int userId, SqlConnection connection = null)
        {
            string SqlStatement = @"select bu.* from UsersBehavioursUsers UBU inner join behavioursUsers bu
                                ON UBU.BehavioursUsersId = BU.Id WHERE UBU.UsersId = @userId";

            IList<BehavioursUsers> rtrnObj;
            try
            {
                rtrnObj = GetSQL(SqlStatement, new { userId }, connection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }
    }
}