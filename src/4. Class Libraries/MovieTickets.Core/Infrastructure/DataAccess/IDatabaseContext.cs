using Microsoft.EntityFrameworkCore;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Infrastructure.DataAccess;

public interface IDatabaseContext
{
    DbSet<Movie> Movies { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
