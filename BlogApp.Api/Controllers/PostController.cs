using BlogApp.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    public class PostController : BlogAppControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
