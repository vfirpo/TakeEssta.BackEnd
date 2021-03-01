using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public class Comandas
    {
        
        public int Id { get; set; }

        public int CajaId { get; set; }

        public int ComandaId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaCierre { get; set; }
        public DateTime FechaAsignacionMoto { get; set; }

        public Employees EmpleadoEnvio { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }

        public EstadoComanda Estado { get; set; }

        public int MinutosEstimadosDesde { get; set; }
        public int MinutosEstimadosHasta { get; set; }

        public DateTime HoraEntrega { get; set; }

        public TimeSpan TiempoDeVida {
            get {
                return DateTime.Now - FechaCreacion;
            }
        }

        public TimeSpan TiempoDeViaje {
            get
            {
                return DateTime.Now - FechaAsignacionMoto;
            }
        }

        public string PlataformaOrigen { get; set; }

        public string Observacion1 { get; set; }
        public string Observacion2 { get; set; }
        public string Observacion3 { get; set; }

        public IList<FormasDePago> FormasDePago { get; set; }

        public int Subtotal { get; set; }

        public int DescuentoPorcentaje { get; set; }
        public int DescuentoValor { get; set; }
        public int Adicional { get; set; }

        public string IdCupon { get; set; }
        public int Importe { get; set; }

    }
}