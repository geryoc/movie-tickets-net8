using System.ComponentModel.DataAnnotations.Schema;
using MovieTickets.Core.Application._Shared.Mapping;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Models;

public class MovieModel : IMapFrom<Movie>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int? DurationInMinutes { get; set; }

    public virtual ICollection<MovieActorModel> MovieActors { get; set; } = new List<MovieActorModel>();
    public virtual ICollection<MovieDirectorModel> MovieDirectors { get; set; } = new List<MovieDirectorModel>();
    public virtual ICollection<MovieGenderModel> MovieGenders { get; set; } = new List<MovieGenderModel>();
}
