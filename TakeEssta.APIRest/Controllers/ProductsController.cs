using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeEssta.Mappers;
using TakeEssta.Model;

namespace TakeEssta.APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        [HttpGet("GetBySucursal")]
        public ActionResult<Response<Products>>GetBySucursal([FromQuery] int sucursalId)
        {
            var prods = ProductsMapper.GetBySucursal(sucursalId);

            var rtn = new Response<Products>();

            rtn.Items = prods;

            if (rtn.Items != null)
            {
                rtn.Message = "Productos recuperado con Exito";
                rtn.MessageType = MessageType.OK;
            }
            return (Ok(rtn));

        }
    }
}
