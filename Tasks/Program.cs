class Program
{
    static void Main(string[] args)
    {
        //Мероприятия
        var eventManager = new EventManager();
        var students = eventManager.LoadStudents();
        var allEvents = eventManager.LoadAllEvents();
        Console.WriteLine("Задача 1: Выбор студентов на мероприятие");
        Console.Write("Название мероприятия: ");
        string eventName = Console.ReadLine();
        Console.Write("Количество участников от каждой группы: ");
        int perGroup = int.Parse(Console.ReadLine());
        Console.WriteLine("\nОтметьте желающих участвовать (введите имена через запятую, или оставьте пустым):");
        string volunteersInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(volunteersInput))
        {
            var volunteerNames = volunteersInput.Split(',');
            foreach (var name in volunteerNames)
            {
                var student = students.Find(s => s.Name == name.Trim());
                if (student != null)
                    student.IsVolunteer = true;
            }
        }
        var selected = eventManager.SelectParticipants(students, allEvents, perGroup, eventName);
        eventManager.SaveStudents(students);
        eventManager.LogEvent(eventName, selected);
        Console.WriteLine("\nВыбранные студенты:");
        foreach (var s in selected)
            Console.WriteLine($"- {s.Name} ({s.Group})");
        //Хобби
        Console.WriteLine("\nЗадача 2: Реакция на событие");
        Console.Write("Введите событие (например: фильм, концерт, книга): ");
        string hobbyEvent = Console.ReadLine();
        var watcher = new HobbyWatcher();
        watcher.CheckEvent(hobbyEvent);
    }
}