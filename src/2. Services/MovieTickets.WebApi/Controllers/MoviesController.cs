using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Core.Application._Shared.Models.CustomModels;
using MovieTickets.Core.Application._Shared.Models.EntityModels;
using MovieTickets.Core.Application.Movies.Queries;

namespace MovieTickets.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(ILogger<MoviesController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<MoviesController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<PageResult<MovieModel>>> GetMovies([FromQuery] GetMoviesQuery query)
    {
        return await _mediator.Send(query);
    }
}
