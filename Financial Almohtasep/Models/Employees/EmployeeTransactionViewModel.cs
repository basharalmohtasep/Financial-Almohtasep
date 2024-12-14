using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Enum;

namespace Financial_Almohtasep.Models.Employees
{
    public class EmployeeTransactionViewModel
    {
        public decimal SalaryChange { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public TransactionType TransactionType { get; set; }
        public string Note { get; set; }
        public Guid EmployeeId { get; set; }
        public List<BaseIdNameModel<Guid>> BaseIdNameModels { get; set; }
    }
}