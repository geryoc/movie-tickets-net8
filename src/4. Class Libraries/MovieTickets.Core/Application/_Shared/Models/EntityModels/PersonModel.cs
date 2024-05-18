using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Models.EntityModels;

public class PersonModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}
