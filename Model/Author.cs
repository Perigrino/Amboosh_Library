namespace Amboosh_Library.Model;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }
    
    //Navigation Prop
    public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}