using Domain.Entities;
using Domain.IRepositorie;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApiDbContext context) : base(context)
        {
        }

        public bool TakeBook(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && !book.IsTaken)
            {
                book.IsTaken = true;
                return true;
            }
            return false;
        }

        public bool ReturnBook(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && book.IsTaken)
            {
                book.IsTaken = false;
                return true;
            }
            return false;
        }

        public bool BorrowingBook(int bookId, bool isBorrowing)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && book.IsTaken!= isBorrowing){
                book.IsTaken = isBorrowing;
                return true;
            }
            return false;
        }
    }
}
