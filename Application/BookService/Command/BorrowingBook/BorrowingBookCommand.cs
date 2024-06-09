using MediatR;

namespace Application.BookService.Command.BorrowingBook
{
    public class BorrowingBookCommand : IRequest<Unit>
    {
        public int BookId { get; set; }
        public bool isBorrowing { get; set; }
    }
}
