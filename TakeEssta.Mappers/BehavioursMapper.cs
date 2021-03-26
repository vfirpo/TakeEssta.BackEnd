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

        public static IList<Behaviours> GetAllByPromotions(SqlConnection connection)
        {
            string SqlStatement = @"select b.*, PB.PromotionsId as [IdParent] from PromotionsBehaviours PB inner join behaviours b
                                ON PB.BehavioursId = b.Id ORDER BY PB.PromotionsId";

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

        public static IList<Behaviours> GetAllByPromotionsConfig(SqlConnection connection)
        {
            string SqlStatement = @"select b.*, PCB.PromotionsConfigId as [IdParent] from PromotionsConfigBehaviours PCB inner join behaviours b
                                ON PCB.BehavioursId = b.Id ORDER BY PCB.PromotionsId";

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

        public static IList<Behaviours> GetAll()
        {
            string SqlStatement = @"select b.* from behaviours b";

            IList<Behaviours> rtrnObj;
            try
            {
                rtrnObj = GetSQL(SqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }

        public static bool InsertUpdateForProductId(int idProduct, IList<Behaviours> behaviours, SqlConnection connection, SqlTransaction sqlTransaction)
        {
            string SqlStatement = @"DELETE FROM [dbo].[ProductsBehaviours] WHERE ProductsId = @idProduct";

            try
            {
                ExecuteSQL(SqlStatement, new { idProduct }, connection, sqlTransaction);

                SqlStatement = @"INSERT INTO [dbo].[ProductsBehaviours] 
                                       ([ProductsId]
                                       ,[BehavioursId])
                                 VALUES
                                       (@productsId
                                       ,@behavioursId)";

                foreach (var item in behaviours)
                {
                    ExecuteSQL(SqlStatement, new { productsId = idProduct, behavioursId = item.Id }, connection, sqlTransaction);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

    }
}