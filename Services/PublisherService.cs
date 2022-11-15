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

    public void AddPublisher(PublisherVM publisher) //Adds a Publisher to db
    {
        var _publisher = new Publisher()
        {
            Name = publisher.Name
        };
        _context.Publishers.Add(_publisher);
        _context.SaveChanges();
    }

    public List<Publisher> GetAllPublisher() //Gets a list of all Publisher
    {
        var allPublisher = _context.Publishers.ToList();
        return allPublisher;
    }

    public Publisher GetPublisherById(int publisherId) //Gets Publisher by Id
    {
        var publisherById = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
        return publisherById;
    }

    public Publisher UpdatePublisherById(int publisherId, PublisherVM publisher) //Update a Publisher 
    {
        var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
        if (_publisher != null)
        {
            _publisher.Name = publisher.Name;

            _context.SaveChanges();
        }
        return _publisher;
    }

    public void DeleteById(int publishId) //Deletes a Publisher by Id
    {
        var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publishId);
        if (_publisher != null)
        {
            _context.Publishers.Remove(_publisher);
            _context.SaveChanges();
        }
    }
}