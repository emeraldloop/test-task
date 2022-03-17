using System.ComponentModel.DataAnnotations;

namespace test_task.Models;

public class Client
{
    [Key]
    public long Inn { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
    public int BusinessType { get; set; }
    public long DateAdding { get; set; }
    public long DateUpdating { get; set; }
    private List<Сonstitutor> Сonstitutors { get; set; }
}