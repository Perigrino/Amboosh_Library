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
    
    public async Task AddBookWithAuthors(BookVM bookObj) //Adds a book to db
    {
        var book = new Book()
        {
            Title = bookObj.Title,
            Description = bookObj.Description,
            IsRead = bookObj.IsRead,
            DateRead = bookObj.IsRead? bookObj.DateRead.Value: null,
            Rate = bookObj.IsRead? bookObj.Rate.Value: null,
            Genre = bookObj.Genre,
            CoverURL = bookObj.CoverURL,
            DateAdded = DateTime.Now,
            PublisherId = bookObj.PublisherId
        };
        _context.Books.Add(book);
        _context.SaveChanges();

        foreach (var id in bookObj.AuthorId)
        {
            var book_author = new BookAuthor()
            {
                BookId = book.Id,
                AuthorId = id
            };
            _context.Book_Authors.Add(book_author);
            _context.SaveChanges();
        }
    }

    public List<Book> GetAllBooks() //Gets a list of all book
    {
        var books = _context.Books.ToList();
        return books;
    }

    public BookWithAuthorsVM GetBookByWithAuthors(int bookId) //Gets book by Id
    {
        var book = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorsVM()
        {
            Title = book.Title,
            Description = book.Description,
            IsRead = book.IsRead,
            DateRead = book.IsRead ? book.DateRead.Value : null,
            Rate = book.IsRead ? book.Rate.Value : null,
            Genre = book.Genre,
            CoverURL = book.CoverURL,
            PublisherName = book.Publisher.Name,
            AuthorNames = book.BookAuthors.Select(n => n.Author.FullName).ToList()
        }).FirstOrDefault();
        
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