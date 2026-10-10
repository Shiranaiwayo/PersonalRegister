namespace PersonalRegister;

class DataStorage : IDataSource
{
    /// <summary>
    /// Returns the hardcoded people to be used in PersonalRegister
    /// </summary>
    /// <returns></returns>
    public List<Person> GetPeople()
    {
        return new List<Person>
        {
        new Person(198802242242,
            "Maria Andersson",
            "maria.andersson@example.com",
            new Address("Storgatan 12", "111 22", "Stockholm"),
            new Company("Nordic Solutions", "Technology for a better future")),

        new Person(
            199001011239,
            "Erik Johansson",
            "erik.johansson@example.com",
            new Address("Parkvägen 8", "411 18", "Göteborg"),
            new Company("Bright Ideas AB", "Ideas that make a difference")),

        new Person(
            199505164460,
            "Sofia Nilsson",
            "sofia.nilsson@example.com",
            new Address("Kyrkogatan 4", "223 50", "Lund"),
            new Company("Green World", "Sustainable choices for everyone")),

        new Person(
            198503151113,
            "Lars Karlsson",
            "lars.karlsson@example.com",
            new Address("Vasagatan 21", "722 15", "Västerås"),
            new Company("Reliable Systems", "Simple solutions, reliable results")),

        new Person(
            197308196282,
            "Anna Eriksson",
            "anna.eriksson@example.com",
            new Address("Hamngatan 6", "211 10", "Malmö"),
            new Company("Future Works", "Building tomorrow today")),

        new Person(
            199206273339,
            "Johan Larsson",
            "johan.larsson@example.com",
            new Address("Skolgatan 19", "903 22", "Umeå"),
            new Company("Smart Design", "Design that works")),

        new Person(
            200109108822,
            "Emma Persson",
            "emma.persson@example.com",
            new Address("Björkvägen 3", "702 25", "Örebro"),
            new Company("Creative Minds", "Creativity without limits")),

        new Person(
            197909085578,
            "Oskar Svensson",
            "oskar.svensson@example.com",
            new Address("Ågatan 15", "582 22", "Linköping"),
            new Company("Digital Partners", "Your digital advantage")),

        new Person(
            198307012461,
            "Karin Gustafsson",
            "karin.gustafsson@example.com",
            new Address("Strandvägen 10", "291 31", "Kristianstad"),
            new Company("Oceanic Group", "Closer to the possibilities")),

        new Person(
            196804127198,
            "Nils Berg",
            "nils.berg@example.com",
            new Address("Lövvägen 7", "891 33", "Örnsköldsvik"),
            new Company("Mountain Tech", "Strong solutions from the north")),

        new Person(
            199704286842,
            "Elin Lindberg",
            "elin.lindberg@example.com",
            new Address("Stationsgatan 2", "831 45", "Östersund"),
            new Company("Central Services", "Service you can trust")),

        new Person(
            200007319994,
            "Per Holm",
            "per.holm@example.com",
            new Address("Industrigatan 11", "553 02", "Jönköping"),
            new Company("Holm Consulting", "Knowledge creates progress"))
        };
    }
}


