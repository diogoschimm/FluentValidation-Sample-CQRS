using FluentValidation.AspNetCore;
using FluentValidationSampleCore;
using FluentValidationSampleCore.Commands;
using FluentValidationSampleCore.Handlers.CommandHanlders;
using FluentValidationSampleCore.Handlers.QueryHandlers;
using FluentValidationSampleCore.Queries;
using FluentValidationSampleData;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace FluentValidationSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(Startup));

            services.AddMvc().AddFluentValidation(fv => {
                fv.ImplicitlyValidateRootCollectionElements = true; // Para collections 
                fv.RegisterValidatorsFromAssemblyContaining<AtualizarPessoaCommandValidator>();
            });

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaQuery, PessoaQuery>();
            
            services.AddScoped<IRequestHandler<CriarPessoaCommand, Pessoa>, PessoaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarPessoaCommand, Pessoa>, PessoaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirPessoaCommand, Pessoa>, PessoaCommandHandler>();

            services.AddScoped<IRequestHandler<ObterClientePorIdQuery, Pessoa>, PessoaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodosClientesQuery, IEnumerable<Pessoa>>, PessoaQueryHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
