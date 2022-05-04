using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            var newBook = _booksService.AddBookWithAuthors(book);
            return Created(nameof(AddBook), newBook);
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPut("update-book-by-id/{id:int}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);

            if (updatedBook != null)
            {
                return Ok(updatedBook);
            }

            return NotFound();
        }

        [HttpDelete("delete-book-by-id/{id:int}")]
        public IActionResult DeleteBookById(int id)
        {
            var deletedBook = _booksService.DeleteBookById(id);

            if (deletedBook != null)
            {
                return Ok(deletedBook);
            }

            return NotFound();
        }

        [HttpDelete("delete-all-books")]
        public IActionResult DeleteAllBooks()
        {
            _booksService.DeleteAllBooks();
            return Ok();
        }
    }
}
