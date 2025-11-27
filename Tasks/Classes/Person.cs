public class Person
{
    public string Name { get; set; }
    public string Hobby { get; set; }
    public Person(string name, string hobby)
    {
        Name = name;
        Hobby = hobby;
    }
    public void React(string eventName)
    {
        if (Hobby.ToLower().Contains(eventName.ToLower()))
        {
            Console.WriteLine($"{Name}: \"Ура! Я ждал этого!\"");
        }
        else
        {
            Console.WriteLine($"{Name}: \"Не моё...\"");
        }
    }
}