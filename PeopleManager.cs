

namespace PersonalRegister;

public class PeopleManager
{
    public void PrintPeople(IEnumerable<Person> people) //gör om till private efter Json test
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
    public void PrintPeopleIDSorted(IEnumerable<Person> people, int? quantity = null)
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
    public void PrintPeopleNameSorted(IEnumerable<Person> people, int? quantity = null)
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
    public void SearchPeopleByName(IEnumerable<Person> people, string? searchText)
    {
        while (string.IsNullOrEmpty(searchText?.Trim()))
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
}


