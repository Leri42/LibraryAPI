
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookService.Query.GetBookList
{
    public class BookListQueryHandler : IRequestHandler<GetBookListQuery, IEnumerable<BookListModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookListModel>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            int pageNumber = request.PageNumber;
            int pageSize = request.PageSize;

            var books = await _unitOfWork.Books.GetAllAsync();

            var pagedBooks = books
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .Select(book => new BookListModel
               {
                   Id = book.Id,
                   Title = book.Title,
                   Description = book.Description,
                   ImageUrl = book.ImageUrl,
                   Authors = book.AuthorBook.Select(ba => new AuthorViewModel
                   {
                       Id = ba.Author.Id,
                       FullName = ba.Author.FullName
                   })
               });

            return pagedBooks;

        }
    }
    }

