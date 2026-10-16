using PersonalRegister.Models;

namespace PersonalRegister.UI;

/// <summary>
/// Handles the display of information to the console.
/// </summary>
public class OutputHandler
{
    /// <summary>
    /// Displays the menu options.
    /// </summary>
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

    /// <summary>
    /// Displays a collection of people with a description of the results.
    /// </summary>
    /// <param name="people">The people to display.</param>
    /// <param name="description">Describes the operation used to retrieve the results.</param>
    public void PrintPeople(IEnumerable<Person> people, string description)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\nVisar {description}:");
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

    /// <summary>
    /// Displays the results of a name search.
    /// </summary>
    /// <param name="matches">The people matching the search.</param>
    /// <param name="searchText">The text used in the search.</param>
    public void PrintSearchResult(IEnumerable<Person> matches, string searchText)
    {
        if (!matches.Any())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nInga personer hittades för söktexten \"{searchText}\".");
            Console.ResetColor();
        }
        else
        {
            PrintPeople(matches, $"resultat innehållande söktexten \"{searchText}\"");
        }
    }

    /// <summary>
    /// Displays an error message in red.
    /// </summary>
    /// <param name="message">The error message to be displayed.</param>
    public void PrintErrorMessage(string message) 
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write($"\n{message}");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays a message when the program exits.
    /// </summary>
    public void PrintExitMessage()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nProgrammet avslutat.");
        Console.ResetColor();
    }

    /// <summary>
    /// Prompts the user to press a key to return to the menu.
    /// </summary>
    public void PrintReturnMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn.");
        Console.ResetColor();
        Console.ReadKey(true);
    }
}
