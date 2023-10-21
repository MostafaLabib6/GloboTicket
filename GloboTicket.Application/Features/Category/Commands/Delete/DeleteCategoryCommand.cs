using MediatR;

namespace GloboTicket.Application.Features.Category.Commands.Delete;

public class DeleteCategoryCommand:IRequest
{
    public Guid CategoryId { get; set; }
}
