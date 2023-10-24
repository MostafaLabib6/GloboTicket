using GloboTicket.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}
