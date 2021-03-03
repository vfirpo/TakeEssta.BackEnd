using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class BehavioursMapper: BaseSQLMapper<Behaviours>
    {
        public static IList<Behaviours> GetByUser(int userId, SqlConnection connection = null)
        {
            string SqlStatement = @"select b.* from UsersBehaviours UB inner join behaviours b
                                ON UB.BehavioursId = b.Id WHERE UB.UsersId = @userId";

            IList<Behaviours> rtrnObj;
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

        public static IList<Behaviours> GetByProduct(int productsId, SqlConnection connection)
        {
            string SqlStatement = @"select b.* from ProductsBehaviours PB inner join behaviours b
                                ON PB.BehavioursId = b.Id WHERE PB.ProductsId = @productsId";

            IList<Behaviours> rtrnObj;
            try
            {
                rtrnObj = GetSQL(SqlStatement, new { productsId }, connection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }

        public static IList<Behaviours> GetAllByProduct(SqlConnection connection)
        {
            string SqlStatement = @"select b.*, PB.ProductsId as [IdParent] from ProductsBehaviours PB inner join behaviours b
                                ON PB.BehavioursId = b.Id ORDER BY PB.ProductsId";

            IList<Behaviours> rtrnObj;
            try
            {
                rtrnObj = GetSQL(SqlStatement, connection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }
    }
}