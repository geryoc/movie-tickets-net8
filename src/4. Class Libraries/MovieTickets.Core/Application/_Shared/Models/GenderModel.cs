using MovieTickets.Core.Application._Shared.Mapping;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Models;

public class GenderModel : IMapFrom<Gender>
{
    public short Id { get; set; }
    public string Name { get; set; }
}
