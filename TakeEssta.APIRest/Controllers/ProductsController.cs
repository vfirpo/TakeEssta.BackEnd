using Microsoft.AspNetCore.Cors;
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
        [EnableCors]
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
        [EnableCors]
        public ActionResult<PageItems<Products>> GetToList([FromQuery] int sucursalId, [FromQuery] int PageSize, [FromQuery] int CurrentPage, [FromQuery]  int rubroId = 0, [FromQuery] int subRubroId = 0)
        {
            var rtn = ProductsMapper.GetToList(sucursalId, PageSize, CurrentPage, rubroId, subRubroId);

            return (Ok(rtn));

        }
        
        [HttpGet("GetStockBySucursal")]
        [EnableCors]
        public ActionResult<IList<ProductsStock>> GetStockBySucursal([FromQuery] int sucursalId)
        {
            var rtn = ProductsMapper.GetStockBySucursal(sucursalId);

            return (Ok(rtn));

        }

        [HttpPut("ActiveDesactive")]
        [EnableCors]
        public ActionResult<Response<bool>> ActiveDesactive(int productId)
        {
            var rtn = new Response<bool>();

            rtn.Item = ProductsMapper.ActiveDesactive(productId);

            rtn.Message = "Producto Modificado con Exito";
            rtn.MessageType = MessageType.OK;
            
            return (Ok(rtn));

        }

        [HttpPost("InsertUpdate")]
        [EnableCors]
        public ActionResult<Response<Products>> InsertUpdate([FromBody] Products products)
        {
            var rtn = new Response<Products>();

            rtn.Item = ProductsMapper.InsertUpdate(products);

            rtn.Message = (products.Id != 0) ? "Producto Agregado con Exito" : "Producto Modificado con Exito";
            rtn.MessageType = MessageType.OK;

            return (Ok(rtn));

        }

    }
}
