using PersonalRegister.Operations;
using PersonalRegister.Models;
using System.Text.RegularExpressions;
using PersonalRegister.UI;

namespace PersonalRegister.Controllers;

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
                    _output.PrintPeople(_peopleOperator.SortPeopleByID(_people));
                    break;
                case "2":
                    _output.PrintPeople(_peopleOperator.SortPeopleByID(_people, 5));
                    break;
                case "3":
                    _output.PrintPeople(_peopleOperator.SortPeopleByName(_people));
                    break;
                case "4":
                    _output.PrintPeople(_peopleOperator.SortPeopleByName(_people, 5));
                    break;
                case "5":
                    var searchText = _input.GetSearchText();
                    var matches = _peopleOperator.SearchPeopleByName(_people, searchText);
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


