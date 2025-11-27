using DZ10.Chapter11;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Упражнение 11.1:");
        Guid acc1 = BankAccountFactory.CreateAccount();
        Guid acc2 = BankAccountFactory.CreateAccount(5000m);
        Console.WriteLine($"Создан счёт: {acc1}");
        Console.WriteLine($"Создан счёт: {acc2} с балансом 5000");
        Console.WriteLine($"Закрытие счёта {acc1}");
        bool closed = BankAccountFactory.CloseAccount(acc1);
        Console.WriteLine($"Счёт закрыт: {closed}");
        Console.WriteLine("\nДомашнее задание 11.1:");
        Guid build = Creator.CreateBuild("ул.Колокольчиков,3");
        Console.WriteLine($"Здание создано: {build}");
        bool removed = Creator.RemoveBuild(build);
        Console.WriteLine($"Здание удалено: {removed}");






    }
} 
