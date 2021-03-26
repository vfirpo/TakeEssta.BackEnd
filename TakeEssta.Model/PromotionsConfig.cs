using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public class PromotionsConfig
    {
        public int Id { get; set; }

        public int PromotionsId { get; set; }

        public Rubro Rubro { get; set; }

        public SubRubro SubRubro { get; set; }

        public SubRubro SubRubro2 { get; set; }

        public SubRubro SubRubro3 { get; set; }

        public SubRubro SubRubro4 { get; set; }

        public IList<Products> FixedProducts { get; set; }

        public int MinUnits { get; set; }

        public int MaxUnits { get; set; }

        public IList<Behaviours> Behaviours { get; set; }

    }
}
