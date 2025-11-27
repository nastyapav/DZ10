public class EventManager
{
    private const string StudentsFile = "students.txt";
    private const string EventsLog = "events.log";
    public List<Student> LoadStudents()
    {
        var students = new List<Student>();
        if (!File.Exists(StudentsFile))
        {
            // Создаём пример
            File.WriteAllText(StudentsFile, "Иванов;Группа1\nПетров;Группа2\nСидоров;Группа1\nКозлов;Группа3");
        }
        foreach (var line in File.ReadAllLines(StudentsFile))
        {
            var parts = line.Split(';');
            if (parts.Length == 2)
                students.Add(new Student(parts[0], parts[1]));
        }
        return students;
    }
    public List<string> LoadAllEvents()
    {
        var events = new List<string>();
        if (File.Exists(EventsLog))
        {
            foreach (var line in File.ReadAllLines(EventsLog))
            {
                if (line.Contains(" | "))
                {
                    var eventName = line.Split(" | ")[1];
                    if (!events.Contains(eventName))
                        events.Add(eventName);
                }
            }
        }
        return events;
    }
    public void SaveStudents(List<Student> students)
    {
        var lines = students.Select(s => $"{s.Name};{s.Group}");
        File.WriteAllLines(StudentsFile, lines);
    }
    public void LogEvent(string eventName, List<Student> participants)
    {
        using (var writer = File.AppendText(EventsLog))
        {
            writer.WriteLine($"{DateTime.Now:dd.MM.yyyy} | {eventName}");
            foreach (var p in participants)
                writer.WriteLine($"  {p.Name} ({p.Group})");
        }
    }
    public List<Student> SelectParticipants(List<Student> students, List<string> allEvents, int perGroup, string eventName)
    {
        var selected = new List<Student>();
        var groups = students.GroupBy(s => s.Group).ToList();

        foreach (var group in groups)
        {
            // Сначала добавляем добровольцев из группы
            var volunteers = group.Where(s => s.IsVolunteer).ToList();
            foreach (var v in volunteers.Take(perGroup))
            {
                selected.Add(v);
                v.EventsAttended.Add(eventName);
            }
            int remaining = perGroup - volunteers.Count;
            if (remaining > 0)
            {
                // Остальных выбираем по количеству пропущенных
                var candidates = group
                    .Where(s => !s.IsVolunteer)
                    .OrderByDescending(s => s.GetMissedCount(allEvents))
                    .ThenBy(s => Guid.NewGuid()) // случайность при равенстве
                    .Take(remaining);
                foreach (var c in candidates)
                {
                    selected.Add(c);
                    c.EventsAttended.Add(eventName);
                }
            }
        }
        return selected;
    }
}