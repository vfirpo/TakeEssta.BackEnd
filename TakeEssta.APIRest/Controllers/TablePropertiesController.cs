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
    public class TablePropertiesController: ControllerBase
    {
        [HttpGet("GetRubros")]
        public ActionResult<Response<Rubro>> GetRubos()
        {
            var rubros =  TablePropertiesMapper.GetAllRubros();

            var rtn = new Response<Rubro>
            {
                Items = rubros
            };

            if (rtn.Items != null)
            {
                rtn.Message = "Rubros recuperados con Exito";
                rtn.MessageType = MessageType.OK;
            }
            return (Ok(rtn));
        }

        [HttpGet("GetSubRubros")]
        public ActionResult<Response<SubRubro>> GetSubRubros()
        {
            var rubros = TablePropertiesMapper.GetAllSubRubros();

            var rtn = new Response<SubRubro>
            {
                Items = rubros
            };

            if (rtn.Items != null)
            {
                rtn.Message = "SubRubros recuperados con Exito";
                rtn.MessageType = MessageType.OK;
            }
            return (Ok(rtn));
        }

        [HttpGet("GetProductBrands")]
        public ActionResult<Response<ProductBrand>> GetProductBrands()
        {
            var rubros = TablePropertiesMapper.GetAllProductBrand();

            var rtn = new Response<ProductBrand>
            {
                Items = rubros
            };

            if (rtn.Items != null)
            {
                rtn.Message = "Products Brands recuperados con Exito";
                rtn.MessageType = MessageType.OK;
            }
            return (Ok(rtn));
        }

        [HttpGet("GetAllUnits")]
        public ActionResult<Response<Unit>> GetAllUnits()
        {
            var rubros = TablePropertiesMapper.GetAllUnits();

            var rtn = new Response<Unit>
            {
                Items = rubros
            };

            if (rtn.Items != null)
            {
                rtn.Message = "Units recuperados con Exito";
                rtn.MessageType = MessageType.OK;
            }
            return (Ok(rtn));
        }

    }
}
