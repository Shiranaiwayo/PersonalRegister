using PersonalRegister.Models;

namespace PersonalRegister.Operations;

/// <summary>
/// Handles sorting and searching operations on people.
/// </summary>
public class PeopleOperator
{
    /// <summary>
    /// Sorts people by ID in ascending order.
    /// </summary>
    /// <param name="people">The people to sort.</param>
    /// <param name="quantity">Optional maximum number of people to return.</param>
    /// <returns>The sorted people.</returns>
    public IEnumerable<Person> SortPeopleByID(IEnumerable<Person> people, int? quantity = null)
    {
        var sorted = people.OrderBy(person => person.Id);
        return quantity.HasValue ? sorted.Take(quantity.Value) : sorted;
    }

    /// <summary>
    /// Sorts people alphabetically by name.
    /// </summary>
    /// <param name="people">The people to sort.</param>
    /// <param name="quantity">Optional maximum number of people to return.</param>
    /// <returns>The sorted people.</returns>
    public IEnumerable<Person> SortPeopleByName(IEnumerable<Person> people, int? quantity = null)
    {
        var sorted = people.OrderBy(person => person.Name);
        return quantity.HasValue ? sorted.Take(quantity.Value) : sorted;
    }

    /// <summary>
    /// Searches for people whose names contain the specified text.
    /// </summary>
    /// <param name="people">The people to search.</param>
    /// <param name="searchText">The text to search for.</param>
    /// <returns>Matching people sorted by ID.</returns>
    public IEnumerable<Person> SearchPeopleByName(IEnumerable<Person> people, string searchText)
    {
        return people
            .Where(person => person.Name
            .Contains(searchText.Trim(), StringComparison.OrdinalIgnoreCase))
            .OrderBy(person => person.Id);
    }
}


