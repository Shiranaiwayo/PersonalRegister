namespace PersonalRegister.Models;

/// <summary>
/// Represents a person with ID, name, contactinfo, address and company info.
/// </summary>
public class Person
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public Company Company { get; set; }

    public Person(long id, 
                  string name, 
                  string email, 
                  Address address, 
                  Company company)
    {
        Id = id;
        Name = name;
        Email = email;
        Address = address;
        Company = company;
    }
}
