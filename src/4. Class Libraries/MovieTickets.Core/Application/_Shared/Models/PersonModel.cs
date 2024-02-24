using MovieTickets.Core.Application._Shared.Mapping;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Models;

public class PersonModel : IMapFrom<Person>
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}
