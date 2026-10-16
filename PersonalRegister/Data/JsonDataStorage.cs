using PersonalRegister.Models;
using System.Text.Json;

namespace PersonalRegister.Data;

/// <summary>
/// Retrieves person data from a JSON file.
/// </summary>
public class JsonDataStorage : IDataSource
{
    /// <summary>
    /// Reads and deserializes people from a JSON file.
    /// </summary>
    /// <returns>A list of people from the JSON file.</returns>
    public List<Person> GetPeople()
    {
        string json = File.ReadAllText("Data/people.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(json, options);
        return people ?? new List<Person>();
    }
}


