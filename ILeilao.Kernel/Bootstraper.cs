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
            services.AddTransient<ILoginBusiness, LoginBusiness>();
            services.AddTransient<ILeiloeiroBusiness, LeiloeiroBusiness>();

            // Services
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IParticipanteService, ParticipanteService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ILeiloeiroService, LeiloeiroService>();

            // Repository
            services.AddTransient<ILeilaoContext, ILeilaoContext>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IParticipanteRepository, ParticipanteRepository>();
            services.AddTransient<IContaRepository, ContaRepository>();
            services.AddTransient<ILeiloeiroRepository, LeiloeiroRepository>();

            // Validations
            services.AddTransient<IValidator<Conta>, ContaValidator>();
            services.AddTransient<IValidator<Participante>, ParticipanteValidator>();
            services.AddTransient<IValidator<Produto>, ProdutoValidator>();
            services.AddTransient<IValidator<Leiloeiro>, LeiloeiroValidator>();
        }
    }
}
