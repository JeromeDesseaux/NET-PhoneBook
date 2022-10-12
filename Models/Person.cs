using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Firstname { get; set; } = "";
    public string Lastname { get; set; } = "";
    public IEnumerable<Entry>? Entries { get; set; }
}