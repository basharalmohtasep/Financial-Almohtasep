using Financial_Almohtasep.Models.Enum;

namespace Financial_Almohtasep.Models.Employees
{
    public class EmployeeTransactionViewModel
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Note { get; set; }
        public Guid EmployeeId { get; set; }
    }
}