namespace Amboosh_Library.ViewModels;

public class AuthorVM
{
    public string FullName { get; set; }
}

public class AuthorWithListOfBooksVM
{
    public string FullName { get; set; }
    public List<string> BookTitles { get; set; }
}