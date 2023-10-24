using GloboTicket.Core.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GloboTicket.Core.Domain.Entities;

public class Category : BaseEntity
{
    [Key]
    public Guid CatgoryId { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<EventEntity>? Events { get; set; }
}
