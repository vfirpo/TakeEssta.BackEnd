using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public class PromotionsFixedProducts
    {
        public int Id { get; set; }

        public Products Product { get; set; }

        public int Units { get; set; }
    }
}
