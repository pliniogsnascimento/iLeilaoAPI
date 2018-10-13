using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _service.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            var produtoInserido = await _service.IniciarLeilaoProduto(produto);
            return Created("api/v1/produtos", produtoInserido);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
