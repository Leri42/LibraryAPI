using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using System.Reflection;

namespace Application.BookService.Command.BorrowingBook
{
    public class BorrowingBookHandler : IRequestHandler<BorrowingBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BorrowingBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(BorrowingBookCommand request, CancellationToken cancellationToken)
        {
            var book  = await _unitOfWork.Books.GetByIdAsync(request.BookId);
            if(book == null)
            {
                throw new CustomException("Book Not Found");
            }
            var changeBookStatus = _unitOfWork.Books.BorrowingBook(book.Id, request.isBorrowing);
            if (changeBookStatus)
            {
                return Unit.Value;
            }
            else
            {
                throw new CustomException("Book already Has this status");
            }
        }
    }
}
