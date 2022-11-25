namespace Amboosh_Library.ViewModels;

public class PublisherVM
{
    public string Name { get; set; }
}

public class PublisherWithBooksAndAuthors
{
    public string Name { get; set; }
    public List<BookAndAuthorsVM> BookAndAuthorsVM { get; set; }
}

public class BookAndAuthorsVM
{
    public string BookName { get; set; }
    public List<string> AuthorNames { get; set; }
}