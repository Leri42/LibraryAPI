using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookService.Command.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new CustomException(@$"{request.Id} not found");
            }
            book.Title = request.Title;
            book.Description = request.Description;
            book.ImageUrl = request.ImageUrl;
            book.ReleaseYear = request.ReleaseYear;
            book.Rating = request.Rating;

            await _unitOfWork.Books.UpdateAsync(book);
            await _unitOfWork.CompleteAsync();

            return true;

        }
    }
}
