namespace MovieTickets.Core.Domain.Entities;

public partial class Movie
{
    public string PresentationTitle => $"Test Entity Logic: {Title}";
}
