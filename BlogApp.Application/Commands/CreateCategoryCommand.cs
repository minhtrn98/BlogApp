using MediatR;

namespace BlogApp.Application.Commands
{
    public record CreateCategoryCommand(
        string Title,
        string Slug,
        string Content,
        string? MetaTitle = null,
        int? ParentId = null
        ) : IRequest;
}
