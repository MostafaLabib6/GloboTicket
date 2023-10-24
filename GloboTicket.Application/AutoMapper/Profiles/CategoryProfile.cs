using AutoMapper;
using GloboTicket.Application.Features.Category.Commands.Create;
using GloboTicket.Application.Models;
using GloboTicket.Core.Domain.Entities;
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
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryCommand>();
            CreateMap<CreateCategoryCommand,Category>();


        }
    }
}
