

namespace PersonalRegister;

internal class Program
{
    static void Main(string[] args)
    {
        var dataStorage = new DataStorage();
        List<Person> people = dataStorage.GetPeople();

        var continues = true;

        while (continues) 
        {
            Console.Clear();
            ShowMenu();

            var choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    PrintPeopleIDSorted(people);
                    break;
                case "2":
                    PrintPeopleIDSorted(people, 5);
                    break;
                case "3":
                    PrintPeopleNameSorted(people);
                    break;
                case "4":
                    PrintPeopleNameSorted(people, 5);
                    break;
                case "5":
                    Console.Write("\nVad vill du söka på?: ");
                    SearchPeopleByName(people, Console.ReadLine());
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
    private static void ShowMenu()
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
    private static void PrintPeople(IEnumerable<Person> people)
    {
        Console.WriteLine("\nRESULTAT");
        
        foreach (Person person in people)
        {
            Console.WriteLine($"""
            ------------------------------------------------
            ID:             {person.Id}
            Namn:           {person.Name}
            Epost:          {person.Email}
            Gatuadress:     {person.Address.Street}
            Postnummer:     {person.Address.PostalCode}
            Ort:            {person.Address.City}
            Företag:        {person.Company.Name}
            Företagsslogan: {person.Company.Slogan}
            """);
        }
        Console.WriteLine("------------------------------------------------");
    }
    private static void PrintPeopleIDSorted(IEnumerable<Person> people, int? quantity = null)
    {
        if (quantity != null)
        {
            PrintPeople(people.OrderBy(person => person.Id).Take(quantity.Value));
        }
        else
        {
            PrintPeople(people.OrderBy(person => person.Id));
        }

    }
    private static void PrintPeopleNameSorted(IEnumerable<Person> people, int? quantity = null)
    {
        if (quantity != null)
        {
            PrintPeople(people.OrderBy(person => person.Name).Take(quantity.Value));
        }
        else
        {
            PrintPeople(people.OrderBy(person => person.Name));
        }
    }
    private static void SearchPeopleByName(IEnumerable<Person> people, string? searchText)
    {
        while (string.IsNullOrEmpty(searchText.Trim()))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\nSöktexten får inte vara tom, vänligen försök igen: ");
            Console.ResetColor();
            searchText = Console.ReadLine();
        }

        IEnumerable<Person> matches = people
            .Where(person => person.Name.ToLower()
            .Contains(searchText.Trim().ToLower()))
            .OrderBy(person => person.Id);

        if (!matches.Any())
        {
            Console.WriteLine($"\nInga personer hittades för söktexten \"{searchText}\".");
            return;
        }

        Console.WriteLine($"\nSökresultatet för \"{searchText}\":");

        PrintPeople(matches);
    }
    private static void HandleInvalidInput()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nOgiltig input. Välj ett nummer mellan 1 och 6.");
        Console.ResetColor();
    }

}


