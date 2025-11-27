public class BookCollection
{
    public Book[] Books { get; set; }
    public BookCollection(Book[] books)
    {
        Books = books;
    }
    public void SortBooks(BookComparer comparer)
    {
        Array.Sort(Books, (a, b) => comparer(a, b)); 
    }
}