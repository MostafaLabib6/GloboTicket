﻿using GloboTicket.Core.Domain.Common;
using GloboTicket.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class EventEntity: BaseEntity
    {
        [Key]
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? Artist { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;

    }
}
