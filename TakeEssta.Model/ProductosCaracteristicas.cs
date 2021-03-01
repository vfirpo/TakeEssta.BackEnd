using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    class ProductosCaracteristicas
    {
        public int ProductsId { get; set; }

        public IList<Caracteristicas> Caracteristicas { get; set; }
    }
}
