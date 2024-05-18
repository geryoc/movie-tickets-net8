using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Models.EntityModels;

public class MovieGenderModel
{
    public long Id { get; set; }
    public long MovieId { get; set; }
    public short GenderId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public virtual GenderModel Gender { get; set; }
    public virtual MovieModel Movie { get; set; }
}
