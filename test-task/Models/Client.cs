using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Inn { get; set; }
    public string Name { get; set; }
    public int BusinessType { get; set; }
    public long DateAdding { get; set; }
    public long DateUpdating { get; set; }
    private List<Сonstitutor> Сonstitutors { get; set; }

    public Client()
    {
        DateAdding = DateTimeOffset.Now.ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToUnixTimeSeconds();
    }
    public Client(long inn, string name, int type)
    {
        Inn = inn;
        Name = name;
        BusinessType = type;
        DateAdding = DateTimeOffset.Now.ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToUnixTimeSeconds();
    }
}