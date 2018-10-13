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

        public async Task<Produto> IniciarLeilaoProduto(Produto produto)
        {
            return await _business.IniciarLeilaoProduto(produto);
        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return await _business.ListarProdutos();
        }
    }
}
