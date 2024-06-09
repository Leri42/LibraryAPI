using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthorService.Command.UpdateAuthor
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(request.Id);
            if (author == null)
            {
                throw new CustomException("Author Not Found");
            }
            author.Firstname = request.Firstname;
            author.Lastname = request.Lastname;
            author.Birthdate = request.Birthdate;

            await _unitOfWork.Authors.UpdateAsync(author);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
