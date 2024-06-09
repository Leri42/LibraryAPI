using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthorService.Query.GetAuthor
{
    public class GetAuthorQuery :IRequest<AuthorDto>
    {
        public int Id { get; set; }
    }
}
