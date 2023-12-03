namespace MovieTickets.Core.Domain.Entities;

public partial class Movie
{
    public string PresentationName => $"Test Entity Logic: {Name}";
}
