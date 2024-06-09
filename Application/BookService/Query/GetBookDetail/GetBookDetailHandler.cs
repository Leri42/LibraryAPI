using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookService.Query.GetBookDetail
{
    public class GetBookDetailHandler : IRequestHandler<GetBookDetailQuery, BookDetailModel>
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public GetBookDetailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BookDetailModel> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);
            //var book = await _unitOfWork.Books
            //            .Include(b => b.AuthorBook.Select(o=>o.Author))
            //            .FirstOrDefaultAsync(b => b.Id == request.Id);


            if (book == null)
            {
                throw new CustomException("Book can't be found");
            }

            var authorIds = await _unitOfWork.AuthorBook.GetAllAuthorIdsByBook(book.Id);

            var authorviewModels = new List<AuthorViewModel>();

            foreach(var authorId in authorIds)
            {
                var authorEnity = await _unitOfWork.Authors.GetByIdAsync(authorId);
                authorviewModels.Add(new AuthorViewModel
                {
                    FullName = authorEnity.FullName,
                    Birthdate = authorEnity.Birthdate,
                    Id = authorEnity.Id

                });
            }


            var bookDetailViewModel = new BookDetailModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                ReleaseYear = book.ReleaseYear,
                Rating = book.Rating,
                IsTaken = book.IsTaken,
                Authors= authorviewModels
            }; 
            return bookDetailViewModel;
        }
    }
}
