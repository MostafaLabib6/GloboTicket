using AutoMapper;
using GloboTicket.Application.Models;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.Application.AutoMapper.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, GetOrderDto>();
    }
}
