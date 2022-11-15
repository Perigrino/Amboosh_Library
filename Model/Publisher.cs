namespace Amboosh_Library.Model;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    //Navigation Prop
    public List<Book> Books { get; set; }
}