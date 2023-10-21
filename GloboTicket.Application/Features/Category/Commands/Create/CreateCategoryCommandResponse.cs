using GloboTicket.Application.Models;
using GloboTicket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {

        }

        // i need to map CategoryEntity to outerface Dto so i add that here.
        CreateCategoryDto CategoryDto { get; set; } = default!;
    }
}
