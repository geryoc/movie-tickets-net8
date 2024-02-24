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

        await SeedMovies();

        _logger.LogInformation("Seeding Finished.");
    }

    private async Task SeedMovies()
    {
        await CreateMovieIfNotExists(
            "La Sociedad De La Nieve",
            145,
            ["Drama", "Aventura"],
            [("J.A.", "Bayona")],
            [
                ("Enzo", "Bayona"),
                ("Esteban", "Bigliardi")
            ]
        );

        await CreateMovieIfNotExists(
            "Muchachos La Película De La Gente",
            110,
            ["Documental"],
            [("Jesus", "Braceras")],
            []
        );

        await CreateMovieIfNotExists(
            "Venganza Silenciosa",
            105,
            ["Acción"],
            [("John", "Woo")],
            [
                ("Catalina", "Sandino"),
                ("Joel", "Kinnaman")
            ]
        );

        await CreateMovieIfNotExists(
            "Wonka",
            115,
            ["Infantil", "Aventura"],
            [("Paul", "King")],
            [
                ("Hugh", "Grant"),
                ("Timothée", "Colman"),
                ("Olivia", "Chalamet"),
            ]
        );

        await CreateMovieIfNotExists(
            "Digimon Adventures 02 El Comienzo",
            80,
            ["Animación", "Aventura"],
            [("Tomohisa", "Taguchi")],
            []
        );

        await CreateMovieIfNotExists(
            "Mavka Guardiana Del Bosque",
            80,
            ["Animación", "Infantil"],
            [("Oleh", "Malamuzh")],
            []
        );

        await CreateMovieIfNotExists(
            "Viernes Negro",
            105,
            ["Terror"],
            [("Eli", "Roth")],
            [
                ("Gina", "Gershon"),
                ("Rick", "Hoffman"),
            ]
        );

        await CreateMovieIfNotExists(
            "Napoleón",
            160,
            ["Acción", "Drama"],
            [("Ridley", "Scott")],
            [
                ("Joaquin", "Phoenix"),
                ("Vanessa", "Kirby"),
            ]
        );

        await CreateMovieIfNotExists(
            "El Duelo",
            80,
            ["Acción", "Comedia", "Thriller"],
            [("Augusto", "Tejada")],
            [
                ("Joaquín", "Furriel"),
                ("Maria Eugenia", "Suarez"),
            ]
        );
    }

    private async Task CreateMovieIfNotExists(string title, int duration, string[] genders, (string firstName, string lastName)[] directors, (string firstName, string lastName)[] actors)
    {
        var existingMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Title.Equals(title));

        if (existingMovie == null)
        {
            var movie = new Movie
            {
                Title = title,
                DurationInMinutes = duration,
            };

            foreach (var gender in genders)
            {
                var genderEntity = await _dbContext.Genders.FirstOrDefaultAsync(g => g.Name.Equals(gender));
                
                var movieGender = new MovieGender
                {
                    Movie = movie,
                    CreatedAt = DateTime.UtcNow,
                    GenderId = genderEntity.Id,
                };

                movie.MovieGenders.Add(movieGender);
            }

            foreach (var (firstName, lastName) in directors)
            {
                var person = await _dbContext.People.FirstOrDefaultAsync(p => p.FirstName.Equals(firstName) && p.LastName.Equals(lastName));

                var movieDirector = new MovieDirector
                {
                    Movie = movie,
                    CreatedAt = DateTime.UtcNow,
                    Person = person,
                };

                movieDirector.Person ??= new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                };

                movie.MovieDirectors.Add(movieDirector);
            }

            foreach (var (firstName, lastName) in actors)
            {
                var movieActor = new MovieActor
                {
                    Movie = movie,
                    CreatedAt = DateTime.UtcNow,
                    Person = await _dbContext.People.FirstOrDefaultAsync(p => p.FirstName.Equals(firstName) && p.LastName.Equals(lastName))
                };

                movieActor.Person ??= new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                };

                movie.MovieActors.Add(movieActor);
            }

            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
