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
										  ,pb.*
                                      FROM [dbo].[Products] p
                                      INNER JOIN rubro r ON p.RubroId = r.Id 
                                      INNER JOIN SubRubro sr ON p.SubRubroId = sr.Id
                                      INNER JOIN Units u ON  p.UmId = u.Id
                                      LEFT JOIN Stock s ON p.Id = s.ProductsId AND s.SucursalId = p.SucursalId OR s.SucursalId IS NULL
                                      LEFT JOIN ProductBrand pb ON p.ProductBrandId = pb.Id OR p.ProductBrandId IS NULL
                                      WHERE ( p.SucursalId = @sucursalId OR p.SucursalId IS NULL ) AND p.IsActive = 1";


            IList<Products> prods;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    prods = connection.Query<Products, Rubro, SubRubro, Unit, ProductBrand, Products>(SqlStatement,
                        (prod, rubro, subrubro, unit, productBrand) =>
                        {
                            prod.Rubro = rubro;
                            prod.SubRubro = subrubro;
                            prod.Unit = unit;
                            prod.ProductBrand = productBrand;
                            return prod;
                        }, new { sucursalId = sucursal }, splitOn: "Id, Id, Id, Id, Id").Distinct().ToList();

                    if (prods != null && prods.Count > 0)
                    {
                        var behaviours = BehavioursMapper.GetAllByProduct(connection);

                        foreach (var item in prods)
                        {
                            item.Behaviours = behaviours.Where(b => b.IdParent == item.Id).ToList();
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return prods;
        }

        public static PageItems<Products> GetToList(int sucursal, int PageSize, int CurrentPag, int RubroId = 0, int SubRubroId = 0)
        {
            string filterStatement = "";
            if (RubroId != 0 && SubRubroId != 0)
            {
                filterStatement = @"AND (p.RubroId = @rubroId AND p.SubRubroId = @subRubroId) ";
            }
            else if (RubroId != 0)
            {
                filterStatement = @"AND p.RubroId = @rubroId ";
            }

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
										  ,pb.*
                                      FROM [dbo].[Products] p
                                      INNER JOIN rubro r ON p.RubroId = r.Id 
                                      INNER JOIN SubRubro sr ON p.SubRubroId = sr.Id
                                      INNER JOIN Units u ON  p.UmId = u.Id
                                      LEFT JOIN Stock s ON p.Id = s.ProductsId AND s.SucursalId = p.SucursalId OR s.SucursalId IS NULL
                                      LEFT JOIN ProductBrand pb ON p.ProductBrandId = pb.Id OR p.ProductBrandId IS NULL
                                      WHERE ( p.SucursalId = @sucursalId OR p.SucursalId IS NULL ) AND p.IsActive = 1 " + filterStatement +
                                      "ORDER BY r.id, sr.id OFFSET (@currentPage - 1) * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY";

            string SqlStatement2 = @"SELECT COUNT(*) FROM Products p 
                                    WHERE ( p.SucursalId = @sucursalId OR p.SucursalId IS NULL ) AND p.IsActive = 1 " + filterStatement;
            

            IList<Products> prods;
            int recordCounts = 0;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {

                    prods = connection.Query<Products, Rubro, SubRubro, Unit, ProductBrand, Products>(SqlStatement,
                        (prod, rubro, subrubro, unit, productBrand) =>
                        {
                            prod.Rubro = rubro;
                            prod.SubRubro = subrubro;
                            prod.Unit = unit;
                            prod.ProductBrand = productBrand;
                            return prod;
                        }, new { sucursalId = sucursal, currentPage = CurrentPag, pageSize = PageSize, rubroId = RubroId, subRubroId = SubRubroId }, 
                        splitOn: "Id, Id, Id, Id, Id").Distinct().ToList();

                    if (prods != null && prods.Count > 0)
                    {
                        var behaviours = BehavioursMapper.GetAllByProduct(connection);

                        foreach (var item in prods)
                        {
                            item.Behaviours = behaviours.Where(b => b.IdParent == item.Id).ToList();
                        }
                        recordCounts = (int)GetValueSQL(SqlStatement2, new { sucursalId = sucursal, rubroId = RubroId, subRubroId = SubRubroId }, connection);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return new PageItems<Products>() { Items = prods, CurrentPage = CurrentPag, RecordCounts = recordCounts } ;
        }

        public static bool ActiveDesactive(int productsId)
        {
            string SqlStatement = @"UPDATE Products
                                    SET IsActive = (1 ^ IsActive)
                                    WHERE id = @productId";

            ExecuteSQL(SqlStatement, new { productId = productsId });

            return true;
        }

    }
}
