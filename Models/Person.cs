using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace PhoneBook.Models;

public record PersonCreateDTO(string Firstname, string Lastname);
public record PersonGetDTO(string Firstname, string Lastname);

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Firstname { get; set; } = "";
    public string Lastname { get; set; } = "";
    public IEnumerable<Entry>? Entries { get; set; }
}

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonCreateDTO>().ReverseMap();
        CreateMap<Person, PersonGetDTO>().ReverseMap();
    }
}