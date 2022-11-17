namespace Amboosh_Library.Model;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
    public DateTime? DateRead { get; set; }
    public int? Rate { get; set; }
    public string Genre { get; set; }
    public string CoverURL { get; set; }
    public DateTime DateAdded { get; set; }
    
    //Navigation Prop
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}