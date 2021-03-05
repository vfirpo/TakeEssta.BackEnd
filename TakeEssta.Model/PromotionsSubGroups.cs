using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public class PromotionsSubGroups
    {
        public int Id { get; set; }

        public Rubro Rubro { get; set; }

        public SubRubro SubRubro { get; set; }

        public int Units { get; set; }

    }
}
