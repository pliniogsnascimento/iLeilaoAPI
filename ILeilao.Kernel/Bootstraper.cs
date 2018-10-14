using FluentValidation;
using ILeilao.Business;
using ILeilao.Domain;
using ILeilao.Repository;
using ILeilao.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ILeilao.Kernel
{
    public class Bootstraper
    {
        public static void Configure(IServiceCollection services)
        {
            // Business
            services.AddTransient<IProdutoBusiness, ProdutoBusiness>();
            services.AddTransient<IParticipanteBusiness, ParticipanteBusiness>();

            // Services
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IParticipanteService, ParticipanteService>();

            // Repository
            services.AddTransient<ILeilaoContext, ILeilaoContext>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IParticipanteRepository, ParticipanteRepository>();
            services.AddTransient<IContaRepository, ContaRepository>();

            // Validations
            services.AddTransient<IValidator<Conta>, ContaValidator>();
            services.AddTransient<IValidator<Participante>, ParticipanteValidator>();
        }
    }
}
