namespace PhoneBook.Models;

public class Person
{
    public int Id { get; set; }
    public string Firstname { get; set; } = "";
    public string Lastname { get; set; } = "";
    public IEnumerable<Entry>? Entries { get; set; }
}