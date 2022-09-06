using BlogApp.Application.DTOs;
using MediatR;

namespace BlogApp.Application.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {

    }
}
