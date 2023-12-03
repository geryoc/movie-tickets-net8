using MovieTickets.Core.Application._Shared.Mapping;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Models
{
    public class MovieModel : IMapFrom<Movie>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
