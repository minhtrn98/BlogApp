using BlogApp.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    public class CategoryController : BlogAppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Mediator is null
                ? BadRequest()
                : Ok(await Mediator.Send(command));
        }
    }
}
