using Financial_Almohtasep.Models.Enum;

namespace Financial_Almohtasep.Models
{
    public class EmployeeTransactionViewModel
    {

        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid EmployeeId { get; set; }
    }
}