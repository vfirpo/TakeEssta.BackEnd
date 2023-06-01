using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeEssta.BL;
using TakeEssta.Mappers;
using TakeEssta.Model;

namespace TakeEssta.APIRest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController: ControllerBase
    {
        [HttpGet("ValidateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EnableCors]
        [AllowAnonymous]
        public ActionResult<Response<Users>>ValidateUser([FromQuery] string user, [FromQuery] string password)
        {
            return Ok(UsersBL.ValidateUser(user, password));
        }
    }
}
