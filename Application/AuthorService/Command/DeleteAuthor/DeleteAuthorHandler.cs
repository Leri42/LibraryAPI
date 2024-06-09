using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthorService.Command.DeleteAuthor
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAuthorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(request.AuthorId);
            if (author == null)
            {
                throw new CustomException("Author Not Found");
            }
            await _unitOfWork.Authors.RemoveAsync(request.AuthorId);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
