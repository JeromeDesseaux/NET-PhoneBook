using PhoneBook.Helpers;
using PhoneBook.Models;

namespace PhoneBook.Repositories;

public class PersonRepository: GenericRepository<Person>
{
    public PersonRepository(DataContext context) : base(context)
    {
    }
}