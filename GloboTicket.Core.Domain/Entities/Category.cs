using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.Core.Domain.Entities;

public class Category
{
    public Guid CatgoryId { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Event>? Events { get; set; } 
}
