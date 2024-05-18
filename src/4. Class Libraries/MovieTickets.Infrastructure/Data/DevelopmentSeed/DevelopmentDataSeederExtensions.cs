using Microsoft.Extensions.DependencyInjection;

namespace MovieTickets.Infrastructure.Data.DevelopmentSeed;

public static class DevelopmentDataSeederExtensions
{
    public static async Task SeedDevelopmentData(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DevelopmentDataSeeder>();
        await dataSeeder.SeedDevelopmentDataAsync();
    }
}
