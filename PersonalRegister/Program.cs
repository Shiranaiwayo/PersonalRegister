namespace PersonalRegister;

internal class Program
{
    static void Main(string[] args)
    {
        var dataStorage = new DataStorage();
        List<Person> people = dataStorage.GetPeople();
        var peopleHandler = new PeopleHandler();
        var peoplePrinter = new PeoplePrinter();
        var menu = new Menu(people, peopleHandler, peoplePrinter);

        menu.Run();

        //testa jsonfil
        //var jsonDataStorage = new JsonDataStorage();
        //List<Person> peopleJson = jsonDataStorage.GetPeople();
        //peopleManager.PrintPeople(peopleJson);
    }
}


