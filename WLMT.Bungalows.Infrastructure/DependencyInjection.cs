using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WLMT.Bungalows.Domain.Entities;
using WLMT.Bungalows.Domain.Interfaces;
using WLMT.Bungalows.Infrastructure.Persistence;
using WLMT.Bungalows.Infrastructure.Repositories;


namespace WLMT.Bungalows.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //options.UseInMemoryDatabase("TestDb")); // Pour test rapide
            //services.AddScoped<ICampaignRepository, CampaignRepository>();
            //return services;

            // Ajouter DbContext
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            // Ajouter repositories
           // services.Ad*/dScoped<ICampaignReadRepository, CampaignReadRepository>();

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<ICampaignReadRepository, CampaignReadRepository>();



            // Ajouter autres services externes si besoin
            // ex: services.AddScoped<IEmailSender, EmailSender>();


            // Ajouter les services d'infrastructure ici
            // ex: services.AddScoped<IEmailService, EmailService>();




            return services;
        }
    }
}
