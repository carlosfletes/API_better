using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InegiController : ControllerBase
    {

        private readonly IInegi _inegiBL;

        public InegiController(IInegi inegi)
        {
            _inegiBL = inegi;
        }

        // POST api/<Inegi>
        [HttpPost]
        public IActionResult Post([FromBody] List<InegiDTO> inegiList)
        {
            try
            {
                AnioDTO anio = _inegiBL.GetAnio(inegiList);

                return Ok($"El resultado es {anio.Anio} con {anio.PersonasVivas} personas vivas");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
