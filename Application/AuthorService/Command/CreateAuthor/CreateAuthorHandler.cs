
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthorService.Command.CreateAuthor
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAuthorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author { 
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Birthdate = request.Birthdate,
                };
            _unitOfWork.Authors.AddAsync(author);
            _unitOfWork.CompleteAsync();
            return Unit.Task;

        }
    }
}
