using PersonalRegister.Models;

namespace PersonalRegister.Data;

/// <summary>
/// Defines a contract for retrieving people from a data source.
/// </summary>
public interface IDataSource
{
    List<Person> GetPeople();
}


