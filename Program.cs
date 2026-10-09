namespace PersonalRegister;

internal class Program
{
    static void Main(string[] args)
    {
        var dataStorage = new DataStorage();
        List<Person> people = dataStorage.GetPeople();
        var peopleManager = new PeopleManager();
        var menu = new Menu(people, peopleManager);

        menu.Run();
    }
}


