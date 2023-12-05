namespace MovieTickets.Core.Application._Shared.Queries;

public class OrderByPagedQuery : PagedQuery
{
    public virtual OrderByDirection OrderByDirection {  get; set; } = OrderByDirection.Ascending;
    public virtual string OrderBy { get; set; }

    internal bool IsOrderByDescending => OrderByDirection == OrderByDirection.Descending;
}

public enum OrderByDirection
{
    Ascending,
    Descending
}
