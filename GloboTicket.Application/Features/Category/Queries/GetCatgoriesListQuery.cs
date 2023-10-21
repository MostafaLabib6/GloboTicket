using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Category.Queries;

public class GetCatgoriesListQuery : IRequest<List<GetCategoryDto>>
{
    public bool IncludeEvents { get; set; }
}
