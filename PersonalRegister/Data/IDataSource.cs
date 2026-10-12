using PersonalRegister.Models;

namespace PersonalRegister.Data;

public interface IDataSource
{
    List<Person> GetPeople(); //IEnumerable istället för List?
}


