namespace MovieTickets.Core.Application._Shared.Queries;

public class OrderByPagedQuery : PagedQuery
{
    public virtual OrderByDirection OrderByDirection { get; set; } = OrderByDirection.Ascending;
    public virtual string OrderBy { get; set; }
}

public enum OrderByDirection
{
    Ascending,
    Descending
}
