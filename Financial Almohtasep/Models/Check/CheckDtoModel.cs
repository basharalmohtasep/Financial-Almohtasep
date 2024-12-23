using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Enum;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.ComponentModel.DataAnnotations;
using Financial_Almohtasep.Data;

namespace Financial_Almohtasep.Models.Checks
{
    public class CheckDtoModel()
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Checks number must be a positive integer.")]
        public int CheckNumber { get; set; }

        [Required(ErrorMessage = "Pyees ID is required.")]
        public Guid PayeeId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Bank name is required.")]
        public BankName Bank { get; set; }
        [Required(ErrorMessage = "Currency is required.")]
        public Currency Currency { get; set; } 

        [StringLength(500, ErrorMessage = "Note cannot exceed 500 characters.")]
        public string Note { get; set; } 
        public List<BaseIdNameModel<Guid>> BaseIdNames { get; set; }

    }
}
