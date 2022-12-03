using Amboosh_Library.Data;
using Amboosh_Library.Data.Paging;
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
    
    public List<Author> GetAllAuthors(string sortBy, string searchString, int? pageNumber) //Gets a list of all authors
    {
        var authors = _context.Authors.OrderBy(n => n.FullName).ToList();
        if (!string.IsNullOrEmpty(sortBy))
        {
            switch (sortBy)
            {
                case "desc": authors = _context.Authors.OrderByDescending(n => n.FullName).ToList();
                    break;
            }
        }
        if (!string.IsNullOrEmpty(searchString))
        {
            var author = authors
                .Where(n => n.FullName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        //Paging
        int pageSize = 5;
        authors = PaginatedList<Author>.Create(authors.AsQueryable(), pageNumber ?? 1, pageSize);

        return authors;
    }
    
    public AuthorWithListOfBooksVM GetAuthorById(int authorId) //Gets Author by Id
    {
        var author = _context.Authors.Where(n => n.Id == authorId)
            .Select(f => new AuthorWithListOfBooksVM()
        {
            FullName = f.FullName,
            BookTitles = f.BookAuthors.Select(bt => bt.Book.Title).ToList()
        }).FirstOrDefault();
        
        return author;
    }
    
    // public Author UpdateAuthorById(int authorId, AuthorVM authorObj) //Update a Author 
    // {
    //     var author = _context.Authors.FirstOrDefault(n =>n.Id == authorId);
    //     if (author != null)
    //     {
    //         author.FullName = authorObj.FullName;
    //         
    //         _context.SaveChanges();
    //     }
    //
    //     return author;
    // }
    
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