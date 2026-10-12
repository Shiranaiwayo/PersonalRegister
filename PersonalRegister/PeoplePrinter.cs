namespace PersonalRegister;

public class PeoplePrinter
{
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
}


