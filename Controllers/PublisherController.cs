
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
        public IActionResult GetPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                var publishers = _publisherService.GetAllPublisher(sortBy, searchString, pageNumber);
                return Ok(publishers);
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong whiles fetching all your publishers");
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

            throw new Exception($"Something went wrong whiles fetching publisher with ID {publisherId}");

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
            try
            {
                var publisher = _publisherService.AddPublisher(publisherObj);
                return Ok(publisher);
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong whiles creating your new publisher");
            }
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
            catch (Exception)
            {
                throw new Exception("Something went wrong whiles deleting your publisher");
            }
            
        }
    }
}