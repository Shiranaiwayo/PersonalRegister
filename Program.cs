

namespace PersonalRegister;

internal class Program
{
    static void Main(string[] args)
    {
        ShowMenu();

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                //Method ShowAllPeopleIDSorted
                break;
            case "2":
                //Method ShowTop5PeopleIDSorted
                break;
            case "3":
                //Method ShowAllPeopleNameSorted
                break;
            case "4":
                //Method ShowTop5PeopleNameSorted
                break;
            case "5":
                //Method SearchPeopleByName
                break;
            case "6":
                //End loop/program
                Console.WriteLine("Programmet avslutat.");
                break;
            default:
                Console.WriteLine("Ogiltig input. Välj ett nummer mellan 1 och 6.");
                break;
        }
    }
    private static void ShowMenu()
    {
        Console.WriteLine("""
            ************************************************
                             PERSONREGISTER      
            ************************************************
            1. Visa alla personer sortearde på ID
            2. Visa de 5 första personerna sorterade på ID
            3. Visa alla personer sorterade på namn
            4. Visa de 5 första personerna sorterade på namn
            5. Sök efter persons namn
            6. Avsluta program
            """);
        Console.Write("\nVälj ett alternativ (1-6): ");
    }

}


