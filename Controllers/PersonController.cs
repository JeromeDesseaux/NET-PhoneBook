using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Repositories;

namespace PhoneBook.Controllers;

[ApiController]
[Route("/person")]
public class PersonController
{
    private readonly ILogger<PersonController> _logger;
    private readonly PersonRepository _personRepository;

    public PersonController(ILogger<PersonController> logger, PersonRepository personRepository)
    {
        _logger = logger;
        _personRepository = personRepository;
    }

    [HttpGet("/")]
    public IEnumerable<Person> GetAllPersons()
    {
        return this._personRepository.Get();
    }
    
    [HttpPost("/")]
    public Person AddPerson(Person person)
    {
        return this._personRepository.Insert(person);
    }
}