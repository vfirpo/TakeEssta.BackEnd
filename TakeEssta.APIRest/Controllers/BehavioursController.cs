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
    public class BehavioursController: ControllerBase
    {
        [HttpGet("GetAll")]
        [EnableCors]
        public ActionResult<Response<Behaviours>> GetAll()
        {
            var behaviours = BehavioursMapper.GetAll();

            var rtn = new Response<Behaviours>
            {
                Items = behaviours
            };

            if (rtn.Items != null)
            {
                rtn.Message = "Behaviours recuperados con Exito";
                rtn.MessageType = MessageType.OK;
            }
            return (Ok(rtn));

        }
    }
}
