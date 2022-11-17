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
    
    public void AddBookWithAuthors(BookVM book) //Adds a book to db
    {
        var _book = new Book()
        {
            Title = book.Title,
            Description = book.Description,
            IsRead = book.IsRead,
            DateRead = book.IsRead? book.DateRead.Value: null,
            Rate = book.IsRead? book.Rate.Value: null,
            Genre = book.Genre,
            CoverURL = book.CoverURL,
            DateAdded = DateTime.Now,
            PublisherId = book.PublisherId
        };
        _context.Books.Add(_book);
        _context.SaveChanges();

        foreach (var id in book.AuthorId)
        {
            var _book_author = new BookAuthor()
            {
                BookId = _book.Id,
                AuthorId = id
            };
            _context.Book_Authors.Add(_book_author);
            _context.SaveChanges();
        }
    }

    public List<Book> GetAllBooks() //Gets a list of all book
    {
        var allBooks = _context.Books.ToList();
        return allBooks;
    }

    public Book GetBookById(int bookId) //Gets book by Id
    {
        var bookById = _context.Books.FirstOrDefault(n =>n.Id == bookId);
        return bookById;
    }

    public Book UpdateBookById(int bookId, BookVM book) //Update a book 
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
            _book.CoverURL = book.CoverURL;
            
            _context.SaveChanges();
        }

        return _book;
    }

    public void DeleteById(int bookId) //Deletes a book by Id
    {
        var _book = _context.Books.FirstOrDefault(n =>n.Id == bookId);
        if (_book != null)
        {
            _context.Books.Remove(_book);
            _context.SaveChanges();
        }
    }
}