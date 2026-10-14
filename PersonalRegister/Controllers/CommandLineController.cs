using PersonalRegister.Models;
using PersonalRegister.Operations;
using PersonalRegister.UI;

namespace PersonalRegister.Controllers;

public class CommandLineController
{
    private string[] _args;
    private List<Person> _people;
    private PeopleOperator _peopleOperator;
    private OutputHandler _output;
    public CommandLineController(string[] args, List<Person> people)
    {
        _args = args;
        _people = people;
        _peopleOperator = new PeopleOperator();
        _output = new OutputHandler();
    }

    public void Run()
    {
        var choice = CheckArguments();

        switch (choice)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ogiltigt kommando.");
                Console.ResetColor();
                break;
            case 2:
                _output.PrintPeople(_peopleOperator.SortPeopleByID(_people));
                break;
            case 3:
                _output.PrintPeople(_peopleOperator.SortPeopleByID(_people, 5));
                break;
            case 4:
                _output.PrintPeople(_peopleOperator.SortPeopleByName(_people));
                break;
            case 5:
                _output.PrintPeople(_peopleOperator.SortPeopleByName(_people, 5));
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Söktext saknas");
                Console.ResetColor();
                break;
            case 7:
                var searchText = _args[2];
                var matches = _peopleOperator.SearchPeopleByName(_people, searchText);
                _output.PrintSearchResult(matches, searchText);
                break;
            case 8:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ogitigt argument");
                Console.ResetColor();
                break;
        }
    }
    private int CheckArguments()
    {
        if (_args[0] != "--list")
        {
            return 1;
        }

        if (_args.Length == 1)
        {
            return 2;
        }

        if (_args.Length == 2)
        {
            if (_args[1] == "--top5")
            {
                return 3;
            }
            else if (_args[1] == "--sort")
            {
                return 4;
            }
            else if (_args[1] == "--search")
            {
                return 6;
            }
        }
        
        if (_args.Length == 3 && _args[1] == "--sort")
        {
            if (_args[2] == "--top5")
            {
                return 5;
            }
        }

        if (_args.Length == 3 && _args[1] == "--search")
        {
            if (string.IsNullOrWhiteSpace(_args[2]))
            {
                return 6;
            }

            return 7;
        }
        return 8;
    }

}
