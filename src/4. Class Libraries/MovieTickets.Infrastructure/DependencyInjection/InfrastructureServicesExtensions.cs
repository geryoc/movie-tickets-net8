using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieTickets.Core.Infrastructure.DataAccess;
using MovieTickets.Infrastructure.Data;
using MovieTickets.Infrastructure.Data.DevelopmentSeed;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseInMemoryDatabase("MovieTicketsDb"));
        }
        else
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        services.AddScoped<IDatabaseContext>(provider => provider.GetRequiredService<DatabaseContext>());

        services.AddScoped<DevelopmentDataSeeder>();

        return services;
    }
}
