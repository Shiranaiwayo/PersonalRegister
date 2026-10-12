using PersonalRegister.Data;
using PersonalRegister.Models;
using PersonalRegister.Operations;
using PersonalRegister.UI;

namespace PersonalRegister;

internal class Program
{
    static void Main(string[] args)
    {
        IDataSource dataStorage = new DataStorage();
        List<Person> people = dataStorage.GetPeople();

        var peopleHandler = new PeopleOperator();
        var inputHandler = new InputHandler();
        var outputHandler = new OutputHandler();

        var menuController = new MenuController(people, peopleHandler, inputHandler, outputHandler);

        menuController.Run();

        //testa jsonfil
        //var jsonDataStorage = new JsonDataStorage();
        //List<Person> peopleJson = jsonDataStorage.GetPeople();
        //peopleManager.PrintPeople(peopleJson);
    }
}
