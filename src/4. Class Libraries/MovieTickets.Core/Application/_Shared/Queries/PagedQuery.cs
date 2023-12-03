﻿namespace MovieTickets.Core.Application._Shared.Queries
{
    public class PagedQuery
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;

        public int Skip => PageNumber - 1;
        public int Take => PageSize;
    }
}
