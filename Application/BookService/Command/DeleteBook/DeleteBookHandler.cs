using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookService.Command.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.BookId);

            if (book == null)
            {
                throw new CustomException(@$"{request.BookId} not found");
            }
           

            await _unitOfWork.Books.RemoveAsync(request.BookId);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
