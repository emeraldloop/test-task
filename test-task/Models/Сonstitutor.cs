using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models;

public class Сonstitutor
{
    public long ClientInn { get; set; }
    public string FullName { get; set; }
    public long DateAdding { get; set; }
    public long DateUpdating { get; set; }
    public Client Client { get; set; }
}