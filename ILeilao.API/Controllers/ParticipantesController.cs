using ILeilao.Domain;
using ILeilao.Service;
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
        private readonly IParticipanteService _service;

        public ParticipantesController(IParticipanteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Participante participante)
        {
            try
            {
                await _service.RegistrarParticipante(participante);
                return Created("", participante);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
