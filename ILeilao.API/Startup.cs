using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using ILeilao.Business;
using ILeilao.CrossCutting;
using ILeilao.Domain;
using ILeilao.Kernel;
using ILeilao.Repository;
using ILeilao.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ILeilao.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                //.AddCustomSwagger()
                //.AddApplicationDI()
                .AddFluentValidation()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            ConfigureSwagger(services);

            services.Configure<DatabaseOptions>(Configuration.GetSection("Database"));

            services.AddCors(o => o.AddPolicy("DefaultPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("DefaultPolicy"));
            });

            services.AddLogging((logging) =>
            {
                logging.AddConsole();
                logging.AddEventSourceLogger();
            });

            Bootstraper.Configure(services);

            MongoDbMapper.MapClasses();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            ConfigureSwagger(app);

            app.UseCors("DefaultPolicy");
            app.UseMvc();
        }

        

        private void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ILeilao API");
                c.RoutePrefix = "swagger";
            });
        }

        public void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ILeilao API",
                    Description = "Serviço do ILeilao para criação e gerenciamento de leilões",
                    TermsOfService = "ILeilao Ltda.",
                    Contact = new Contact
                    {
                        Name = "Plinio Nascimento",
                        Email = "plinio.gsnascimento@gmail.com",
                        Url = "https://github.com/pliniogsnascimento"
                    }
                });
            });

        }

    }

    //static class CustomExtensions
    //{
    //    public static IServiceCollection AddApplicationDI(this IServiceCollection services)
    //    {
    //        // Business
    //        services.AddTransient<IProdutoBusiness, ProdutoBusiness>();
    //        services.AddTransient<IParticipanteBusiness, ParticipanteBusiness>();
    //        services.AddTransient<ILoginBusiness, LoginBusiness>();
    //        services.AddTransient<ILeiloeiroBusiness, LeiloeiroBusiness>();

    //        // Services
    //        services.AddTransient<IProdutoService, ProdutoService>();
    //        services.AddTransient<IParticipanteService, ParticipanteService>();
    //        services.AddTransient<ILoginService, LoginService>();
    //        services.AddTransient<ILeiloeiroService, LeiloeiroService>();

    //        // Repository
    //        services.AddTransient<ILeilaoContext, ILeilaoContext>();
    //        services.AddTransient<IProdutoRepository, ProdutoRepository>();
    //        services.AddTransient<IParticipanteRepository, ParticipanteRepository>();
    //        services.AddTransient<IContaRepository, ContaRepository>();
    //        services.AddTransient<ILeiloeiroRepository, LeiloeiroRepository>();

    //        // Validations
    //        services.AddTransient<IValidator<Conta>, ContaValidator>();
    //        services.AddTransient<IValidator<Participante>, ParticipanteValidator>();
    //        services.AddTransient<IValidator<Produto>, ProdutoValidator>();
    //        services.AddTransient<IValidator<Leiloeiro>, LeiloeiroValidator>();

    //        return services;
    //    }

    //    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    //    {
    //        services.AddSwaggerGen(c =>
    //        {
    //            c.SwaggerDoc("v1", new Info
    //            {
    //                Version = "v1",
    //                Title = "ILeilao API",
    //                Description = "Serviço do ILeilao para criação e gerenciamento de leilões",
    //                TermsOfService = "ILeilao Ltda.",
    //                Contact = new Contact
    //                {
    //                    Name = "Plinio Nascimento",
    //                    Email = "plinio.gsnascimento@gmail.com",
    //                    Url = "https://github.com/pliniogsnascimento"
    //                }
    //            });
    //        });

    //        return services;
    //    }
    //}
}
