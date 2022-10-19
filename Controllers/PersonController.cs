using AutoMapper;
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
    private readonly IMapper _mapper;

    public PersonController(ILogger<PersonController> logger, PersonRepository personRepository, IMapper mapper)
    {
        _logger = logger;
        _personRepository = personRepository;
        _mapper = mapper;
    }

    [HttpGet("")]
    public IEnumerable<PersonGetDTO> GetAllPersons()
    {
        _logger.Log(LogLevel.Information, "Getting all persons");
        var allPersons = this._personRepository.Get();
        return _mapper.Map<PersonGetDTO[]>(allPersons);
    }
    
    [HttpPost("")]
    public PersonGetDTO AddPerson(PersonCreateDTO person)
    {
        _logger.Log(LogLevel.Information, "Storing a new person into the database");
        var readyToInsertPerson = _mapper.Map<Person>(person);
        var dbPerson = this._personRepository.Insert(readyToInsertPerson);
        return _mapper.Map<PersonGetDTO>(dbPerson);
    }
    
    [HttpPut("{id:int}")]
    public PersonGetDTO EditPerson(int id, PersonCreateDTO person)
    {
        var loggingMessage = String.Format("Editing person with id {0}", id);
        _logger.Log(LogLevel.Information, loggingMessage);
        var dbPerson = _personRepository.GetByID(id);
        dbPerson.Firstname = person.Firstname;
        dbPerson.Lastname = person.Lastname;
        _personRepository.Update(dbPerson);
        return _mapper.Map<PersonGetDTO>(dbPerson);
    }
    
    [HttpDelete("/{id:int}")]
    public void DeletePerson(int id)
    {
        var loggingMessage = String.Format("Deleting person with id {0}", id);
        _logger.Log(LogLevel.Information, loggingMessage);
        var toDelete = _personRepository.GetByID(id);
        _personRepository.Delete(toDelete);
    }
}