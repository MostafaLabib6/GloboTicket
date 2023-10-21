

using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.Application.Models;

public class GetCategoryDto
{
    public Guid CatgoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<EventEntity>? Events { get; set; }
}
