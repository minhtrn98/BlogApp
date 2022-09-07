using MediatR;

namespace BlogApp.Application.Commands
{
    public record CreatePostCommand : IRequest
    {
        public string Title { get; }
        public string? MetaTitle { get; }
        public string Slug { get; }
        public string? Summary { get; }
        public string Content { get; }
        public int[] CategoryIds { get; }
        public CreatePostMetaCommand[] PostMetaes { get; }

        public CreatePostCommand(
            string Title,
            string? MetaTitle,
            string Slug,
            string? Summary,
            string Content,
            int[] CategoryIds,
            CreatePostMetaCommand[]? PostMetaes = null)
        {
            this.Title = Title;
            this.MetaTitle = MetaTitle;
            this.Slug = Slug;
            this.Summary = Summary;
            this.Content = Content;
            this.CategoryIds = CategoryIds;
            this.PostMetaes = PostMetaes ?? Array.Empty<CreatePostMetaCommand>();
        }
    }

    public record CreatePostMetaCommand(string Key, string? Content);
}
