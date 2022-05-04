using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddBook([FromBody] AuthorVM author)
        {
            var newAuthor = _authorsService.AddAuthor(author);
            return Created(nameof(AddBook), newAuthor);
        }

        [HttpGet("get-author-with-books-by-id/{id:int}")]
        public IActionResult GetAuthorWithBooksById(int id)
        {
            var authorWithBooks = _authorsService.GetAuthorWithBooks(id);

            if (authorWithBooks != null)
            {
                return Ok(authorWithBooks);
            }

            return NotFound();
        }
    }
}
