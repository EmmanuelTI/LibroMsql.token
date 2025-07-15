using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using UTTT.Micro.Libro.Persistencia;
using UTTT.Micro.Libro.Applicaciones;
using MediatR;
using Uttt.Micro.Libro.Aplicacion;



namespace UTTT.Micro.Libro.Extenxiones
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

            services.AddDbContext<ContextoLibreria>(options =>
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
            services.AddAutoMapper(typeof(Consulta.Manejador));

            return services;
        }
    }
}
