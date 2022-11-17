using Amboosh_Library.Data;
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

    public void AddPublisher(PublisherVM publisherObj) //Adds a Publisher to db
    {
        var publisher = new Publisher()
        {
            Name = publisherObj.Name
        };
        _context.Publishers.Add(publisher);
        _context.SaveChanges();
    }

    public List<Publisher> GetAllPublisher() //Gets a list of all Publisher
    {
        var publishers = _context.Publishers.ToList();
        return publishers;
    }

    public Publisher GetPublisherById(int publisherId) //Gets Publisher by Id
    {
        var publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
        return publisher;
    }

    public Publisher UpdatePublisherById(int publisherId, PublisherVM publisherObj) //Update a Publisher 
    {
        var publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
        if (publisher != null)
        {
            publisher.Name = publisherObj.Name;

            _context.SaveChanges();
        }
        return publisher;
    }

    public void DeleteById(int publishId) //Deletes a Publisher by Id
    {
        var publisher = _context.Publishers.FirstOrDefault(n => n.Id == publishId);
        if (publisher != null)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }
    }
}