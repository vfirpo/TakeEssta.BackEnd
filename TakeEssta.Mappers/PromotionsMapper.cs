using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class PromotionsMapper : BaseSQLMapper<Promotions>
    {
        public static IList<Promotions> GetPromotions(int sucursalId, bool onlyActive = true)
        {
            String SqlStatement = @"select p.*, s.* from promotions p inner join sucursales s on p.SucursalId = s.id";

            String SqlStatement2 = @"select pc.*, r.*, sr.*, sr2.*, sr3.*, sr4.* 
                                    from PromotionsConfig pc inner join Rubro r on pc.RubroId = r.Id
                                    inner join SubRubro sr on pc.SubRubroId = sr.Id
                                    inner join SubRubro sr2 on pc.SubRubroId = sr2.Id
                                    inner join SubRubro sr3 on pc.SubRubroId = sr3.Id
                                    inner join SubRubro sr4 on pc.SubRubroId = sr4.Id";

            IList < Promotions> promos;
            IList<PromotionsConfig> promosConfig;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {

                    promos = connection.Query<Promotions, Sucursal, Promotions>(SqlStatement,
                        (prom, sucursal) =>
                        {
                            prom.Sucursal = sucursal;
                            return prom;
                        }, null, splitOn: "Id").Distinct().ToList();

                    if (promos != null && promos.Count > 0)
                    {
                        var behaviours = BehavioursMapper.GetAllByPromotions(connection);

                        foreach (var item in promos)
                        {
                            item.Behaviours = behaviours.Where(b => b.IdParent == item.Id).ToList();
                        }

                        promosConfig = connection.Query<PromotionsConfig, Rubro, SubRubro, 
                            SubRubro, SubRubro, SubRubro, PromotionsConfig>(SqlStatement2,
                            (pc, rubro, subRubro, subRubro2, subRubro3, subRubro4) =>
                            {
                                pc.Rubro = rubro;
                                pc.SubRubro = subRubro;
                                pc.SubRubro2 = subRubro2;
                                pc.SubRubro3 = subRubro3;
                                pc.SubRubro4 = subRubro4;
                                return pc;
                            }, null, splitOn: "Id, Id, Id, Id, Id").Distinct().ToList();

                        var behaviours2 = BehavioursMapper.GetAllByPromotionsConfig(connection);

                        foreach (var item in promosConfig)
                        {
                            item.Behaviours = behaviours2.Where(b => b.IdParent == item.Id).ToList();
                        }
                    }
                }
                if (onlyActive)
                {
                    promos = promos.Where(p => (p.IsActive == true && p.ActiveTo < System.DateTime.Now)).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return promos;

        }

        public static object SavePromotions(Promotions promotions, bool isNew)
        {
            //Alta de promociones
            string SqlStatement = @"INSERT INTO [dbo].[Promotions]
                                   ([Code]
                                   ,[Description]
                                   ,[ExtendedDescription]
                                   ,[SucursalId]
                                   ,[Price]
                                   ,[Turno]
                                   ,[Image]
                                   ,[Color]
                                   ,[ActiveFrom]
                                   ,[ActiveTo]
                                   ,[ActiveDays]
                                   ,[IsActive]
                                   ,[UserId])
                             VALUES
                                   (@code
                                   ,@description
                                   ,@extendedDescription
                                   ,@sucursalId
                                   ,@price
                                   ,@turno
                                   ,@image
                                   ,@color
                                   ,@activeFrom
                                   ,@activeTo
                                   ,@activeDays
                                   ,@isActive
                                   ,@userId)

                        SELECT @@IDENTITY";

            Object xid;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    connection.Open();
                    using (var tr = connection.BeginTransaction())
                    {
                        try
                        {
                            xid = connection.ExecuteScalar(SqlStatement, new {
                               code = promotions.Code,
                               description = promotions.Description,
                               extendedDescription = promotions.ExtendedDescription,
                               sucursalId = promotions.Sucursal.Id,
                               price = promotions.Price,
                               turno = promotions.Turno,
                               image = promotions.Image,
                               color = promotions.Color,
                               activeFrom = promotions.ActiveFrom,
                               activeTo = promotions.ActiveTo,
                               activeDays = promotions.ActiveDays,
                               isActive = true,
                               userId = promotions.UserId}, tr);

                            promotions.Id = Convert.ToInt32(xid);

                            //Alta de Behaviours de Promociones
                            SqlStatement = @"INSERT INTO [dbo].[PromotionsBehaviours]
                                           ([PromotionsId]
                                           ,[BehavioursId])
                                     VALUES
                                           (@promotionsId
                                           ,@behavioursId)";

                            foreach (var item in promotions.Behaviours)
                            {
                                connection.Execute(SqlStatement, new { promotionsId = promotions.Id, behavioursId = item.Id }, tr);
                            }

                            //Alta de Configuraciones
                            SqlStatement = @"INSERT INTO [dbo].[PromotionsConfig]
                                           ([PromotionsId]
                                           ,[RubroId]
                                           ,[SubRubroId]
                                           ,[SubRubroId2]
                                           ,[SubRubroId3]
                                           ,[SubRubroId4]
                                           ,[MinUnits]
                                           ,[MaxUnits])
                                     VALUES
                                           (@promotionsId
                                           ,@rubroId
                                           ,@subRubroId
                                           ,@subRubroId2
                                           ,@subRubroId3
                                           ,@subRubroId4
                                           ,@minUnits
                                           ,@maxUnits)";
                            
                            var SqlStatement2 = @"INSERT INTO [dbo].[PromotionsConfigProducts]
                                               ([PromotionsId]
                                               ,[PromotionsConfigId]
                                               ,[ProductsId])
                                         VALUES
                                               (@promotionsId
                                               ,@promotionsConfigId
                                               ,@productsId)";

                            foreach (var item in promotions.PromotionsConfig)
                            {
                                connection.Execute(SqlStatement, new
                                {
                                    promotionsId = promotions.Id,
                                    rubroId = (item.Rubro == null)? 0: item.Rubro.Id,
                                    subrubroId = (item.SubRubro == null) ? 0 : item.SubRubro.Id,
                                    subRubroId2 = (item.SubRubro2 == null) ? 0 : item.SubRubro2.Id,
                                    subRubroId3 = (item.SubRubro3 == null) ? 0 : item.SubRubro3.Id,
                                    subRubroId4 = (item.SubRubro4 == null) ? 0 : item.SubRubro4.Id,
                                    minUnits = item.MinUnits,
                                    maxUnits = item.MaxUnits,
                                }, tr);

                                foreach (var item2 in item.FixedProducts)
                                {
                                    connection.Execute(SqlStatement2, new
                                    {
                                        promotionsId = promotions.Id,
                                        promotionsConfigId = item.Id,
                                        productsId = item2.Id,
                                    }, tr);
                                }
                            }
                            tr.Commit();

                        }
                        catch (Exception)
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return new Promotions();
        }

        private static IList<PromotionsConfig> GetConfig(int promotionsId)
        {
            return null;
        }

    }

}
