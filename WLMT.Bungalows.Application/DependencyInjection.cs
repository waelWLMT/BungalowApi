using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace WLMT.Bungalows.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Ajouter MediatR pour les Command et Query Handlers
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            // FluentValidation - Correction de l'erreur en ajoutant l'import nécessaire
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            // Ajouter d’autres services Application si nécessaire
            // ex: services.AddScoped<ICampaignValidator, CampaignValidator>();


            //         "DbConnection": "Data Source=.;Initial Catalog=WLMTBungalows_Dev;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true"


            return services;
        }
    }
}
