using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models;
public enum ClientType
{
    [Display(Name = "ЮЛ")]
    Legal = 0,
    [Display(Name = "ИП")]
    Physical = 1
}

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required(ErrorMessage = "Не указан ИНН")]
    [Range(1000000000,9999999999,ErrorMessage = "Длина ИНН - 10 цифр")]
    public long Inn { get; set; }
    [Required (ErrorMessage = "Не указано Имя")]
    public string Name { get; set; }
    public int BusinessType { get; set; }
    public double DateAdding { get; set; }
    public double DateUpdating { get; set; }
    public List<Сonstitutor> Сonstitutors { get; set; } = new List<Сonstitutor>();
    
    public Client(long inn, string name, int type)
    {
        Inn = inn;
        Name = name;
        BusinessType = type;
        DateAdding = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
    }

    public Client()
    {
        DateAdding = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
        DateUpdating = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
    }
    
  public string GetTypeName()
    {
        switch (BusinessType)
        {
           case 0 :
               return "ЮЛ";
           case 1 :
               return "ИП";
           default:
               return "error";
        }
    }
    
}