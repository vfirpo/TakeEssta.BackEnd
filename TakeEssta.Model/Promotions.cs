using System;
using System.Collections.Generic;

namespace TakeEssta.Model
{
    public class Promotions: BaseModel
    {
        public int Id { get; set; } 

        public string Code { get; set; }

        public string Description { get; set; }

        public string ExtendedDescription { get; set; }

        public Sucursal Sucursal { get; set; }

        public double Price { get; set; }

        public string Turno { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveTo { get; set; }

        public string ActiveDays { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

        public IList<PromotionsConfig> PromotionsConfig { get; set; }

        public IList<Behaviours> Behaviours { get; set; }
    }
}   
