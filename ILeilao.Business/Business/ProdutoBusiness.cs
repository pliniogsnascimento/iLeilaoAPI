using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILeilao.Domain;
using ILeilao.Repository;

namespace ILeilao.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IParticipanteRepository _participanteRepository;

        public ProdutoBusiness(IProdutoRepository produtoRepository, IParticipanteRepository participanteRepository)
        {
            _produtoRepository = produtoRepository;
            _participanteRepository = participanteRepository;
        }

        #region Public Methods

        public async Task<Produto> BuscarProdutoPorId(string id) => await _produtoRepository.FindAsync(c => c.Id == id);

        public async Task<Produto> IniciarLeilaoProduto(Produto produto) => await _produtoRepository.AddAsync(produto);

        public async Task<IEnumerable<Produto>> ListarProdutos() => await _produtoRepository.FindAllAsync();

        public async Task InserirLanceEmProduto(string id, Lance lance)
        {
            await ValidaParticipanteExistente(lance.Participante);

            var produto = await _produtoRepository.FindAsync(c => c.Id == id);

            lance.Participante = await _participanteRepository.FindAsync(c => c.Id == lance.Participante.Id);

            ValidaValorStatusLance(produto, lance);

            produto.Lances.Add(lance);

            if (produto.Participantes.Find(c => c.Id == lance.Participante.Id) == null)
                produto.Participantes.Add(lance.Participante);

            await _produtoRepository.EditAsync(c => c.Id == id, produto);
        }

        public async Task<Participante> EncerrarLeilao(string id, Produto produto)
        {
            var product = await _produtoRepository.FindAsync(c => c.Id == id);

            ValidaEncerramento(produto, product);

            product.Status = StatusProduto.Vendido;

            await _produtoRepository.EditAsync(c => product.Id == c.Id, product);

            return BuscarParticipanteComprador(product);
        }

        #endregion

        #region Private methods

        private void ValidaValorStatusLance(Produto produto, Lance lance)
        {
            if (produto.Status == StatusProduto.Vendido)
                throw new Exception("Leilão deste produto já foi encerrado!");

            if (produto.LanceMinimo >= lance.Valor)
                throw new Exception("Valor do lance inválido!");

            produto.LanceMinimo = lance.Valor;
        }

        private async Task ValidaParticipanteExistente(Participante participante)
        {
            var result = await _participanteRepository.FindAsync(c => c.Id == participante.Id);

            if (result == null)
                throw new Exception("Participante não registrado no iLeilão!");
        }

        private void ValidaEncerramento(Produto produto, Produto produtoBase)
        {
            if(produtoBase.Lances.Count <= 0)
                throw new Exception("Este leilão ainda não possui nenhum lance!");

            if (produtoBase.Status == StatusProduto.Vendido)
                throw new Exception("Este leilão já foi encerrado!");

            if (!produto.SenhaEncerramento.Equals(produtoBase.SenhaEncerramento))
                throw new Exception("A senha de encerramento está incorreta!");
        }

        private Participante BuscarParticipanteComprador(Produto produto)
        {
            var maiorLance = new Lance();

            foreach (var lance in produto.Lances)
            {
                if (maiorLance.Valor < lance.Valor)
                    maiorLance = lance;
            }

            return maiorLance.Participante;
        }

        #endregion

    }
}
