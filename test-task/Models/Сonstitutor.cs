using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models;

public class Сonstitutor
{
    [Key]
    public long Inn { get; set; }
    public long ClientInn { get; set; }
    public string FullName { get; set; }
    public double DateAdding { get; set; }
    public double DateUpdating { get; set; }
    public Client Client { get; set; }
}