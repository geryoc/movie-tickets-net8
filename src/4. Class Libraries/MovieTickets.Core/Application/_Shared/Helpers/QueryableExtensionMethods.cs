using System.Linq.Expressions;
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

    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
    {
        return source.OrderBy(ToLambda<T>(propertyName));
    }

    public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
    {
        return source.OrderByDescending(ToLambda<T>(propertyName));
    }

    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool orderByDescending)
    {
        return orderByDescending ?
            source.OrderByDescending(ToLambda<T>(propertyName)) :
            source.OrderBy(ToLambda<T>(propertyName));
    }

    private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T));
        var property = Expression.Property(parameter, propertyName);
        var propAsObject = Expression.Convert(property, typeof(object));

        return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
    }
}
