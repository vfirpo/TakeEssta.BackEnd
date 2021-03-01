using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public class Cajas
    {
        public int Id { get; set; }

        public DateTime FechaApertura { get; set; }

        public DateTime FechaCierre { get; set; }

        public bool IsOpen { get; set; }

        public int SucursalId { get; set; }
        public string SucursalDescripcion { get; set; }

        public string Turno { get; set; }

        public int InicioDeCaja { get; set; }

        public int TotalTeoricoDeCaja { get; set; }

        public int UserId { get; set; }
        public string UserNombre { get; set; }


        public IList<IngresosCaja> Ingresos { get; set; }

        public IList<EgresosCaja> Egresos { get; set; }

        public IList<Comandas> Comandas { get; set; }

        public IList<Sueldos> Sueldos { get; set; }

        public IList<Gastos> Gastos { get; set; }
        


    }
}