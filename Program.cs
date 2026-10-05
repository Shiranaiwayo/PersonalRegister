

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

            var choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    PrintAllPeopleIDSorted(people);
                    break;
                case "2":
                    //Method PrintTop5PeopleIDSorted
                    break;
                case "3":
                    //Method PrintAllPeopleNameSorted
                    break;
                case "4":
                    //Method PrintTop5PeopleNameSorted
                    break;
                case "5":
                    //Method SearchPeopleByName
                    break;
                case "6":
                    continues = false;
                    Console.WriteLine("\nProgrammet avslutat.");
                    continue;
                default:
                    Console.WriteLine("Ogiltig input. Välj ett nummer mellan 1 och 6.");
                    break;
            }
            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
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
    private static void PrintAllPeopleIDSorted(List<Person> people)
    {
        PrintPeople(people.OrderBy(person => person.Id));
    }

}


