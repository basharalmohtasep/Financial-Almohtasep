using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Models.Dto.Employees.Transaction
{
    public class EmployeeTransactionViewModel
    {
        [Range(0, double.MaxValue, ErrorMessage = "Salary change value must be a valid number.")]
        public decimal SalaryChange { get; set; }

        [Required(ErrorMessage = "Transaction date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Transaction type is required.")]
        public EmployeeTransactionType TransactionType { get; set; }

        [StringLength(500, ErrorMessage = "Note cannot exceed 500 characters.")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "At least one base model is required.")]
        public List<BaseIdNameModel<Guid>> BaseIdNameModels { get; set; } = new List<BaseIdNameModel<Guid>>();
    }
}