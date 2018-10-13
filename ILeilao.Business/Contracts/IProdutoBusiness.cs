using ILeilao.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILeilao.Business
{
    public interface IProdutoBusiness
    {
        Task<Produto> IniciarLeilaoProduto(Produto produto);
        Task<IEnumerable<Produto>> ListarProdutos();
    }
}
