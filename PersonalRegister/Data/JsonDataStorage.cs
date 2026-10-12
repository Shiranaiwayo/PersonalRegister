using PersonalRegister.Models;
using System.Text.Json;

namespace PersonalRegister.Data;

public class JsonDataStorage : IDataSource
{
    public List<Person> GetPeople()
    {
        string json = File.ReadAllText("people.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(json, options);
        return people ?? new List<Person>();
    }
}


