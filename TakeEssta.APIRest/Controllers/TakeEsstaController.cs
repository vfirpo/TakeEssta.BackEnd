using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeEssta.APIRest.Controllers
{
    public class TakeEsstaController<T>: ControllerBase
    {

        internal readonly ILogger<T> Logger;

        public TakeEsstaController(ILogger<T> logger)
        {
            this.Logger = logger;
        }
    }
}
