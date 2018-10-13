using ILeilao.Business;
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

            // Services
            services.AddTransient<IProdutoService, ProdutoService>();

            // Repository
            services.AddTransient<ILeilaoContext, ILeilaoContext>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
        }
    }
}
