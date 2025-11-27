public class Student
{
    public string Name { get; set; }
    public string Group { get; set; }
    public List<string> EventsAttended { get; set; }
    public bool IsVolunteer { get; set; } // хочет ли участвовать добровольно
    public Student(string name, string group)
    {
        Name = name;
        Group = group;
        EventsAttended = new List<string>();
        IsVolunteer = false;
    }
    // Сколько из последних мероприятий пропущено
    public int GetMissedCount(List<string> allEvents)
    {
        return allEvents.Count(e => !EventsAttended.Contains(e));
    }
}