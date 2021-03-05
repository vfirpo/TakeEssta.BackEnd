using System;

namespace TakeEssta.Model
{
    public class Promotions
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Sucursal Sucursal { get; set; }

        public double Price { get; set; }

        public double Price1 { get; set; }

        public double Price2 { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveTo { get; set; }

        public string ActiveDays { get; set; }

        public bool IsActive { get; set; }
    }
}
