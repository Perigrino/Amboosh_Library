using Amboosh_Library.Data;
using Amboosh_Library.Model;
using Amboosh_Library.Services;
using Amboosh_Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Amboosh_Library.Controllers;

public class PublisherController : Controller
{
    private readonly PublisherService _publisherService;

    public PublisherController(PublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    // GET: api/Publisher
    [HttpGet("get_all_publisher")]
    public IActionResult GetPublishers()
    {
        var allpublishers = _publisherService.GetAllPublisher();
        return Ok(allpublishers);

    }

    // GET: api/Publisher/5
    [HttpGet("publisher_by_Id/{publisherId}")]
    public IActionResult GetPublisherById(int publisherId)
    {
        var publisher = _publisherService.GetPublisherById(publisherId);
        return Ok(publisher);
    }

    // // PUT: api/Publisher/
    [HttpPut("update_publisher/{id}")]
    public IActionResult PutPublisher(int id, [FromBody] PublisherVM publisher)
    {
        var updatedPublisher = _publisherService.UpdatePublisherById(id, publisher);
        return Ok(updatedPublisher);
    }

    // POST: api/Publisher
    [HttpPost("add_publisher")]
    public IActionResult PostPublisher([FromBody] PublisherVM publisher)
    {
        _publisherService.AddPublisher(publisher);
        return Ok();
    }

    // DELETE: api/Publisher/5
    [HttpDelete("delete_publish/{id}")]
    public IActionResult DeletePublisher(int id)
    {
        _publisherService.DeleteById(id);
        return Ok("Publisher has been deleted successfully");
    }
}