using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amboosh_Library.Data;
using Amboosh_Library.Model;
using Amboosh_Library.Services;
using Amboosh_Library.ViewModels;

namespace Amboosh_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet("get_all_books")]
        public IActionResult GetBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            if (allBooks == null)
            {
                return NotFound();
            }
            return Ok(allBooks);

        }

        // GET: api/Books/5
        [HttpGet("{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
          if (_bookService.GetBookById(bookId) == null)
          {
              return NotFound();
          }
          var book = _bookService.GetBookById(bookId);
          if (book == null)
          {
                return NotFound();
          } 
          return Ok(book);
        }
 
        // // PUT: api/Books/
        [HttpPut("update_book/{id}")]
        public IActionResult PutBook(int id, [FromBody]BookVM book)
        {
            var updatedBook = _bookService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        // POST: api/Books
        [HttpPost("add_book_with_authors")]
        public IActionResult PostBook ([FromBody]BookVM book)
        {
            _bookService.AddBookWithAuthors(book);
            return Ok();
        }

    // DELETE: api/Books/5
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        _bookService.DeleteById(id);
        return Ok();
    }
    

     }
}