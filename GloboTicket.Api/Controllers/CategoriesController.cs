using AutoMapper;
using GloboTicket.Application.Contracts.Persistance;
using GloboTicket.Application.Features.Category.Commands.Create;
using GloboTicket.Application.Features.Category.Queries;
using GloboTicket.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace GloboTicket.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(IMediator mapper, ICategoryRepository categoryRepository)
        {
            _mediator = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<ActionResult<List<GetCategoryDto>>> GetCategories([FromQuery] bool IncludeEvents = false)
        {
            var dtos = await _mediator.Send(new GetCatgoriesListQuery() { IncludeEvents = IncludeEvents });
            return Ok(dtos);
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create(CreateCategoryCommand createCategoryCommand)
        {
            var dto =await  _mediator.Send(createCategoryCommand);
            return Ok(dto);
        }
    }
}
