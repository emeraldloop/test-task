using Microsoft.EntityFrameworkCore;

namespace test_task.Models.Context;

public class Context : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Сonstitutor> Сonstitutors { get; set; }
    
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}