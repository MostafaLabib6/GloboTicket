using AutoMapper;
using GloboTicket.Application.Features.Event.Commands;
using GloboTicket.Application.Models;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventsListDto>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();

        }
    }
}
