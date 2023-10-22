using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.Persistance.Configrations;

public class EventEntityTypeConfigration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Price)
            .IsRequired();

    }
}
