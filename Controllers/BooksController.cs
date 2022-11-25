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
        [HttpGet()]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetAllBooks();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);

        }

        // GET: api/Books/5
        [HttpGet("{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
          if (_bookService.GetBookByWithAuthors(bookId) == null)
          {
              return NotFound();
          }
          var book = _bookService.GetBookByWithAuthors(bookId);
          if (book == null)
          {
                return NotFound();
          } 
          return Ok(book);
        }
 
        // // PUT: api/Books/
        [HttpPut("{bookId}")]
        public IActionResult PutBook(int bookId, [FromBody]BookVM book)
        {
            var updatedBook = _bookService.UpdateBookById(bookId, book);
            return Ok(updatedBook);
        }

        // POST: api/Books
        [HttpPost()]
        public IActionResult PostBook ([FromBody]BookVM book)
        {
            _bookService.AddBookWithAuthors(book);
            return Ok();
        }

    // DELETE: api/Books/5
    [HttpDelete("{bookId}")]
    public IActionResult DeleteBook(int bookId)
    {
        _bookService.DeleteById(bookId);
        return Ok();
    }
    

     }
}