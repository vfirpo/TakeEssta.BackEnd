using System;
using System.Collections.Generic;
using System.Text;
using TakeEssta.Model;

namespace TakeEssta.Model
{
    public class Products
    {
        public int Id { get; set; }

        public int SucursalId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string ExtendedDescription { get; set; }

        public string ExternalCode { get; set; }

        public Rubro Rubro { get; set; }

        public SubRubro SubRubro { get; set; }

        public Unit Unit { get; set; }

        public string EAN { get; set; }

        public double Price { get; set; }

        public double Price2 { get; set; }

        public double Price3 { get; set; }

        public int StockAlert { get; set; }

        public double Stock { get; set; }

        public IList<Behaviours> Behaviours { get; set; }

    }
}
