using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using my_books.Exceptions;

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
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-by-id/{id:int}")]
        public Publisher GetPublisherById(int id)
        {
            // to test remove comment
            //throw new Exception("This is an exception that will be handled by middleware");
            var response = _publishersService.GetPublisherById(id);

            if (response != null)
            {
                return response;
                //return Ok(response);
            }

            return null;
            //return NotFound();
        }

        [HttpGet("get-publisher-books-with-authors/{id:int}")]
        public IActionResult GetPublisherData(int id)
        {
            try
            {
                var publisherWithBooks = _publishersService.GetPublisherData(id);

                if (publisherWithBooks != null)
                {
                    return Ok(publisherWithBooks);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                 _publishersService.DeletePublisherById(id);
                 return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
