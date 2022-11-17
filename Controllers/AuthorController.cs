using Amboosh_Library.Services;
using Amboosh_Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Amboosh_Library.Controllers;

public class AuthorController : Controller
{
    private readonly AuthorService _authorService;

    public AuthorController(AuthorService authorService)
    {
        _authorService = authorService;
    }
    // GET: api/Authors
   [HttpGet("get_all_authors")]
   public IActionResult GetAuthors()
   {
       var allAuthors = _authorService.GetAllAuthors();
       return Ok(allAuthors);

   }
       
       // GET: api/Authors/5
       [HttpGet("author_by_Id/{authorId}")]
       public IActionResult GetAuthorById(int authorId)
       { 
           var author = _authorService.GetAuthorById(authorId);
           return Ok(author);
       }
        
       // // PUT: api/Authors/
       [HttpPut("update_author/{id}")]
       public IActionResult PutPublisher(int id, [FromBody]AuthorVM author)
       {
           var updatedAuthor = _authorService.UpdateAuthorById(id, author);
           return Ok(updatedAuthor);
       }

       // POST: api/Authors
       [HttpPost("add_author")]
       public IActionResult PostPublisher ([FromBody]AuthorVM author)
       {
           _authorService.AddAuthor(author);
           return Ok();
       }
       
       // DELETE: api/Authors/5
       [HttpDelete("delete_author/{id}")]
       public IActionResult DeleteAuthor (int id)
       {
           _authorService.DeleteById(id);
           return Ok();
       }
}