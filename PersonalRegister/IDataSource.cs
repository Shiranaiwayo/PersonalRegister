namespace PersonalRegister;

public interface IDataSource //flytta till egen flik/fil
{
    List<Person> GetPeople(); //IEnumerable istället för List?
}


