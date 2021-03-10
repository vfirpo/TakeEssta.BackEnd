using Microsoft.AspNetCore.Http;
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
    public class CajasController : ControllerBase
    {
        [HttpGet("GetCajasToList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PageItems<Cajas>> GetCajasToList([FromQuery] int Sucursal, [FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            try
            {
                var rtn = CajasMapper.GetCajas(Sucursal, PageSize, CurrentPage);
                if (rtn is null || rtn.Items is null || rtn.Items.Count == 0)
                {
                    return NotFound();
                }
                return Ok(rtn);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("GetLast")]
        public ActionResult<Response<Cajas>> GetLastCajas([FromQuery] int Sucursal)
        {
            try
            {
                var retValue = CajasMapper.GetLastCaja(Sucursal);

                return Ok(retValue);

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("GetOpen")]
        public ActionResult<Response<Cajas>> GetOpen([FromQuery] int Sucursal)
        {
            try
            {
                var retValue = CajasMapper.GetOpen(Sucursal);

                if (retValue.Items.Count == 0 )
                {
                    retValue.Message = "No hay ninguna Caja Abierta";
                    retValue.MessageType = MessageType.Info;
                }

                return Ok(retValue);

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("GetById")]
        public ActionResult<Response<Cajas>> GetById([FromQuery] int iDCaja)
        {
            try
            {
                var retValue = CajasMapper.GetCajasById(iDCaja);

                if (retValue.Items.Count == 0)
                {
                    retValue.Message = "La caja consultada no existe";
                    retValue.MessageType = MessageType.Info;
                }

                return Ok(retValue);

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("IsOpen")]
        public ActionResult<bool> IsOpen([FromQuery] int Sucursal)
        {
            try
            {
                return Ok(CajasMapper.IsOpen(Sucursal));
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("CrearCaja")]
        public ActionResult<Response<Cajas>> CrearCaja(Cajas caja)
        {
            try
            {
                return Ok(CajasMapper.CrearCaja(caja));
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
