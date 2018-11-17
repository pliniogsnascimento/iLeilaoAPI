//using ILeilao.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ILeilao.Business;
using ILeilao.Domain;

namespace ILeilao.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoBusiness _business;

        public ProdutoService(IProdutoBusiness business)
        {
            _business = business;
        }

        public async Task AdicionarLance(string id, Lance lance) => await _business.InserirLanceEmProduto(id, lance);
        
        public async Task<Produto> BuscarProdutoPorId(string id) => await _business.BuscarProdutoPorId(id);
        
        public async Task<Produto> IniciarLeilaoProduto(Produto produto) => await _business.IniciarLeilaoProduto(produto);
        
        public async Task<IEnumerable<Produto>> ListarProdutos() => await _business.ListarProdutos();

        public async Task<Participante> EncerrarLeilao(string id, Produto produto) => await _business.EncerrarLeilao(id, produto);
    }
}
