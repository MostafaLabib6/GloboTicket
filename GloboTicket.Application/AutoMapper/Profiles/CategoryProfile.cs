using AutoMapper;
using GloboTicket.Application.Features.Category.Commands.Create;
using GloboTicket.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Core.Domain.Entities.Category,CreateCategoryDto>();
            CreateMap<Core.Domain.Entities.Category,GetCategoryDto>();
            CreateMap<Core.Domain.Entities.Category,CreateCategoryCommand>();



        }
    }
}
