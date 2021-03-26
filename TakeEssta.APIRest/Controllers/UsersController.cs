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
    public class UsersController: ControllerBase
    {
        [HttpGet("ValidateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EnableCors]
        public ActionResult<Response<Users>>ValidateUser([FromQuery] string user, [FromQuery] string password)
        {
            if (user == null) user = "";
            if (password == null) password = "";

            var hashpass = CommonFunctions.GetSHA256(password);
            Users users = UsersMapper.ValidateUser(user, hashpass);

            var rtn = new Response<Users>();

            rtn.Item = users;
            
            if (users != null)
            {
                rtn.Message = "Usuario recuperado con Exito";
                rtn.MessageType = MessageType.OK;
            }
            else
            {
                rtn.Message = "Usuario o Password no Validos";
                rtn.MessageType = MessageType.Alert;
            }
            return (Ok(rtn));
        }
    }
}
