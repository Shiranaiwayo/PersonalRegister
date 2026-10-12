

using System.Text.RegularExpressions;

namespace PersonalRegister;

public class Menu
{
    private List<Person> _people;
    private PeopleHandler _peopleHandler;
    private PeoplePrinter _peoplePrinter;
    public Menu(List<Person> people, PeopleHandler peopleHandler, PeoplePrinter peoplePrinter)
    {
        _people = people;
        _peopleHandler = peopleHandler;
        _peoplePrinter = peoplePrinter;
    }
    public void Run()
    { 
    var continues = true;

        while (continues) 
        {
            Console.Clear();
            ShowMenu();

            var choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    _peoplePrinter.PrintPeople(_peopleHandler.SortPeopleByID(_people));
                    break;
                case "2":
                    _peoplePrinter.PrintPeople(_peopleHandler.SortPeopleByID(_people, 5));
                    break;
                case "3":
                    _peoplePrinter.PrintPeople(_peopleHandler.SortPeopleByName(_people));
                    break;
                case "4":
                    _peoplePrinter.PrintPeople(_peopleHandler.SortPeopleByName(_people, 5));
                    break;
                case "5":
                    var searchText = PromptForName();
                    var matches = _peopleHandler.SearchPeopleByName(_people, searchText);
                    if (!matches.Any())
                    {
                        Console.WriteLine($"\nInga personer hittades för söktexten \"{searchText}\".");
                    }
                    else
                    {
                        Console.WriteLine($"\nSökresultat för \"{searchText}\":");
                        _peoplePrinter.PrintPeople(matches);
                    }
                    break;
                case "6":
                    continues = false;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nProgrammet avslutat.");
                    Console.ResetColor();
                    continue;
                default:
                    HandleInvalidInput();
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn.");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }

    private string PromptForName()
    {
        Console.Write("\nVad vill du söka på?: ");
        string? searchText = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(searchText))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\nSöktexten får inte vara tom, vänligen försök igen: ");
            Console.ResetColor();
            searchText = Console.ReadLine();
        }

        return searchText;
    }

    public void ShowMenu()
    {
        Console.WriteLine("""
            ************************************************
                             PERSONREGISTER      
            ************************************************
            1. Visa alla personer sorterade på ID
            2. Visa de 5 första personerna sorterade på ID
            3. Visa alla personer sorterade på namn
            4. Visa de 5 första personerna sorterade på namn
            5. Sök efter persons namn
            6. Avsluta program
            """);
        Console.Write("\nVälj ett alternativ (1-6): ");
    }
    public void HandleInvalidInput()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nOgiltig input. Välj ett nummer mellan 1 och 6.");
        Console.ResetColor();
    }
}


