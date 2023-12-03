using MediatR;
using MovieTickets.Core.Application._Shared.Helpers;
using MovieTickets.Core.Application._Shared.Models;
using MovieTickets.Core.Application._Shared.Queries;
using MovieTickets.Core.Infrastructure;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MovieTickets.Core.Application.Movies.Queries
{
    public class GetMoviesQuery : PagedQuery, IRequest<PageResult<MovieModel>>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, PageResult<MovieModel>>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public GetMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PageResult<MovieModel>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var pageResult = await _context.Movies
                .Where(movie => request.Id == null || movie.Id == request.Id)
                .Where(movie => string.IsNullOrEmpty(request.Name) || movie.Name.Contains(request.Name))
                .OrderBy(x => x.Name)
                .ProjectTo<MovieModel>(_mapper.ConfigurationProvider)
                .ToPageResultAsync(request);

            return pageResult;
        }
    }
}
