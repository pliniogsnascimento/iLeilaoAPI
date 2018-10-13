using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ILeilao.Domain;
using ILeilao.Repository;

namespace ILeilao.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly IProdutoRepository _repository;

        public ProdutoBusiness(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto> IniciarLeilaoProduto(Produto produto)
        {
            return await _repository.AddAsync(produto);
        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return await _repository.FindAllAsync();
        }
    }
}
