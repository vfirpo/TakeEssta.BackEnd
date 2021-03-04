using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class TablePropertiesMapper : BaseSQLMapper<object>
    {
        public static IList<Rubro> GetAllRubros()
        {
            string SqlStatement = @"select r.* from Rubro r";

            IList<Rubro> rtrnObj;
            try
            {
                rtrnObj = GetSQL<Rubro>(SqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }

        public static IList<SubRubro> GetAllSubRubros()
        {
            string SqlStatement = @"select sr.* from SubRubro sr";

            IList<SubRubro> rtrnObj;
            try
            {
                rtrnObj = GetSQL<SubRubro>(SqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }

        public static IList<ProductBrand> GetAllProductBrand()
        {
            string SqlStatement = @"select pb.* from ProductBrand pb";

            IList<ProductBrand> rtrnObj;
            try
            {
                rtrnObj = GetSQL<ProductBrand>(SqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }

        public static IList<Unit> GetAllUnits()
        {
            string SqlStatement = @"select u.* from Units u";

            IList<Unit> rtrnObj;
            try
            {
                rtrnObj = GetSQL<Unit>(SqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }

    }
}
