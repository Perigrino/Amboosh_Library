namespace Amboosh_Library.Model;

public class BookAuthor
{
    public int Id { get; set; }
    
    //Navigation Prop
    public int  BookId { get; set; }
    public Book Book { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}