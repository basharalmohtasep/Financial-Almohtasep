
using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Enum;

namespace Financial_Almohtasep.Models.Dto.Clinets.ClinetTransactions
{
    public class ClinetTransactionDto
    {
        public ClinetTransactionDto()
        {

        }
        public ClinetTransactionDto(ClinetTransaction model)
        {
            Id = model.Id;
            Amount = model.Amount;
            TransactionDate = model.TransactionDate;
            TransactionType = model.TransactionType;
            Note = model.Note;
            ClinetId = model.ClinetId;
        }
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public ClinetTransactionType TransactionType { get; set; }
        public string Note { get; set; }
        public Guid ClinetId { get; set; }
    }

}
