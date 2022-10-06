﻿using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Commands.Insert
{
    public record InsertCategoryCommand(
        string Name,
        string Description,
        int MinThreshold) : IRequest<ErrorOr<CategoryResult>>;
}
