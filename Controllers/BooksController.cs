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
using Exception = System.Exception;

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
        public IActionResult GetBooks(string sortBy, string searchString, int pageNumber)
        {
            var books = _bookService.GetAllBooks(sortBy, searchString, pageNumber);
            if (books == null)
            {
                throw new Exception("Something went wrong whiles fetching all your books");
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
              throw new Exception("Something went wrong whiles fetching all your books");
          } 
          return Ok(book);
        }
 
        // // PUT: api/Books/
        [HttpPut("{bookId}")]
        public IActionResult PutBook(int bookId, [FromBody]BookVM bookObj)
        {
            var book = _bookService.UpdateBookById(bookId, bookObj);
            if (book == null)
            {
                throw new Exception("Something went wrong whiles fetching all your books");
            } 
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost()]
        public IActionResult PostBook ([FromBody]BookVM book)
        {
            try
            {
                _bookService.AddBookWithAuthors(book);
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong whiles creating your new book");
            }
        }

    // DELETE: api/Books/5
    [HttpDelete("{bookId}")]
    public IActionResult DeleteBook(int bookId)
    {
        try
        {
            _bookService.DeleteById(bookId);
            return Ok("This book has been deleted successfully.");
        }
        catch (Exception)
        {
            throw new Exception($"Something went wrong whiles deleting your book with ID {bookId}");
        }
    }
    

     }
}