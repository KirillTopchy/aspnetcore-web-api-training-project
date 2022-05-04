using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            var newPublisher = _publishersService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher);
        }

        [HttpGet("get-publisher-by-id/{id:int}")]
        public IActionResult GetPublisherById(int id)
        {
            var response = _publishersService.GetPublisherById(id);

            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet("get-publisher-books-with-authors/{id:int}")]
        public IActionResult GetPublisherData(int id)
        {
            var publisherWithBooks = _publishersService.GetPublisherData(id);

            if (publisherWithBooks != null)
            {
                return Ok(publisherWithBooks);
            }

            return NotFound();
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            var response = _publishersService.DeletePublisherById(id);

            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }
    }
}
