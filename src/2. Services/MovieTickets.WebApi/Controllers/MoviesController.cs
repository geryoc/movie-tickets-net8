using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Core.Application._Shared.Models;
using MovieTickets.Core.Application.Movies.Queries;

namespace MovieTickets.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(ILogger<MoviesController> logger) : ControllerBase
{
    private ISender _mediator;
    private readonly ILogger<MoviesController> _logger = logger;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [HttpGet]
    public async Task<ActionResult<PageResult<MovieModel>>> GetMovies([FromQuery] GetMoviesQuery query)
    {
        return await Mediator.Send(query);
    }
}
