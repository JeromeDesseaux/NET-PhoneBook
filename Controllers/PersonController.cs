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

    [HttpGet("/")]
    public IEnumerable<PersonGetDTO> GetAllPersons()
    {
        var allPersons = this._personRepository.Get();
        return _mapper.Map<PersonGetDTO[]>(allPersons);
    }
    
    [HttpPost("/")]
    public PersonGetDTO AddPerson(PersonCreateDTO person)
    {
        var readyToInsertPerson = _mapper.Map<Person>(person);
        var dbPerson = this._personRepository.Insert(readyToInsertPerson);
        return _mapper.Map<PersonGetDTO>(dbPerson);
    }
}