using BlogApp.Domain.Entities;
using BlogApp.Domain.Repositories;
using MediatR;

namespace BlogApp.Application.Commands.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post()
            {
                Title = request.Title,
                Content = request.Content,
                MetaTitle = request.MetaTitle,
                Slug = request.Slug,
                Summary = request.Summary,
            };

            post.Categories = await _unitOfWork.Category.GetByIdsAsync(request.CategoryIds, cancellationToken);
            post.PostMetaes = request.PostMetaes.Select(m => new PostMeta()
            {
                Key = m.Key,
                Content = m.Content
            }).ToList();

            await _unitOfWork.Post.AddAsync(post, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
