using Microsoft.EntityFrameworkCore;
using MovieTickets.Core.Application._Shared.Models;
using MovieTickets.Core.Application._Shared.Queries;

namespace MovieTickets.Core.Application._Shared.Helpers;

public static class QueryableExtensionMethods
{
    public static async Task<PageResult<T>> ToPageResultAsync<T>(this IQueryable<T> source, PagedQuery pagedQuery) where T : class
    {
        var count = await source.CountAsync();
        var items = await source.AsNoTracking().Skip(pagedQuery.Skip).Take(pagedQuery.Take).ToListAsync();

        return new PageResult<T>(items, count, pagedQuery.PageNumber, pagedQuery.PageSize);
    }
}
