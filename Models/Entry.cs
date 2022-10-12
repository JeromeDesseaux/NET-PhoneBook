namespace PhoneBook.Models;

public class Entry
{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public EntryType EntryType { get; set; } = EntryType.PHONE_NUMBER;
    public Person? Person { get; set; }
}