using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieTickets.Core.Domain.Entities;
using MovieTickets.Infrastructure.Data.Scripts;

namespace MovieTickets.Infrastructure.Data;

public class DataSeeder(ILogger<DataSeeder> logger, ApplicationDbContext dbContext) // Primary Constructor feature c# 12
{
    private readonly ILogger<DataSeeder> _logger = logger;
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task SeedDataAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        _logger.LogInformation("Seeding Database...");

        // Examples seed custom logic
        await SeedCustomMoviesUsingScriptAsync();
        await SeedCustomMoviesUsingCodeAsync();

        _logger.LogInformation("Seeding Finished.");
    }

    private async Task SeedCustomMoviesUsingScriptAsync()
    {
        // Example seed data using in code scripts 
        await _dbContext.Database.ExecuteSqlRawAsync(DataScripts.SeedCustomMovies);
    }

    private async Task SeedCustomMoviesUsingCodeAsync()
    {
        // Example seed custom logic
        var customMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Name.Equals("Custom Test Movie 2"));

        if (customMovie == null)
        {
            customMovie = new Movie
            {
                Name = "Custom Test Movie 2"
            };

            _dbContext.Movies.Add(customMovie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
