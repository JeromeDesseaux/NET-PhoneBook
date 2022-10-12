using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models;

public class Entry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public EntryType EntryType { get; set; } = EntryType.PHONE_NUMBER;
    public Person? Person { get; set; }
}