using Amboosh_Library.Data;
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
        public IActionResult GetPublishers()
        {
            var allpublishers = _publisherService.GetAllPublisher();
            return Ok(allpublishers);

        }

        // GET: api/Publisher/5
        [HttpGet("{publisherId}")]
        public IActionResult GetPublisherById(int publisherId)
        {
            var publisher = _publisherService.GetPublisherById(publisherId);
            return Ok(publisher);
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
        public IActionResult PostPublisher([FromBody] PublisherVM publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok();
        }

        // DELETE: api/Publisher/5
        [HttpDelete("{publisherId}")]
        public IActionResult DeletePublisher(int id)
        {
            _publisherService.DeleteById(id);
            return Ok("Publisher has been deleted successfully");
        }
    }
}