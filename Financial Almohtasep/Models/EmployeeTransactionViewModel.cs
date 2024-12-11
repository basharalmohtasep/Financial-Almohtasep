using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Enum;

namespace Financial_Almohtasep.Models
{
    public class EmployeeTransactionViewModel
    {
       
        public float Transaction { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid EmployeeId { get; set; }
        
    }
}
