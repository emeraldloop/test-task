using Microsoft.EntityFrameworkCore;

namespace test_task.Models.Context;

public class Context : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Сonstitutor> Сonstitutors { get; set; }
    public DbSet<BusinessType> BusinessType { get; set; }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
        Database.EnsureCreated();
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessType>().HasData(
            new BusinessType[]
            {
                new BusinessType { Id=0, Name="ЮЛ"},
                new BusinessType { Id=1, Name="ИП"}
            });
    }
}