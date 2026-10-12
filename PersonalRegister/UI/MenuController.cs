using PersonalRegister.Operations;
using PersonalRegister.Models;
using System.Text.RegularExpressions;

namespace PersonalRegister.UI;

public class MenuController
{
    private List<Person> _people;
    private PeopleOperator _peopleHandler;
    private InputHandler _input;
    private OutputHandler _output;
    public MenuController(List<Person> people, PeopleOperator peopleHandler, 
                            InputHandler input, OutputHandler output)
    {
        _people = people;
        _peopleHandler = peopleHandler;
        _input = input;
        _output = output;
    }
    public void Run()
    { 
    var continues = true;

        while (continues) 
        {
            Console.Clear();
            _output.ShowMenu();

            var choice = _input.GetMenuChoice();

            switch (choice)
            {
                case "1":
                    _output.PrintPeople(_peopleHandler.SortPeopleByID(_people));
                    break;
                case "2":
                    _output.PrintPeople(_peopleHandler.SortPeopleByID(_people, 5));
                    break;
                case "3":
                    _output.PrintPeople(_peopleHandler.SortPeopleByName(_people));
                    break;
                case "4":
                    _output.PrintPeople(_peopleHandler.SortPeopleByName(_people, 5));
                    break;
                case "5":
                    var searchText = _input.GetSearchText();
                    var matches = _peopleHandler.SearchPeopleByName(_people, searchText);
                    _output.PrintSearchResult(matches, searchText);
                    break;
                case "6":
                    continues = false;
                    _output.PrintExitMessage();
                    continue;
                default:
                    _output.HandleInvalidMenuChoice();
                    break;
            }
            _output.PrintReturnMessage();
        }
    }
}


