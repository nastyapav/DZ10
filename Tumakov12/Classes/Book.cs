public delegate int BookComparer(Book x, Book y);
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public Book(string title, string author, string publisher)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
    }
    public override string ToString()
    {
        return $"\"{Title}\" — {Author}, {Publisher}";
    }





}