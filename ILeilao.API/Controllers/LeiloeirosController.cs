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
    public class LeiloeirosController : ControllerBase
    {
        private readonly ILeiloeiroService _service;

        public LeiloeirosController(ILeiloeiroService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Leiloeiro leiloeiro)
        {
            try
            {
                await _service.RegistrarLeiloeiro(leiloeiro);
                return Created("", leiloeiro);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
