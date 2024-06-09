using Application.BookService.Command.BorrowingBook;
using Application.BookService.Command.CreateBook;
using Application.BookService.Command.DeleteBook;
using Application.BookService.Command.UpdateBook;
using Application.BookService.Query.GetBookDetail;
using Application.BookService.Query.GetBookList;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
   // [Authorize]
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

     

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooksList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetBookListQuery { PageNumber = pageNumber, PageSize = pageSize };
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var bookDto = await _mediator.Send(new GetBookDetailQuery() { Id= id});
            if (bookDto == null)
            {
                return NotFound();
            }
            
            return Ok(bookDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            var book = await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("BorrowingBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BorrowingBook(int id, [FromBody] BorrowingBookCommand command)
        {
            if (id != command.BookId)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBookCommand() { BookId=id});
            return NoContent();
        }
    }
}
