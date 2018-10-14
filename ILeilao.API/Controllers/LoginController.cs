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
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Conta conta)
        {
            try
            {
                return Ok(await _loginService.EfetuarLogin(conta));
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}
