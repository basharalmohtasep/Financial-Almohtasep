using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Almohtasep.Data
{
    public class EmployeeTransaction : BaseClass
    {
        [Required, Column(TypeName = "decimal(18,4)")]
        public required decimal SalaryChange { get; set; } = decimal.Zero;
        public string Note { get; set; } = string.Empty;
        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        [Required]
        public required EmployeeTransactionType TransactionType { get; set; } = EmployeeTransactionType.None;


        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}