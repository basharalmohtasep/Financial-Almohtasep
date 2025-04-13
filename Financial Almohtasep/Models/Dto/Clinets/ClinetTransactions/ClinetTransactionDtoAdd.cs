using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Almohtasep.Models.Dto.Clinets.ClinetTransactions
{
    public class ClinetTransactionDtoAdd
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transaction Date is required.")]
        public DateTime TransactionDate { get; set; }= DateTime.Now;

        [Required(ErrorMessage = "Transaction Type is required.")]
        public ClinetTransactionType TransactionType { get; set; }
        public string Note { get; set; }
        public Guid ClinetId { get; set; }
    }
}
