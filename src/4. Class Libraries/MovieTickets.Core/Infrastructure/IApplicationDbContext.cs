using Microsoft.EntityFrameworkCore;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Infrastructure;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
