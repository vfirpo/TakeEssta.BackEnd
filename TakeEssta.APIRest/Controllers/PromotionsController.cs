using Microsoft.AspNetCore.Cors;
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
    [EnableCors]
    public class PromotionsController : ControllerBase
    {
        [HttpGet("GetPromotions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EnableCors]
        public ActionResult<Response<Promotions>> GetPromotions([FromQuery] int sucursalId, bool activeOnly = false)
        {
            try
            {
                var rtn = new Response<Promotions>();

                rtn.Items = PromotionsMapper.GetPromotions(sucursalId, activeOnly);
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

        [HttpPost("SavePromotions")]
        [EnableCors]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Response<bool>> SavePromotions([FromBody] Promotions promotions, bool isNew = true )
        {
            try
            {
                var rtn = new Response<bool>();

                rtn.Value = PromotionsMapper.SavePromotions(promotions, isNew);
                rtn.MessageType = MessageType.OK;
                rtn.Message = "Promocion Grabada con Exito";
                return Ok(rtn);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}