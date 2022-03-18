using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Inn { get; set; }
    public string Name { get; set; }
    public int BusinessTypeId { get; set; }
    public double DateAdding { get; set; }
    public double DateUpdating { get; set; }
    public List<Сonstitutor> Сonstitutors { get; set; }
    public BusinessType BusinessType { get; set; }
    

    public Client()
    {
        DateAdding = DateTimeOffset.Now.ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToUnixTimeSeconds();
    }
    public Client(long inn, string name, int type)
    {
        Inn = inn;
        Name = name;
        BusinessTypeId = type;
        DateAdding = DateTimeOffset.Now.ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToUnixTimeSeconds();
    }
}