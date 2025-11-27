using Tumakov12.Classes;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Упражнение 12.1:");
        var acc1 = new BankAccount(Guid.NewGuid(), 1000m);
        var acc2 = new BankAccount(acc1.AccountID, 1000m);
        Console.WriteLine(acc1);
        Console.WriteLine($"acc1 == acc2: {acc1 == acc2}");
        Console.WriteLine("Упражнение 12.2:");
        var r1 = new Rational(1, 2);
        var r2 = new Rational(3, 4);
        Console.WriteLine($"{r1} + {r2} = {r1 + r2}");
        Console.WriteLine($"{r1} > {r2}: {r1 > r2}");
        Console.WriteLine($"В float: {(float)r1}");
        Console.WriteLine("ДЗ 12.1:");
        var c1 = new Complex(1, 2);
        var c2 = new Complex(3, 4);
        Console.WriteLine($"{c1} + {c2} = {c1 + c2}");
        Console.WriteLine($"{c1} * {c2} = {c1 * c2}");
        Console.WriteLine("ДЗ 12.2:");
        var books = new Book[]
        {
            new Book("Война и мир", "Толстой", "АСТ"),
            new Book("Гарри Поттер", "Роулинг", "Росмэн"),
            new Book("1984", "Оруэлл", "Эксмо")
        };
        var collection = new BookCollection(books);
        Console.WriteLine("Исходный порядок");
        PrintBooks(collection.Books);
        // Сортировка по названию
        Console.WriteLine("\nПо названию");
        collection.SortBooks((a, b) => a.Title.CompareTo(b.Title));
        PrintBooks(collection.Books);
        // Сортировка по автору
        Console.WriteLine("\nПо автору");
        collection.SortBooks((a, b) => a.Author.CompareTo(b.Author));
        PrintBooks(collection.Books);
        // Сортировка по издательству
        Console.WriteLine("\nПо издательству");
        collection.SortBooks((a, b) => a.Publisher.CompareTo(b.Publisher));
        PrintBooks(collection.Books);
    }
    static void PrintBooks(Book[] books)
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }


}


