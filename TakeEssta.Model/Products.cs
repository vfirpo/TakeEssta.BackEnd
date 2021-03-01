using System;
using System.Collections.Generic;
using System.Text;
using TakeEssta.Model;

namespace TakeEssta.Model
{
    public class Products
    {
        public int Id { get; set; }

        public Sucursal Sucursal { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }

        public string ExtendedDescription { get; set; }

        public string ExternalCode { get; set; }

        public Rubro Rubro { get; set; }

        public SubRubro SubRubro { get; set; }

        public Unit Unit { get; set; }

        public string EAN { get; set; }

        public int Precio { get; set; }

        public int Precio2 { get; set; }

        public int Precio3 { get; set; }

        public IList<EmployessCaracteristicas> Caracteristicas { get; set; }



    }
}
