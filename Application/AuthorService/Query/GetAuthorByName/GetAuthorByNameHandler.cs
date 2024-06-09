using Application.Dto;
using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;

namespace Application.AuthorService.Query.GetAuthorByName
{
    public class GetAuthorByNameHandler : IRequestHandler<GetAuthorByNameQuery, AuthorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAuthorByNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AuthorDto> Handle(GetAuthorByNameQuery request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetAauthorByNameAsync(request.Name, request.lastname);
            if (author == null)
            {
                throw new CustomException("Author wasn't fount");
            }
            var authorDto = new AuthorDto
            {

                Firstname = author.Firstname,
                Lastname = author.Lastname,
                Birthdate = author.Birthdate,
                Fullname = author.FullName,
                Id = author.Id
            };
            return authorDto;

        }
    }
}
