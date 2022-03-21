using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models;

public class Сonstitutor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Inn { get; set; }
    public long ClientInn { get; set; }
    public string FullName { get; set; }
    public double DateAdding { get; set; }
    public double DateUpdating { get; set; }
    public Client Client { get; set; }

    public Сonstitutor()
    {
        DateAdding = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
    }

    public Сonstitutor(long inn,long clientInn,string fullName)
    {
        Inn = inn;
        ClientInn = clientInn;
        FullName = fullName;
        DateAdding = DateTimeOffset.Now.ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToUnixTimeSeconds();
    }
    
}
