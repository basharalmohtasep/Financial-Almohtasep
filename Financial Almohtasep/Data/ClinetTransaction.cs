using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Almohtasep.Data;

public class ClinetTransaction : BaseClass
{
    [Required(ErrorMessage = "Amount is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; } = 0;

    [Required(ErrorMessage = "Transaction Date is required.")]
    public DateTime TransactionDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Transaction Type is required.")]
    public ClinetTransactionType TransactionType { get; set; } = ClinetTransactionType.None;

    [MaxLength(500, ErrorMessage = "Note cannot exceed 500 characters.")] 
    public string Note { get; set; } = string.Empty;


    [Required(ErrorMessage = "Client ID is required.")]
    [ForeignKey(nameof(ClinetId))]
    public Guid ClinetId { get; set; }
    public Clinet Clinet { get; set; }
}
