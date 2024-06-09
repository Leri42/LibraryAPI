using Domain.Entities;
using Domain.IRepositories;

namespace Domain.IRepositorie
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        bool BorrowingBook(int bookId, bool isBorrowing);
    }
}
