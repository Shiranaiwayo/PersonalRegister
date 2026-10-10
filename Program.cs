using System.Text.Json;

namespace PersonalRegister;

internal class Program
{
    static void Main(string[] args)
    {
        var dataStorage = new DataStorage();
        List<Person> people = dataStorage.GetPeople();
        var peopleManager = new PeopleManager();
        var menu = new Menu(people, peopleManager);

        //menu.Run();

        //testa jsonfil
        var jsonDataStorage = new JsonDataStorage();
        List<Person> peopleJson = jsonDataStorage.GetPeople();
        peopleManager.PrintPeople(peopleJson);
    }
}
public interface IDataSource
{
    List<Person> GetPeople(); //IEnumerable istället för List?
}
public class JsonDataStorage : IDataSource
{
    public List<Person> GetPeople()
    {
        string json = File.ReadAllText("people.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(json, options);
        return people ?? new List<Person>();
    }
}


