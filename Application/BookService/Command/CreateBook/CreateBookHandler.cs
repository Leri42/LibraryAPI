
using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepositories;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookService.Command.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                ReleaseYear = request.ReleaseYear,
                Rating = request.Rating
            };

            foreach (var id in request.Ids)
            {
                var author = await _unitOfWork.Authors.GetByIdAsync(id);
                if (author == null)
                {
                    throw new CustomException(@$"Author with this id:{id} not found, please first Add Author ");
                }
                book.AuthorBook.Add(new AuthorBook { Book = book, Author = author });
            }
            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
