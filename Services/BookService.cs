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
        var book = _context.Books.FirstOrDefault(n =>n.Id == bookId);
        return book;
    }

    public Book UpdateBookById(int bookId, BookVM bookObj) //Update a book 
    {
        var book = _context.Books.FirstOrDefault(n =>n.Id == bookId);
        if (book != null)
        {
            book.Title = bookObj.Title;
            book.Description = bookObj.Description;
            book.IsRead = bookObj.IsRead;
            book.DateRead = bookObj.IsRead ? bookObj.DateRead.Value : null;
            book.Rate = bookObj.IsRead ? bookObj.Rate.Value : null;
            book.Genre = bookObj.Genre;
            book.CoverURL = bookObj.CoverURL;
            
            _context.SaveChanges();
        }

        return book;
    }

    public void DeleteById(int bookId) //Deletes a book by Id
    {
        var book = _context.Books.FirstOrDefault(n =>n.Id == bookId);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}