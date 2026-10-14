using PersonalRegister.Models;

namespace PersonalRegister.UI;

public class OutputHandler
{
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
    public void PrintPeople(IEnumerable<Person> people)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nRESULTAT");
        Console.ResetColor();

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
    public void PrintSearchResult(IEnumerable<Person> people, string searchText)
    {
        //var matches = people.ToList(); //Varför ToList istället för bara people.Any?
        if (!people.Any())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nInga personer hittades för söktexten \"{searchText}\".");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nSökresultat för \"{searchText}\":");
            Console.ResetColor();
            PrintPeople(people);
        }
    }
    public void HandleInvalidMenuChoice() //byta namn?
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nOgiltig input. Välj en siffra mellan 1 och 6.");
        Console.ResetColor();
    }

    public void PrintExitMessage()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nProgrammet avslutat.");
        Console.ResetColor();
    }
    public void PrintReturnMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn.");
        Console.ResetColor();
        Console.ReadKey(true);
    }
}
