using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Entity.Base;

public class BaseClass
{
    [Key]
    public Guid Id { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
