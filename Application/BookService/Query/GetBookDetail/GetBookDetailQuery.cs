using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookService.Query.GetBookDetail
{
    public class GetBookDetailQuery : IRequest<BookDetailModel>
    {
        public int Id { get; set; }
    }
}
