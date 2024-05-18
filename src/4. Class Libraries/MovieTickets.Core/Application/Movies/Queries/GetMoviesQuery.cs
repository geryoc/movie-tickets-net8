using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MovieTickets.Core.Application._Shared.Helpers;
using MovieTickets.Core.Application._Shared.Models.CustomModels;
using MovieTickets.Core.Application._Shared.Models.EntityModels;
using MovieTickets.Core.Application._Shared.Queries;
using MovieTickets.Core.Infrastructure.DataAccess;

namespace MovieTickets.Core.Application.Movies.Queries;

public class GetMoviesQuery : OrderByPagedQuery, IRequest<PageResult<MovieModel>>
{
    public int? Id { get; set; }
    public string Title { get; set; }

    public override string OrderBy { get; set; } = nameof(Title);
}

public class GetMoviesQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetMoviesQuery, PageResult<MovieModel>>
{
    private readonly IDatabaseContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PageResult<MovieModel>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var pageResult = await _context.Movies
            .Where(movie => request.Id == null || movie.Id == request.Id)
            .Where(movie => string.IsNullOrEmpty(request.Title) || movie.Title.Contains(request.Title))
            .OrderBy(request.OrderBy, request.OrderByDirection == OrderByDirection.Descending)
            .ProjectTo<MovieModel>(_mapper.ConfigurationProvider)
            .ToPageResultAsync(request);

        return pageResult;
    }
}
