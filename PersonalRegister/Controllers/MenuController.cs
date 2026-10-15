using PersonalRegister.Operations;
using PersonalRegister.Models;
using PersonalRegister.UI;

namespace PersonalRegister.Controllers;

/// <summary>
/// Controls the interactive menu and handles menu selections.
/// </summary>
public class MenuController
{
    private List<Person> _people;
    private PeopleOperator _peopleOperator;
    private InputHandler _input;
    private OutputHandler _output;
    public MenuController(List<Person> people, PeopleOperator peopleOperator, 
                            InputHandler input, OutputHandler output)
    {
        _people = people;
        _peopleOperator = peopleOperator;
        _input = input;
        _output = output;
    }

    /// <summary>
    /// Displays the menu and executes the operation specified by the user.
    /// </summary>
    public void Run()
    { 
    var continues = true;

        while (continues) 
        {
            Console.Clear();
            _output.ShowMenu();

            var menuChoice = _input.GetMenuChoice();

            switch (menuChoice)
            {
                case "1":
                    _output.PrintPeople(_peopleOperator.SortPeopleByID(_people), 
                                        "alla personer sorterade på ID");
                    break;
                case "2":
                    _output.PrintPeople(_peopleOperator.SortPeopleByID(_people, 5), 
                                        "de 5 första personerna sorterade på ID");
                    break;
                case "3":
                    _output.PrintPeople(_peopleOperator.SortPeopleByName(_people), 
                                        "alla personer sorterade på namn");
                    break;
                case "4":
                    _output.PrintPeople(_peopleOperator.SortPeopleByName(_people, 5), 
                                        "de 5 första personerna sorterade på namn");
                    break;
                case "5":
                    var searchText = _input.GetAndValidateSearchText();
                    var matches = _peopleOperator.SearchPeopleByName(_people, searchText);
                    _output.PrintSearchResult(matches, searchText);
                    break;
                case "6":
                    continues = false;
                    _output.PrintExitMessage();
                    continue;
                default:
                    _output.PrintErrorMessage("Ogiltig input. Välj en siffra mellan 1 och 6");
                    break;
            }
            _output.PrintReturnMessage();
        }
    }
}


