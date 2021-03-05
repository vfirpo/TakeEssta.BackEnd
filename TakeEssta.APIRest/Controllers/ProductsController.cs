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

        [HttpGet("GetToList")]
        public ActionResult<PageItems<Products>> GetToList([FromQuery] int sucursalId, [FromQuery] int PageSize, [FromQuery] int CurrentPage, [FromQuery]  int rubroId = 0, [FromQuery] int subRubroId = 0)
        {
            var rtn = ProductsMapper.GetToList(sucursalId, PageSize, CurrentPage, rubroId, subRubroId);

            return (Ok(rtn));

        }
        
        [HttpPut("ActiveDesactive")]
        public ActionResult<Response<bool>> ActiveDesactive(int productId)
        {
            var rtn = new Response<bool>();

            rtn.Item = ProductsMapper.ActiveDesactive(productId);

            rtn.Message = "Producto Modificado con Exito";
            rtn.MessageType = MessageType.OK;
            
            return (Ok(rtn));

        }
    }
}
