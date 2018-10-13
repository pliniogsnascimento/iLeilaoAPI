using ILeilao.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILeilao.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParticipantesController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Participante> Post([FromBody] Participante participante)
        {
            return Created("", participante);
        }
    }
}
