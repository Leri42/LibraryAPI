using Application.Dto;
using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthorService.Query.GetAuthor
{
    public class GetAuthorHandler : IRequestHandler<GetAuthorQuery, AuthorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAuthorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AuthorDto> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(request.Id);
            if (author == null)
            {
                throw new CustomException("Author wasn't fount");
            }
            AuthorDto authorDto = new AuthorDto()
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
