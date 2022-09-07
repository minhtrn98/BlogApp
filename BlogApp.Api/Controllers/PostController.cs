using BlogApp.Application.Commands;
using BlogApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    public class PostController : BlogAppControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellation)
        {
            return Ok(await Mediator.Send(new GetPostsQuery(), cancellation));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
