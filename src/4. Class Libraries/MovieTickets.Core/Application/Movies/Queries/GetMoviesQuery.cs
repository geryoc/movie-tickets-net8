using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MovieTickets.Core.Application._Shared.Helpers;
using MovieTickets.Core.Application._Shared.Models;
using MovieTickets.Core.Application._Shared.Queries;
using MovieTickets.Core.Infrastructure;

namespace MovieTickets.Core.Application.Movies.Queries;

public class GetMoviesQuery : OrderByPagedQuery, IRequest<PageResult<MovieModel>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    
    public override string OrderBy { get; set; } = "Name";
}

public class GetMoviesQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetMoviesQuery, PageResult<MovieModel>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PageResult<MovieModel>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var pageResult = await _context.Movies
            .Where(movie => request.Id == null || movie.Id == request.Id)
            .Where(movie => string.IsNullOrEmpty(request.Name) || movie.Name.Contains(request.Name))
            .OrderBy(request.OrderBy, request.IsOrderByDescending)
            .ProjectTo<MovieModel>(_mapper.ConfigurationProvider)
            .ToPageResultAsync(request);

        return pageResult;
    }
}
