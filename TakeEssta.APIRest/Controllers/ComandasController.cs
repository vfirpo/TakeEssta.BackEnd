using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeEssta.Model;

namespace TakeEssta.APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandasController : ControllerBase
    {
   
        private readonly ILogger<ComandasController> _logger;

        public ComandasController(ILogger<ComandasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<Comandas> ListaDeComandas()
        {
            var lista = new List<Comandas>();

            for (int i = 0; i < 50; i++)
            {
                lista.Add(new Comandas
                    { Id = i + 1, 
                    CajaId = i + 10, 
                    ComandaId = i + 100, FechaCierre = DateTime.Now, FechaCreacion = DateTime.Now,
                    Direccion="Direccion",
                    EmpleadoEnvio = new Employees { Id=5, Name="Pepe"},
                    Estado = new EstadoComanda { Id=3, Descripcion="Este es el Estado"},
                    HoraEntrega = DateTime.Now,
                    Observacion1 = "Observacion 1",
                    Observacion2 = "Observacion 2",
                    Observacion3 = "Observacion 3",
                    Nombre="Este es el nombre",
                    Importe = 10
                    
                });
            }

            return lista.ToArray();
        }

        [HttpGet("encrypt")]
        public string ListaDeComandas(string password)
        {
            return CommonFunctions.GetSHA256(password);
        }


    }
}
