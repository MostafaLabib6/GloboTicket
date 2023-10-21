using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Category.Commands.Create;

public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; } = string.Empty;
}
