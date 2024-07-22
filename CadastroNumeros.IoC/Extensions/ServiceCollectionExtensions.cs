using CadastroNumeros.Application.Services;
using CadastroNumeros.Domain.Interfaces.Repository;
using CadastroNumeros.Domain.Interfaces.Service;
using CadastroNumeros.Implementations;
using CadastroNumeros.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroNumeros.IoC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IContatoRepository, ContatoRepository>();
            service.AddScoped<IContatoService, ContatoService>();
            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return service;
        }
    }
}
