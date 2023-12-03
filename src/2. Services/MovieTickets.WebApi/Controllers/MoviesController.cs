using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Core.Application._Shared.Models;
using MovieTickets.Core.Application.Movies.Queries;

namespace MovieTickets.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private ISender? _mediator;
        private readonly ILogger<MoviesController> _logger;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PageResult<MovieModel>>> GetTodoItemsWithPagination([FromQuery] GetMoviesQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
