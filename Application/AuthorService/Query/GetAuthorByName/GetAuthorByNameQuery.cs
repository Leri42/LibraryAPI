using Application.Dto;
using MediatR;

namespace Application.AuthorService.Query.GetAuthorByName
{
    public class GetAuthorByNameQuery : IRequest<AuthorDto>
    {
        public string Name { get; set; }
        public string lastname { get; set; }
    }
}
