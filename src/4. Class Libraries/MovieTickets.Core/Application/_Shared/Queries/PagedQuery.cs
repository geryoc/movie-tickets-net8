namespace MovieTickets.Core.Application._Shared.Queries;

public class PagedQuery
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

    internal int Skip => PageNumber - 1;
    internal int Take => PageSize;
}
