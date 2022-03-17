using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models;

public class Сonstitutor
{
    [Key]
    public long Inn { get; set; }
    public string FullName { get; set; }
    public long DateAdding { get; set; }
    public long DateUpdating { get; set; }
    public Client Client { get; set; }
}