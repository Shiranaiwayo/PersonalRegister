using PersonalRegister.Models;
using PersonalRegister.Operations;
using PersonalRegister.UI;

namespace PersonalRegister.Controllers;

/// <summary>
/// Handles command-line arguments and executes the selected operation.
/// </summary>
public class CommandLineController
{
    private string[] _args;
    private List<Person> _people;
    private PeopleOperator _peopleOperator;
    private OutputHandler _output;
    public CommandLineController(string[] args, List<Person> people, PeopleOperator peopleOperator, OutputHandler output)
    {
        _args = args;
        _people = people;
        _peopleOperator = peopleOperator;
        _output = output;
    }

    /// <summary>
    /// Executes the operation specified by the command-line arguments.
    /// </summary>
    public void Run()
    {
        var argument = ParseArguments();

        switch (argument)
        {
            case "sortAllByID":
                _output.PrintPeople(_peopleOperator.SortPeopleByID(_people), 
                                    "alla personer sorterade på ID");
                break;
            case "sort5ByID":
                _output.PrintPeople(_peopleOperator.SortPeopleByID(_people, 5), 
                                    "de 5 första personerna sorterade på ID");
                break;
            case "sortAllByName":
                _output.PrintPeople(_peopleOperator.SortPeopleByName(_people), 
                                    "alla personer sorterade på namn");
                break;
            case "sort5ByName":
                _output.PrintPeople(_peopleOperator.SortPeopleByName(_people, 5), 
                                    "de 5 första personerna sorterade på namn");
                break;
            case "searchByName":
                var searchText = _args[2];
                var matches = _peopleOperator.SearchPeopleByName(_people, searchText);
                _output.PrintSearchResult(matches, searchText);
                break;
            case "searchTextMissing":
                _output.PrintErrorMessage("Söktext saknas");
                break;
            case "invalidCommand":
                _output.PrintErrorMessage("Ogiltigt kommando");
                break;
            case "invalidArgument":
                _output.PrintErrorMessage("Ogiltigt argument");
                break;
        }
    }

    /// <summary>
    /// Parses command-line arguments to identify the requested operation.
    /// </summary>
    /// <returns>The operation name or an error identifier.</returns>
    private string ParseArguments()
    {
        if (_args[0] != "--list")
        {
            return "invalidCommand";
        }

        if (_args.Length == 1)
        {
            return "sortAllByID";
        }

        if (_args.Length == 2)
        {
            if (_args[1] == "--top5")
            {
                return "sort5ByID";
            }
            else if (_args[1] == "--sort")
            {
                return "sortAllByName";
            }
            else if (_args[1] == "--search")
            {
                return "searchTextMissing";
            }
        }

        if (_args.Length == 3)
        {
            if (_args[1] == "--sort" && _args[2] == "--top5")
            {
                return "sort5ByName";
            }
            if (_args[1] == "--search")
            {
                return string.IsNullOrWhiteSpace(_args[2])
                        ? "searchTextMissing" : "searchByName";
            }
        }
        return "invalidArgument";
    }
}
