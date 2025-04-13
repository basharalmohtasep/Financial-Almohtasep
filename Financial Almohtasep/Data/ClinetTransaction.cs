using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Financial_Almohtasep.Models.Dto;
using Financial_Almohtasep.Models.Dto.Clinets.ClinetTransactions;

namespace Financial_Almohtasep.Data;

public class ClinetTransaction : BaseClass
{
    public ClinetTransaction() { }
    public ClinetTransaction (ClinetTransactionDtoAdd model)
    {
        Amount=model.Amount;
        TransactionDate = model.TransactionDate;
        TransactionType=model.TransactionType;
        Note=model.Note;
        ClinetId=model.ClinetId;
    }

    [Required(ErrorMessage = "Amount is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
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
    public void Update(ClinetTransactionDtoEdit model)
    {
        Amount = model.Amount;
        TransactionDate = model.TransactionDate;
        TransactionType = model.TransactionType;
        Note = model.Note;
    }
}
