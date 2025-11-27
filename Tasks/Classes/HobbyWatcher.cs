public class HobbyWatcher
{
    private List<Person> people;
    public HobbyWatcher()
    {
        people = new List<Person>
        {
            new Person("Анна", "Фильмы"),
            new Person("Борис", "Концерты"),
            new Person("Вика", "Книги")
        };
    }
    public void CheckEvent(string eventName)
    {
        foreach (var person in people)
        {
            person.React(eventName);
        }
    }
}