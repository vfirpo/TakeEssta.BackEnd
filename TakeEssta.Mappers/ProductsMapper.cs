using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class ProductsMapper: BaseSQLMapper<Products>
    {
        public static IList<Products> GetBySucursal(int sucursal)
        {
            string SqlStatement = @"SELECT p.[Id]
                                          ,p.[Code]
                                          ,p.[Description]
                                          ,p.[ExtendedDescription]
                                          ,p.[ProductBrandId]
                                          ,p.[RubroId]
                                          ,p.[SubRubroId]
                                          ,p.[SucursalId]
                                          ,p.[UmId]
                                          ,p.[EAN]
                                          ,p.[ExternalCode]
                                          ,p.[Price]
                                          ,p.[Price2]
                                          ,p.[Price3]
                                          ,p.[StockAlert]
                                      	  ,s.[Stock]
	                                      ,r.*
	                                      ,sr.*
	                                      ,u.*
                                      FROM [dbo].[Products] p
                                      INNER JOIN rubro r ON p.RubroId = r.Id 
                                      INNER JOIN SubRubro sr ON p.SubRubroId = sr.Id
                                      INNER JOIN Units u ON  p.UmId = u.Id
                                      LEFT JOIN Stock s ON p.Id = s.ProductsId AND s.SucursalId = p.SucursalId OR s.SucursalId IS NULL
                                      WHERE ( p.SucursalId = @sucursalId OR p.SucursalId IS NULL ) AND p.IsActive = 1";


            IList<Products> prods;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    prods = connection.Query<Products, Rubro, SubRubro, Unit, Products>(SqlStatement,
                        (prod, rubro, subrubro, unit) =>
                        {
                            prod.Rubro = rubro;
                            prod.SubRubro = subrubro;
                            prod.Unit = unit;
                            return prod;
                        }, new { sucursalId = sucursal }, splitOn: "Id, Id, Id, Id").Distinct().ToList();

                    if (prods != null && prods.Count > 0)
                    {
                        var behaviours = BehavioursMapper.GetAllByProduct(connection);

                        foreach (var item in prods)
                        {
                            item.Behaviours = behaviours.Where(b => b.IdParent == item.Id).ToList();
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return prods;
        }
    }
}
