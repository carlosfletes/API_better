using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class agruparController : Controller
    {
        private List<Distribuidor> _distribuidorList;

        private readonly IAgrupar _agruparBL;
        public agruparController(IAgrupar agruparBL)
        {
            _distribuidorList = new List<Distribuidor>();
            _agruparBL = agruparBL;
        }

        // POST: api/add
        [HttpPost]
        public ActionResult Post([FromBody] List<RelacionDTO> data)
        {
            try
            {
                _distribuidorList =  _agruparBL.agregarAsociacion(data);
                
                borrarCookie("data");

                var json = System.Text.Json.JsonSerializer.Serialize(_distribuidorList);

                crearCookie("data", json);

                return Ok(new { message = "Se procesó la información con éxito" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            string data = obtenerCookie("data");
            return Ok( _agruparBL.GetDistribuidors(data));
        }

        private void borrarCookie(string key)
        {
            Response.Cookies.Delete(key);
        }

        private void crearCookie(string key, string value)
        {
            Response.Cookies.Append(key, value);
        }

        private string obtenerCookie(string key)
        {
            var cookie = ControllerContext.HttpContext.Request.Cookies[key];
            if (cookie != null)
            {
                return cookie.ToString();
            }
            else
            {
                return "";
            }
        }

    }        
}
