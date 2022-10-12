using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Helpers;

public class DataContext: DbContext
{
    private readonly IConfiguration? _configuration;

    public DbSet<Entry> Entries => Set<Entry>();
    public DbSet<Person> Persons => Set<Person>();
    

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(_configuration.GetConnectionString("Database"));
    }
    
}