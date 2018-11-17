using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ILeilao.Domain;
using ILeilao.Service;
using Microsoft.AspNetCore.Mvc;

namespace ILeilao.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly IValidator<Produto> _validator;

        public ProdutosController(IValidator<Produto> validator, IProdutoService service)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarProdutos());
 

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id) => Ok(await _service.BuscarProdutoPorId(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
            => Created("api/v1/produtos", await _service.IniciarLeilaoProduto(produto));
        

        [HttpPost("{id}/lances")]
        public async Task<IActionResult> Post(string id, [FromBody] Lance lance)
        {
            try
            {
                await _service.AdicionarLance(id, lance);
                return Ok(lance);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] Produto produto)
        {
            try
            {
                var participante = await _service.EncerrarLeilao(id, produto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
