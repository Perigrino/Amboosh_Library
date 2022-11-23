using Amboosh_Library.Services;
using Amboosh_Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Amboosh_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/Authors
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);

        }
        
        // GET: api/Authors/5
        // [HttpGet("{authorId}")]
        // public IActionResult GetAuthorById(int authorId)
        // {
        //     var author = _authorService.GetAuthorById(authorId);
        //     return Ok(author);
        // }

        // PUT: api/Authors/
        // [HttpPut("{authorId}")]
        // public IActionResult PutPublisher(int authorId, [FromBody] AuthorVM authorObj)
        // {
        //     var author = _authorService.UpdateAuthorById(authorId, authorObj);
        //     return Ok(author);
        // }

        // POST: api/Authors
        [HttpPost()]
        public IActionResult PostPublisher([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        // DELETE: api/Authors/5
        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorService.DeleteById(id);
            return Ok();
        }
    }
}