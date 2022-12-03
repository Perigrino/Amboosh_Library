using Amboosh_Library.Data;
using Amboosh_Library.Exceptions;
using Amboosh_Library.Model;
using Amboosh_Library.Services;
using Amboosh_Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Amboosh_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly PublisherService _publisherService;

        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/Publisher
        [HttpGet()]
        public IActionResult GetPublishers(string sortBy, string searchString)
        {
            try
            {
                var publishers = _publisherService.GetAllPublisher(sortBy, searchString);
                return Ok(publishers);
            }
            catch (Exception e)
            {
                return BadRequest("Could not load your list of publishers");
            }

        }

        // GET: api/Publisher/5
        [HttpGet("{publisherId}")]
        public IActionResult GetPublisherById(int publisherId)
        {
            var publisher = _publisherService.GetPublisherById(publisherId);
            if (publisher != null)
            {
                return Ok(publisher);
            }
            else
            {
                return NotFound(); 
            }
                
        }

        // // PUT: api/Publisher/
        // [HttpPut("{publisherId}")]
        // public IActionResult PutPublisher(int publisherId, [FromBody] PublisherVM publisher)
        // {
        //     var updatedPublisher = _publisherService.UpdatePublisherById(publisherId, publisher);
        //     return Ok(updatedPublisher);
        // }

        // POST: api/Publisher
        [HttpPost()]
        public IActionResult PostPublisher([FromBody] PublisherVM publisherObj)
        {
            var publisher = _publisherService.AddPublisher(publisherObj);
            throw new Exception();
            return Ok(publisher);
        }

        // DELETE: api/Publisher/5
        [HttpDelete("{publisherId}")]
        public IActionResult DeletePublisher(int publisherId)
        {
            try
            {
                _publisherService.DeleteById(publisherId);
                return Ok("Publisher has been deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}