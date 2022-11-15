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
    
    public void AddAuthor(AuthorVM author) //Adds a Author to db
    {
        var _author = new Author()
        {
            FullName = author.FullName
        };
        _context.Authors.Add(_author);
        _context.SaveChanges();
    }
    
    public List<Author> GetAllAuthors() //Gets a list of all authors
    {
        var allAuthors = _context.Authors.ToList();
        return allAuthors;
    }
    
    public Author GetAuthorById(int authorId) //Gets Author by Id
    {
        var authorById = _context.Authors.FirstOrDefault(n =>n.Id == authorId);
        return authorById;
    }
    
    public Author UpdateAuthorById(int authorId, AuthorVM author) //Update a Author 
    {
        var _author = _context.Authors.FirstOrDefault(n =>n.Id == authorId);
        if (_author != null)
        {
            _author.FullName = author.FullName;
            
            _context.SaveChanges();
        }

        return _author;
    }
    
    public void DeleteById(int authorId) //Deletes a Author by Id
    {
        var _author = _context.Authors.FirstOrDefault(n =>n.Id == authorId);
        if (_author != null)
        {
            _context.Authors.Remove(_author);
            _context.SaveChanges();
        }
    }
}