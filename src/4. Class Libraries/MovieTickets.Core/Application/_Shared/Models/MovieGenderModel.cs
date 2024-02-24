using MovieTickets.Core.Application._Shared.Mapping;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Models;

public class MovieGenderModel : IMapFrom<MovieGender>
{
    public long Id { get; set; }
    public long MovieId { get; set; }
    public short GenderId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public virtual GenderModel Gender { get; set; }
    public virtual MovieModel Movie { get; set; }
}
