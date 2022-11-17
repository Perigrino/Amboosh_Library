using Amboosh_Library.Data;
using Amboosh_Library.Model;
using Amboosh_Library.ViewModels;

namespace Amboosh_Library.Services;

public class AuthorService
{
    private AppDbContext _context;

    public AuthorService(AppDbContext context)
    {
        _context = context;
    }
    
    public void AddAuthor(AuthorVM authorObj) //Adds a Author to db
    {
        var author = new Author()
        {
            FullName = authorObj.FullName
        };
        _context.Authors.Add(author);
        _context.SaveChanges();
    }
    
    public List<Author> GetAllAuthors() //Gets a list of all authors
    {
        var authors = _context.Authors.ToList();
        return authors;
    }
    
    public Author GetAuthorById(int authorId) //Gets Author by Id
    {
        var author = _context.Authors.FirstOrDefault(n =>n.Id == authorId);
        return author;
    }
    
    public Author UpdateAuthorById(int authorId, AuthorVM authorObj) //Update a Author 
    {
        var author = _context.Authors.FirstOrDefault(n =>n.Id == authorId);
        if (author != null)
        {
            author.FullName = authorObj.FullName;
            
            _context.SaveChanges();
        }

        return author;
    }
    
    public void DeleteById(int authorId) //Deletes a Author by Id
    {
        var author = _context.Authors.FirstOrDefault(n =>n.Id == authorId);
        if (author != null)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}