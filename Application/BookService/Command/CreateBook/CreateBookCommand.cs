using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookService.Command.CreateBook
{
    public class CreateBookCommand :IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public List<int> Ids { get; set; }
    }
}
