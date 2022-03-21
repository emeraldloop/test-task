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
    public List<Сonstitutor> Сonstitutors { get; set; } = new List<Сonstitutor>();
    public BusinessType BusinessType { get; set; }
    

    public Client()
    {
        
        
    }
    public Client(long inn, string name, int type)
    {
        Inn = inn;
        Name = name;
        BusinessTypeId = type;
        DateAdding = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
    }
    public string GetTypeName()
    {
        if (BusinessTypeId != 0 && BusinessTypeId != 1 ) return "error";
        return (BusinessTypeId == 0) ? "ЮЛ" : "ИП";
    }

}