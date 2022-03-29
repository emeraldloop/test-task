using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Models;

public class Сonstitutor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required(ErrorMessage = "Не указан ИНН")]
    [Range(1000000000,9999999999,ErrorMessage = "Длина ИНН - 10 цифр")]
    public long Inn { get; set; }
    public long ClientInn { get; set; }
    [Required (ErrorMessage = "Не указано Имя")]
    public string FullName { get; set; }
    public double DateAdding { get; set; }
    public double DateUpdating { get; set; }
    public Client? Client { get; set; }

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
