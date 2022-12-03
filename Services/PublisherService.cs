using System.Globalization;
using System.Text.RegularExpressions;
using Amboosh_Library.Data;
using Amboosh_Library.Data.Paging;
using Amboosh_Library.Exceptions;
using Amboosh_Library.Model;
using Amboosh_Library.ViewModels;

namespace Amboosh_Library.Services;

public class PublisherService
{
    private AppDbContext _context;
    public PublisherService(AppDbContext context)
    {
        _context = context;
    }

    public Publisher AddPublisher(PublisherVM publisherObj) //Adds a Publisher to db
    {
        var publisher = new Publisher()
        {
            Name = publisherObj.Name
        };
        _context.Publishers.Add(publisher);
        _context.SaveChanges();

        return publisher;
    }

    public List<Publisher> GetAllPublisher(string sortBy, string searchString, int? pageNumber) //Gets a list of all Publisher
    {
        var publishers = _context.Publishers.OrderBy(n => n.Name).ToList();
        if (!string.IsNullOrEmpty(sortBy))
        {
            switch (sortBy)
            {
                case "name_desc": publishers = _context.Publishers.OrderByDescending(n => n.Name).ToList();
                    break;
            }
        }
        if (!string.IsNullOrEmpty(searchString))
        {
            var publisher = publishers.Where(n => n.Name
                .Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        //Paging
        int pageSize = 5;
        publishers = PaginatedList<Publisher>.Create(publishers.AsQueryable(), pageNumber ?? 1, pageSize);
        
        return publishers;
    }

    public PublisherWithBooksAndAuthors GetPublisherById(int publisherId) //Gets Publisher by Id
    {
        var publisher = _context.Publishers.Where(n => n.Id == publisherId)
            .Select(n => new PublisherWithBooksAndAuthors()
            {
                Name = n.Name,
                BookAndAuthorsVM = n.Books.Select(n => new BookAndAuthorsVM()
                {
                    BookName = n.Title,
                    AuthorNames = n.BookAuthors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
        return publisher;
    }

    // public Publisher UpdatePublisherById(int publisherId, PublisherVM publisherObj) //Update a Publisher 
    // {
    //     var publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
    //     if (publisher != null)
    //     {
    //         publisher.Name = publisherObj.Name;
    //
    //         _context.SaveChanges();
    //     }
    //     return publisher;
    // }

    public void DeleteById(int publishId) //Deletes a Publisher by Id
    {
        var publisher = _context.Publishers.FirstOrDefault(n => n.Id == publishId);
        if (publisher != null)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception($"The publisher ID: {publishId} does not exist");
        }
    }

}