using PersonalRegister.Controllers;
using PersonalRegister.Data;
using PersonalRegister.Models;
using PersonalRegister.Operations;
using PersonalRegister.UI;

namespace PersonalRegister;

internal class Program
{
    static void Main(string[] args)
    {
        //Välj datakälla genom att kommentera ut antingen rad 14 eller 15
        IDataSource dataSource = new DataStorage();
        //IDataSource dataSource = new JsonDataStorage();   

        List<Person> people = dataSource.GetPeople();

        var peopleOperator = new PeopleOperator();
        var inputHandler = new InputHandler();
        var outputHandler = new OutputHandler();

        if (args.Length > 0)
        {
            var commandLineController = new CommandLineController(args, people, peopleOperator, outputHandler);
            commandLineController.Run();
        }
        else
        {
            var menuController = new MenuController(people, peopleOperator, inputHandler, outputHandler);
            menuController.Run();
        }
    }
}
