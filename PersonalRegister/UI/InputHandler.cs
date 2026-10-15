namespace PersonalRegister.UI;

/// <summary>
/// Handles user input from the console.
/// </summary>
public class InputHandler
{
    /// <summary>
    /// Reads the user's menu selection.
    /// </summary>
    /// <returns>The entered menu choice, or null if no input is available.</returns>
    public string? GetMenuChoice()
    {
        return Console.ReadLine()?.Trim();
    }

    /// <summary>
    /// Prompts the user to enter valid input to be searched for.
    /// </summary>
    /// <returns>The entered search text.</returns>
    public string GetAndValidateSearchText()
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
}

