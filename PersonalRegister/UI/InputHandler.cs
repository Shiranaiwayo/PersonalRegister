namespace PersonalRegister.UI;

public class InputHandler
{
    public string? GetMenuChoice()
    {
        return Console.ReadLine()?.Trim();
    }

    public string GetSearchText()
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

