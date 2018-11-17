using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ILeilao.Service
{
    public interface IProdutoService
    {
        Task<Produto> IniciarLeilaoProduto(Produto produto);
        Task<IEnumerable<Produto>> ListarProdutos();
        Task AdicionarLance(string id, Lance lance);
        Task<Produto> BuscarProdutoPorId(string id);
        Task<Participante> EncerrarLeilao(string id, Produto produto);
    }
}
