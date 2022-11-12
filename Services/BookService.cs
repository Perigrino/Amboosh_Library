using Amboosh_Library.Data;
using Amboosh_Library.Model;
using Amboosh_Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Amboosh_Library.Services;

public class BookService
{
    private AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public void AddBook(BookVM book)
    {
        var _book = new Book()
        {
            Title = book.Title,
            Description = book.Description,
            IsRead = book.IsRead,
            DateRead = book.IsRead? book.DateRead.Value: null,
            Rate = book.IsRead? book.Rate.Value: null,
            Genre = book.Genre,
            Author = book.Author,
            CoverURL = book.CoverURL,
            DateAdded = DateTime.Now
        };
        _context.Books.Add(_book);
        _context.SaveChanges();
    }

    public List<Book> GetAllBooks()
    {
        var allBooks = _context.Books.ToList();
        return allBooks;
    }

    public Book GetBookById(int bookId)
    {
        var bookById = _context.Books.FirstOrDefault(n =>n.Id == bookId);
        return bookById;
    }

    public Book UpdateBookById(int bookId, BookVM book)
    {
        var _book = _context.Books.FirstOrDefault(n =>n.Id == bookId);
        if (_book != null)
        {
            _book.Title = book.Title;
            _book.Description = book.Description;
            _book.IsRead = book.IsRead;
            _book.DateRead = book.IsRead ? book.DateRead.Value : null;
            _book.Rate = book.IsRead ? book.Rate.Value : null;
            _book.Genre = book.Genre;
            _book.Author = book.Author;
            _book.CoverURL = book.CoverURL;
            
            _context.SaveChanges();
        }

        return _book;
    }

    public void DeleteById(int bookId)
    {
        var _book = _context.Books.FirstOrDefault(n =>n.Id == bookId);
        if (_book != null)
        {
            _context.Books.Remove(_book);
            _context.SaveChanges();
        }
    }
    
    public bool BookExists(int id)
    {
        return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}