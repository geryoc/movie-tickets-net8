using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Models.EntityModels;

public class MovieDirectorModel
{
    public long Id { get; set; }
    public long MovieId { get; set; }
    public long PersonId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public virtual MovieModel Movie { get; set; }
    public virtual PersonModel Person { get; set; }
}
