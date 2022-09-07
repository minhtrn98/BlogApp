﻿using BlogApp.Application.DTOs;
using MediatR;

namespace BlogApp.Application.Queries
{
    public record GetCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;
}
