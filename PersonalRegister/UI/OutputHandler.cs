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
    public void PrintSearchResult(IEnumerable<Person> people, string searchText)
    {
        //var matches = people.ToList(); //Varför ToList istället för bara people.Any?
        if (!people.Any())
        {
            Console.WriteLine($"\nInga personer hittades för söktexten \"{searchText}\".");
        }
        else
        {
            Console.WriteLine($"\nSökresultat för \"{searchText}\":");
            PrintPeople(people);
        }
    }
    public void HandleInvalidMenuChoice() //byta namn?
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nOgiltig input. Välj ett nummer mellan 1 och 6.");
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
