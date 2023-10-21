using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.Models
{
    public class CreateCategoryDto
    {
        public Guid CatgoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
