using PersonalRegister.Models;

namespace PersonalRegister.Operations;

public class PeopleOperator
{
   
    public IEnumerable<Person> SortPeopleByID(IEnumerable<Person> people, int? quantity = null)
    {
        var sorted = people.OrderBy(person => person.Id);
        return quantity.HasValue ? sorted.Take(quantity.Value) : sorted;

    }
    public IEnumerable<Person> SortPeopleByName(IEnumerable<Person> people, int? quantity = null)
    {
        var sorted = people.OrderBy(person => person.Name);
        return quantity.HasValue ? sorted.Take(quantity.Value) : sorted;
    }
    public IEnumerable<Person> SearchPeopleByName(IEnumerable<Person> people, string searchText)
    {
        return people
            .Where(person => person.Name
            .Contains(searchText.Trim(), StringComparison.OrdinalIgnoreCase))
            .OrderBy(person => person.Id);
    }
}


