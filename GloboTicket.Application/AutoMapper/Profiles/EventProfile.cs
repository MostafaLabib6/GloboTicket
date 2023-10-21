using AutoMapper;
using GloboTicket.Application.Features.Event.Commands.Update;
using GloboTicket.Application.Models;
using GloboTicket.Core.Domain.Entities;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventEntity, EventsListDto>().ReverseMap();
            CreateMap<EventEntity, EventDto>().ReverseMap();
            CreateMap<EventCreationDto, EventEntity>();
            CreateMap<EventUpdateDto, EventEntity>();
        }
    }
}
