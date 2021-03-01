using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public class EmployessCaracteristicas
    {
        public int EmployeId { get; set; }

        public IList<Caracteristicas> Caracteristicas { get; set; }

    }
}
