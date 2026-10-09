

namespace PersonalRegister;

public class Menu
{
    private List<Person> _people;
    private PeopleManager _peopleManager;

    public Menu(List<Person> people, PeopleManager peopleManager)
    {
        _people = people;
        _peopleManager = peopleManager;
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
                    _peopleManager.PrintPeopleIDSorted(_people);
                    break;
                case "2":
                    _peopleManager.PrintPeopleIDSorted(_people, 5);
                    break;
                case "3":
                    _peopleManager.PrintPeopleNameSorted(_people);
                    break;
                case "4":
                    _peopleManager.PrintPeopleNameSorted(_people, 5);
                    break;
                case "5":
                    Console.Write("\nVad vill du söka på?: ");
                    _peopleManager.SearchPeopleByName(_people, Console.ReadLine());
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


